using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel.App
{
    public partial class Cazare : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        DateTime dataInceputCazare;
        DateTime dataSfarsitCazare;

        Dictionary<string, int> camereDisponibile;

        string idClientGasit;
        int nrCamereSelectate;

        int id_angajat;

        string nume_angajat;

        int nrNopti;
        int nrOaspeti;
        string tipCazare;
        public Cazare(int nrNopti, int nrOaspeti, int id_angajat)
        {
            //MessageBox.Show(nrOaspeti.ToString()+" oaspeti");
            this.nrNopti = nrNopti;
            this.nrOaspeti = nrOaspeti;
            tipCazare = "fara rezervare";

            this.id_angajat = id_angajat;

            dataInceputCazare = DateTime.Now;
            //int test = DateTime.Today.Hour;
            //dataInceputCazare = DateTime.Parse("08/26/2021");
            dataSfarsitCazare = dataInceputCazare.AddDays(nrNopti);

            InitializeComponent();

            //MessageBox.Show(id_angajat + " angajat id");
        }

        string codIdentitate;
        int id_rezervare;
        public Cazare(string codIdentitate, int id_rezervare, int id_angajat)
        {
            this.codIdentitate = codIdentitate;
            tipCazare = "cu rezervare";
            this.id_angajat = id_angajat;
            this.id_rezervare = id_rezervare;


            // dataInceput = data din rezervare extrasa

            InitializeComponent();
        }

        int id_cazare;
        string tipClient;
        public Cazare(DateTime dataInceputCazare, DateTime dataSfarsitCazare, int id_cazare, string tipClient, int nrOaspeti)
        {
            tipCazare = "istoric";
            this.id_cazare = id_cazare;
            this.dataInceputCazare = dataInceputCazare;
            this.dataSfarsitCazare = dataSfarsitCazare;
            this.tipClient = tipClient;
            nrNopti = (dataSfarsitCazare - dataInceputCazare).Days;
            this.nrOaspeti = nrOaspeti;

            InitializeComponent();
            label4.Text = "Camere selectate:";
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            btnStergeServiciu.Visible = false;
            label22.Text = "ISTORIC CAZARE";
            label22.Location = new Point(559, 58);
            labelHeaderPerioada.Location = new Point(583, 104);
            //this.Size = new Size(1393, 920);
            //btnInainte.Location = new Point(1184, 775);
            //btnInapoi.Location = new Point(1015, 775);
        }

        DataTable serviciiSelectate;
        private void Cazare_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";

            idClientGasit = null;
            nrCamereSelectate = 0;

            labelHeaderPerioada.Text = dataInceputCazare.ToShortDateString() + " - " + dataSfarsitCazare.ToShortDateString();

            //if (tipCazare == "fara rezervare")
            //{

                DisponibilitateCamere evidentaCamere = new DisponibilitateCamere();
                camereDisponibile = evidentaCamere.disponibilitateCamere(dataInceputCazare, dataSfarsitCazare);

                try
                {
                    con.Open();
                    sqlcmd = "select nume + ' ' + prenume as nume from angajati where id_angajat='" + id_angajat + "'";
                    SqlCommand cmd = new SqlCommand(sqlcmd, con);
                    string nume_angajat = (string)cmd.ExecuteScalar();
                    labelNumeReceptioner.Text = nume_angajat;

                    sqlcmd = "select Id, denumire from categorii_camere";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "CategoriiCamere");

                    cbCategoriiCamere.Items.Add("Toate camerele");
                    foreach (DataRow row in ds.Tables["CategoriiCamere"].Rows)
                    {
                        cbCategoriiCamere.Items.Add(row["denumire"].ToString());
                    }
                    cbCategoriiCamere.SelectedIndex = 0;

                    if (tipCazare == "fara rezervare")
                    {
                        //se extrag toate camerele existente in hotel
                        sqlcmd = "select id_camera, numar, categorii_camere.denumire as categorie, etaj, nr_camere, categorii_camere.nr_oaspeti as capacitate_oaspeti, tarife.valoare_lei from camere join categorii_camere on camere.id_categorie_camere=categorii_camere.Id join tarife on camere.id_categorie_camere=tarife.id_categorie_camera where status = 'activ' and tarife.data_inceput < '" + dataInceputCazare + "' and tarife.data_sfarsit > '" + dataInceputCazare + "'";
                        da = new SqlDataAdapter(sqlcmd, con);
                        da.Fill(ds, "Camere");

                        //se extrag toate camerele ocupate pentru a fi scazute
                        sqlcmd = "select id_camera from camere_cazari join cazari on camere_cazari.id_cazare = cazari.id_cazare where '" + dataInceputCazare + "' > checkin and '" + dataInceputCazare + "' < checkout";
                        da = new SqlDataAdapter(sqlcmd, con);
                        da.Fill(ds, "CamereOcupate");

                        List<DataRow> listaCamereDeSters = new List<DataRow>();
                        foreach (DataRow cameraOcupata in ds.Tables["CamereOcupate"].Rows)
                        {
                            foreach (DataRow camera in ds.Tables["Camere"].Rows)
                            {
                                if (camera["id_camera"].ToString() == cameraOcupata["id_camera"].ToString())
                                {
                                    listaCamereDeSters.Add(camera);
                                }
                            }
                        }
                        foreach (DataRow cameraOcupata in listaCamereDeSters)
                        {
                            ds.Tables["Camere"].Rows.Remove(cameraOcupata);
                        }
                        ds.Tables["Camere"].AcceptChanges();

                        //posibil eroare
                        ds.Tables["Camere"].Columns.Add("selectat", System.Type.GetType("System.Boolean")); //https://stackoverflow.com/a/1339889/16440804
                        ds.Tables["Camere"].Columns["selectat"].SetOrdinal(0);
                    }
                    else if (tipCazare == "istoric")
                    {
                        sqlcmd = "select camere_cazari.id_camera, camere.numar, categorii_camere.denumire as categorie, camere.etaj, camere.nr_camere, categorii_camere.nr_oaspeti as capacitate_oaspeti, tarife.valoare_lei from camere_cazari join camere on camere.id_camera = camere_cazari.id_camera join categorii_camere on categorii_camere.Id = camere.id_categorie_camere join tarife on camere.id_categorie_camere=tarife.id_categorie_camera where status = 'activ' and tarife.data_inceput < '"+dataInceputCazare+"' and tarife.data_sfarsit > '"+dataInceputCazare+"' and id_cazare='"+id_cazare+"'";
                        da = new SqlDataAdapter(sqlcmd, con);
                        da.Fill(ds, "Camere");
                    }

                    ds.Tables["Camere"].Columns.Add("total_lei", System.Type.GetType("System.Decimal"));

                    //se extrag camerele cu reducere valabile in perioada cazarii
                    sqlcmd = "select categorii_camere.denumire, procent from reduceri join categorii_camere on categorii_camere.Id=reduceri.id_categorie_camera where id_categorie_camera is not null and data_inceput<='" + dataInceputCazare + "' and data_sfarsit>'" + dataInceputCazare + "'";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "ReduceriCamere");

                    foreach (DataRow camera in ds.Tables["Camere"].Rows)
                    {
                        if(tipCazare=="fara rezervare")
                            camera["selectat"] = false;
                        foreach (DataRow cameraCuReducere in ds.Tables["ReduceriCamere"].Rows)
                        {
                            if (cameraCuReducere["denumire"].ToString() == camera["categorie"].ToString())
                            {
                                camera["valoare_lei"] = ((Convert.ToDecimal(camera["valoare_lei"])) * ((100 - Convert.ToDecimal(cameraCuReducere["procent"].ToString())) / 100)).ToString("0.00");
                                
                            }
                        }
                        camera["total_lei"] = Convert.ToDecimal(camera["valoare_lei"]) * nrNopti;
                    }

                    //cbModPlata.Enabled=false; //TEMPORAR
                    dgvCamere.DataSource = ds.Tables["Camere"];

                    if (tipCazare == "fara rezervare")
                        dgvCamere.Columns["selectat"].HeaderText = "Selectat";
                    dgvCamere.Columns["id_camera"].Visible = false;
                    dgvCamere.Columns["numar"].HeaderText = "Camera";
                    dgvCamere.Columns["categorie"].HeaderText = "Categorie";
                    dgvCamere.Columns["etaj"].HeaderText = "Etaj";
                    dgvCamere.Columns["capacitate_oaspeti"].HeaderText = "Capacitate oaspeti";
                    dgvCamere.Columns["nr_camere"].HeaderText = "Nr. camere";
                    dgvCamere.Columns["valoare_lei"].HeaderText = "Pret lei / noapte";
                    dgvCamere.Columns["total_lei"].HeaderText = "Total lei "+nrNopti.ToString()+" nopti";
                    
                    for (int i = 1; i < dgvCamere.Columns.Count; i++)
                    {
                        dgvCamere.Columns[i].ReadOnly = true;
                    }

                    /*DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                    column.Name = "nr_oaspeti";
                    column.HeaderText = "Nr. oaspeti";
                    dgvCamere.Columns.Add(column);

                    foreach (DataGridViewRow dgvrow in dgvCamere.Rows)
                    {
                        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dgvrow.Cells["nr_oaspeti"];
                        for (int i = 1; i <= Convert.ToInt32(dgvrow.Cells["capacitate_oaspeti"].Value); i++)
                            cell.Items.Add(i.ToString());
                        cell.Value = cell.Items[cell.Items.Count-1];
                    }*/

                    //extrage toate serviciile cu tarif
                    if(tipCazare=="fara rezervare")
                    {
                        sqlcmd = "select servicii.id_serviciu, denumire, tip, tarife.valoare_lei from servicii join tarife on tarife.id_serviciu = servicii.id_serviciu where status = 'activ' and '" + dataInceputCazare + "' >= tarife.data_inceput and '" + dataInceputCazare + "' < tarife.data_sfarsit";
                        da = new SqlDataAdapter(sqlcmd, con);
                        da.Fill(ds, "Servicii");

                        //MessageBox.Show(ds.Tables["Servicii"].Rows.Count.ToString() + " inregistrari in serviciii");

                        cbServicii.DisplayMember = "denumire";
                        cbServicii.ValueMember = "id_serviciu";
                        cbServicii.DataSource = ds.Tables["Servicii"];

                        if (ds.Tables["Servicii"].Rows.Count > 0)
                            cbServicii.SelectedIndex = 0;

                        serviciiSelectate = new DataTable();
                        serviciiSelectate.Columns.Add("id_serviciu", typeof(Int32));
                        serviciiSelectate.Columns.Add("denumire", typeof(string));
                        serviciiSelectate.Columns.Add("nr_beneficiari", typeof(string));
                        serviciiSelectate.Columns.Add("data_inceput", typeof(DateTime));
                        serviciiSelectate.Columns.Add("data_sfarsit", typeof(DateTime));
                        serviciiSelectate.Columns.Add("valoare_lei", typeof(decimal));
                        serviciiSelectate.Columns.Add("total_lei", typeof(decimal));

                        dgvServicii.DataSource = serviciiSelectate;

                        dgvServicii.Columns["id_serviciu"].Visible = false;
                        dgvServicii.Columns["denumire"].HeaderText = "Serviciu";
                        dgvServicii.Columns["nr_beneficiari"].HeaderText = "Nr. beneficiari";
                        dgvServicii.Columns["data_inceput"].HeaderText = "Data inceput";
                        dgvServicii.Columns["data_sfarsit"].HeaderText = "Data sfarsit";
                        dgvServicii.Columns["valoare_lei"].HeaderText = "Pret lei / zi";
                        dgvServicii.Columns["total_lei"].HeaderText = "Total lei";

                        nrBeneficiari.Value = nrOaspeti;
                        nrBeneficiari.Maximum = nrOaspeti;
                        nrBeneficiari.Minimum = 1;
                    }
                    else if (tipCazare == "istoric")
                    {
                        sqlcmd = "select servicii_cazari.id_serviciu, servicii.denumire, nr_beneficiari, servicii_cazari.data_inceput, servicii_cazari.data_sfarsit, tarife.valoare_lei from servicii_cazari join servicii on servicii.id_serviciu=servicii_cazari.id_serviciu   join tarife on tarife.id_serviciu = servicii.id_serviciu where status = 'activ' and '" + dataInceputCazare + "' >= tarife.data_inceput and '" + dataInceputCazare + "' < tarife.data_sfarsit and id_cazare='" + id_cazare + "'";
                        da = new SqlDataAdapter(sqlcmd, con);
                        da.Fill(ds, "Servicii");

                        ds.Tables["Servicii"].Columns.Add("total_lei", typeof(decimal));

                        dgvServicii.DataSource = ds.Tables["Servicii"];

                        dgvServicii.Columns["id_serviciu"].Visible = false;
                        dgvServicii.Columns["denumire"].HeaderText = "Serviciu";
                        dgvServicii.Columns["nr_beneficiari"].HeaderText = "Nr. beneficiari";
                        dgvServicii.Columns["data_inceput"].HeaderText = "Data inceput";
                        dgvServicii.Columns["data_sfarsit"].HeaderText = "Data sfarsit";
                        dgvServicii.Columns["valoare_lei"].HeaderText = "Pret lei / zi";
                        dgvServicii.Columns["total_lei"].HeaderText = "Total lei";

                        int diferentaNopti;
                        foreach (DataRow serviciu in ds.Tables["Servicii"].Rows)
                        {
                            diferentaNopti = (Convert.ToDateTime(serviciu["data_sfarsit"]) - Convert.ToDateTime(serviciu["data_inceput"])).Days;
                            if(diferentaNopti==0)
                                diferentaNopti=1;
                            serviciu["total_lei"] = Convert.ToDecimal(serviciu["valoare_lei"]) * Convert.ToInt32(serviciu["nr_beneficiari"]) * diferentaNopti;
                        }

                        if(tipClient=="Persoana fizica")
                            sqlcmd = "select persoane_fizice.nume, persoane_fizice.prenume, persoane_fizice.cnp as CI, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_fizice on persoane_fizice.id_client=clienti.id_client join cazari on cazari.id_client=clienti.id_client where id_cazare='"+id_cazare+"'";
                        else
                            sqlcmd = "select persoane_juridice.denumire as nume, persoane_juridice.cui as CI, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_juridice on persoane_juridice.id_client=clienti.id_client join cazari on cazari.id_client=clienti.id_client where id_cazare='"+id_cazare+"'";

                        da = new SqlDataAdapter(sqlcmd, con);
                        da.Fill(ds, "Client");

                        cbTipClient.Text = tipClient;
                        tbCI.Text = ds.Tables["Client"].Rows[0]["CI"].ToString();
                        tbNume.Text = ds.Tables["Client"].Rows[0]["nume"].ToString();
                        if (tipClient == "Persoana fizica")
                            tbPrenume.Text = ds.Tables["Client"].Rows[0]["prenume"].ToString();
                        else if(tipClient=="Persoana juridica")
                        {
                            tbPrenume.Visible = false;
                            labelPrenume.Visible = false;
                        }

                        cbCategorieClient.Text = ds.Tables["Client"].Rows[0]["tip_client"].ToString();
                        tbEmail.Text = ds.Tables["Client"].Rows[0]["email"].ToString();
                        tbTelefon.Text = ds.Tables["Client"].Rows[0]["telefon"].ToString();
                        tbAdresa.Text = ds.Tables["Client"].Rows[0]["adresa"].ToString();
                        tbCodPostal.Text = ds.Tables["Client"].Rows[0]["cod_postal"].ToString();

                        tbNume.Enabled = false;
                        tbPrenume.Enabled = false;
                        tbEmail.Enabled = false;
                        tbTelefon.Enabled = false;
                        tbCodPostal.Enabled = false;
                        tbAdresa.Enabled = false;
                        cbCategorieClient.Enabled = false;
                        tbCI.Enabled = false;
                        cbTipClient.Enabled = false;

                        btnStergeDate.Visible = false;
                        btnCautaClient.Visible = false;
                    }

                    btnInapoi.Visible = false;

                    cbTipClient.SelectedIndex = 0;

                    sqlcmd = "select procent, tip_client from reduceri where id_categorie_camera is null and data_inceput <= '"+dataInceputCazare+"' and data_sfarsit > '"+dataInceputCazare+"'";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "ReduceriClienti");

                    sqlcmd = "select tip_client, categorie from categorii_clienti";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "CategoriiClienti");

                    cbCategorieClient.SelectedIndex = 0;

                    //MessageBox.Show(ds.Tables["CategoriiClienti"].Rows.Count.ToString());

                    cbCategorieClient.Items.Clear();
                    cbCategorieClient.Items.Add("Niciuna");
                    cbCategorieClient.SelectedIndex=0;
                    foreach (DataRow categorieClient in ds.Tables["CategoriiClienti"].Rows)
                    {
                        if (categorieClient["categorie"].ToString() == "Persoana fizica")
                            cbCategorieClient.Items.Add(categorieClient["tip_client"].ToString());
                    }

                    cbModPlata.SelectedIndex = 0;

                    dgvCamere.ClearSelection();

                    if(tipCazare=="fara rezervare")
                    {
                        
                    }
                    labelNrOaspeti.Text = nrOaspeti.ToString();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message+"\n"+err.StackTrace);
                }
                finally
                {
                    con.Close();
                }
            this.CenterToScreen();
        }

        int pageIndex=1;
        decimal totalLei;
        DataRow[] camereSelectate;
        private void btnInainte_Click(object sender, EventArgs e)
        {
            if(tipCazare=="fara rezervare")
                camereSelectate = ds.Tables["Camere"].Select("selectat='true'");
            if (pageIndex == 1)
            {
                if (tipCazare == "fara rezervare")
                {
                    int totalLocuriSelectate = 0;
                    foreach (DataRow cameraSelectata in camereSelectate)
                    {
                        totalLocuriSelectate = totalLocuriSelectate + Convert.ToInt32(cameraSelectata["capacitate_oaspeti"]);
                    }
                    if (nrOaspeti <= totalLocuriSelectate)
                        pageIndex++;
                    else
                        MessageBox.Show("Nu ati selectat suficiente camere pentru a gazdui toti oaspetii!\n\nNumar oaspeti: " + nrOaspeti + "\nNumar locuri ocupate: " + totalLocuriSelectate);
                }
                else
                    pageIndex++;
            }
            else if (pageIndex == 3)
            {
                if (tipCazare == "fara rezervare")
                {
                    if (string.IsNullOrWhiteSpace(tbCI.Text) || string.IsNullOrWhiteSpace(tbNume.Text) || string.IsNullOrWhiteSpace(tbEmail.Text) || string.IsNullOrWhiteSpace(tbTelefon.Text) || string.IsNullOrWhiteSpace(tbCodPostal.Text) || string.IsNullOrWhiteSpace(tbAdresa.Text))
                    {
                        MessageBox.Show("Nu ati completat toate campurile pentru a continua");
                    }
                    else
                    {
                        if (cbTipClient.Text == "Persoana fizica" && string.IsNullOrWhiteSpace(tbPrenume.Text))
                        {
                            MessageBox.Show("Nu ati completat toate campurile pentru a continua");
                        }
                        else
                            pageIndex++;
                    }
                }
                else if (tipCazare == "istoric")
                    pageIndex++;
            }
            else
                pageIndex++;

            switch (pageIndex)
            {
                case 2:
                    btnInapoi.Visible = true;
                    panel1.Visible = false;
                    panel2.Visible = true;
                    break;
                case 3:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    break;
                case 4:
                    panel3.Visible = false;
                    panel4.Visible = true;
                    btnInainte.Visible = false;
                    labelNumeClient.Text = tbNume.Text;
                    if (cbTipClient.Text == "Persoana fizica")
                        labelNumeClient.Text = labelNumeClient.Text + " " + tbPrenume.Text;
                    labelPerioadaCazare.Text = dataInceputCazare.ToShortDateString() + " - " + dataSfarsitCazare.ToShortDateString();

                    if (tipCazare == "fara rezervare")
                    {
                        btnConfirmaCazare.Visible = true;
                        
                        labelNrCamereSelectate.Text = camereSelectate.Count().ToString();
                        labelNrServiciiSelectate.Text = serviciiSelectate.Rows.Count.ToString();

                        totalLei = 0;
                        foreach (DataRow cameraAdaugata in camereSelectate)
                        {
                            totalLei = totalLei + Convert.ToInt32(cameraAdaugata["total_lei"]);
                        }
                        foreach (DataRow serviciuAdaugat in serviciiSelectate.Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(serviciuAdaugat["total_lei"]);
                        }

                        labelTotalLei.Text = totalLei.ToString("0.00") + " lei";
                    }
                    else if (tipCazare == "istoric")
                    {
                        labelNrCamereSelectate.Text = dgvCamere.Rows.Count.ToString();
                        labelNrServiciiSelectate.Text = dgvServicii.Rows.Count.ToString();

                        totalLei = 0;
                        foreach (DataRow cameraSelectata in ds.Tables["Camere"].Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(cameraSelectata["total_lei"]);
                        }
                        foreach (DataRow serviciuSelectat in ds.Tables["Servicii"].Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(serviciuSelectat["total_lei"]);
                        }
                        labelTotalLei.Text = totalLei.ToString("0.00") + " lei";

                    }

                    foreach (DataRow reducere in ds.Tables["ReduceriClienti"].Rows)
                    {
                        if (reducere["tip_client"].ToString() == cbCategorieClient.Text)
                        {
                            totalLei = totalLei * ((100 - Convert.ToDecimal(reducere["procent"])) / 100);
                            labelTotalLei.Text = totalLei.ToString("0.00") + " lei (reducere " + reducere["procent"].ToString() + "% " + cbCategorieClient.Text + ")";
                        }
                    }
                    break;
            }
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            pageIndex--;
            switch (pageIndex)
            {
                case 1:
                    btnInapoi.Visible = false;
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;
                case 2:
                    panel2.Visible = true;
                    panel3.Visible = false;
                    break;
                case 3:
                    panel4.Visible = false;
                    panel3.Visible = true;
                    btnInainte.Visible = true;
                    btnConfirmaCazare.Visible = false;
                    
                    break;
            }
        }

        private void btnAplicaFiltru_Click(object sender, EventArgs e)
        {
            if (cbCategoriiCamere.SelectedIndex==0){
                ds.Tables["Camere"].DefaultView.RowFilter = "";
                labelNrCamereDisponibile.Visible = false;
            }
                
            else
            {
                ds.Tables["Camere"].DefaultView.RowFilter = "selectat='True' or categorie='" + cbCategoriiCamere.Text + "'";
            }
            dgvCamere.ClearSelection();
            coloreazaCamereSelectate();
            labelReducereCameraSelectata.Visible = false;
        }

        private void dgvCamere_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                {
                    //se salveaza bifarea checkbox-ului fara a fi nevoie apasaera inafara celulei
                    dgvCamere.CommitEdit(DataGridViewDataErrorContexts.Commit); //https://stackoverflow.com/a/11844206/16440804

                    //algoritm care afiseaza de cate ori a fost bifata o categorie de camere
                    nrCamereSelectate = 0;
                    foreach (DataRow row in ds.Tables["Camere"].Rows)
                    {
                        if (Convert.ToBoolean(row["selectat"]) == true && row["categorie"].ToString() == dgvCamere.Rows[e.RowIndex].Cells["categorie"].Value.ToString())
                            nrCamereSelectate++;
                    }

                    if (nrCamereSelectate > camereDisponibile[dgvCamere.Rows[e.RowIndex].Cells["categorie"].Value.ToString()])
                    {
                        dgvCamere.Rows[e.RowIndex].Cells["selectat"].Value = false;
                        MessageBox.Show("Nu poti selecta mai multe camere");
                    }

                    ds.Tables["Camere"].AcceptChanges();
                    dgvCamere.ClearSelection();
                    coloreazaCamereSelectate();
            }
        }

        public void coloreazaCamereSelectate()
        {
            foreach (DataGridViewRow rows in dgvCamere.Rows)
            {
                if (Convert.ToBoolean(rows.Cells[0].Value.ToString()) == true)
                {
                    rows.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }

        private void btnAdaugaServiciu_Click(object sender, EventArgs e)
        {
            DataRow serviciuGasit =  serviciiSelectate.Select("denumire='" + cbServicii.Text + "' and data_inceput='" + dataInceputServiciu.Value.ToShortDateString() + "'").FirstOrDefault();
            if (serviciuGasit != null)
            {
                MessageBox.Show("Serviciul este deja introdus!");
            }
            else
            {
                DataRow serviciuAdaugat = serviciiSelectate.NewRow();

                serviciuAdaugat["id_serviciu"] = cbServicii.SelectedValue;
                serviciuAdaugat["denumire"] = cbServicii.Text;
                serviciuAdaugat["nr_beneficiari"] = nrBeneficiari.Value;
                serviciuAdaugat["data_inceput"] = dataInceputServiciu.Value.ToShortDateString();
                serviciuAdaugat["data_sfarsit"] = dataSfarsitServiciu.Value.ToShortDateString();
                serviciuAdaugat["valoare_lei"] = serviciuSelectat["valoare_lei"];
                serviciuAdaugat["total_lei"] = Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days) * nrBeneficiari.Value;

                if (dataSfarsitServiciu.Visible == false)
                {
                    serviciuAdaugat["total_lei"] = Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * nrBeneficiari.Value;
                    serviciuAdaugat["data_sfarsit"] = dataInceputServiciu.Value.ToShortDateString();
                }

                serviciiSelectate.Rows.Add(serviciuAdaugat);
                serviciiSelectate.AcceptChanges();

                dgvServicii.ClearSelection();
            }
        }

        DataRow serviciuSelectat;
        private void cbServicii_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbServicii.SelectedIndex!=-1)
            {
                serviciuSelectat = ds.Tables["Servicii"].Select("id_serviciu='" + Convert.ToInt32(cbServicii.SelectedValue.ToString()) + "'").FirstOrDefault();
                //MessageBox.Show(serviciuSelectat["tip"].ToString());
                nrBeneficiari.Value = nrOaspeti;
                if (serviciuSelectat["tip"].ToString() == "zilnic")
                {
                    dataInceputServiciu.Value = dataInceputCazare;
                    dataSfarsitServiciu.Value = dataSfarsitCazare;
                    dataInceputServiciu.Enabled = false;
                    dataSfarsitServiciu.Enabled = false;
                    dataSfarsitServiciu.Visible = true;
                    label6.Visible = true;
                    labelPretZilnic.Visible = true;
                    labelPretTotal.Text = "Pret total: " + ((Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days)) * nrBeneficiari.Value).ToString() + " lei";
                    labelPretTotal.Text += " (" + nrBeneficiari.Value.ToString() + " pers.)";
                    labelPretZilnic.Text = "Pret zilnic: " + serviciuSelectat["valoare_lei"].ToString() + " lei";
                    labelDataInceput.Text = "Data inceput:";
                    labelPretTotal.Location = new Point(18, 367);
                    labelNrBeneficiari.Location = new Point(18, 307);
                    nrBeneficiari.Location = new Point(210, 308);
                }
                else
                {
                    dataInceputServiciu.MinDate = dataInceputCazare;
                    dataInceputServiciu.MaxDate = dataSfarsitCazare;

                    dataInceputServiciu.Value = dataInceputCazare;
                    dataSfarsitServiciu.Value = dataInceputCazare;

                    dataInceputServiciu.Enabled = true;
                    dataSfarsitServiciu.Enabled = true;

                    dataSfarsitServiciu.Visible = false;
                    label6.Visible = false;
                    labelPretZilnic.Visible = false;
                    labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"])*nrBeneficiari.Value).ToString() + " lei";
                    labelPretTotal.Text += " (" + nrBeneficiari.Value.ToString() + " pers.)";
                    labelDataInceput.Text = "Data:";
                    labelPretTotal.Location = new Point(18, 275);
                    labelNrBeneficiari.Location = new Point(18, 215);
                    nrBeneficiari.Location = new Point(210, 215);
                }
            }
        }

        private void dataInceputServiciu_ValueChanged(object sender, EventArgs e)
        {
            dataSfarsitServiciu.MinDate = dataInceputServiciu.Value;
            dataSfarsitServiciu.MaxDate = dataSfarsitCazare;

            if (dataSfarsitServiciu.Visible == true)
                labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days + 1)).ToString() + " lei";
        }

        private void dataSfarsitServiciu_ValueChanged(object sender, EventArgs e)
        {
            if (dataSfarsitServiciu.Visible == true)
                labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days + 1)).ToString() + " lei";
        }

        private void btnStergeServiciu_Click(object sender, EventArgs e)
        {
            if (dgvServicii.Rows.Count > 0)
            {
                if (dgvServicii.CurrentCell.Selected == true)
                {
                    DataGridViewRow serviciuSelectat = dgvServicii.Rows[dgvServicii.CurrentCell.RowIndex];

                    DataRow serviciuDeSters = serviciiSelectate.Select("id_serviciu='" + serviciuSelectat.Cells["id_serviciu"].Value.ToString() + "'").FirstOrDefault();
                    serviciiSelectate.Rows.Remove(serviciuDeSters);
                    serviciiSelectate.AcceptChanges();
                    
                    dgvServicii.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Nu ati selectat un serviciu");
                }
            }
        }

        private void cbTipClient_SelectedValueChanged(object sender, EventArgs e)
        {

            cbCategorieClient.Items.Clear();
            cbCategorieClient.Items.Add("Niciuna");
            cbCategorieClient.SelectedIndex = 0;

            if (cbTipClient.Text == "Persoana juridica")
            {
                labelCI.Text = "CUI:";
                btnCautaClient.Text = "Cauta client dupa CUI";
                labelPrenume.Visible = false;
                tbPrenume.Visible = false;
                labelNume.Text = "Denumire:";
                labelNume.Location = new Point(543, 172);

                if (ds.Tables.Contains("CategoriiClienti"))
                {
                    foreach (DataRow categorieClient in ds.Tables["CategoriiClienti"].Rows)
                    {
                        if (categorieClient["categorie"].ToString() == "Persoana juridica")
                            cbCategorieClient.Items.Add(categorieClient["tip_client"].ToString());
                    }
                }

            }
            else if (cbTipClient.Text == "Persoana fizica")
            {
                labelCI.Text = "CNP:";
                btnCautaClient.Text = "Cauta client dupa CNP";
                labelPrenume.Visible = true;
                tbPrenume.Visible = true;
                labelNume.Text = "Nume:";
                labelNume.Location = new Point(588, 172);

                if (ds.Tables.Contains("CategoriiClienti"))
                { 
                    foreach (DataRow categorieClient in ds.Tables["CategoriiClienti"].Rows)
                    {
                        if (categorieClient["categorie"].ToString() == "Persoana fizica")
                            cbCategorieClient.Items.Add(categorieClient["tip_client"].ToString());
                    }
                }
            }
            //MessageBox.Show(ds.Tables["CategoriiClienti"].Rows.Count.ToString());
        }

        
        private void btnCautaClient_Click(object sender, EventArgs e)
        {
            if (cbTipClient.Text == "Persoana fizica")
                sqlcmd = "select clienti.id_client, persoane_fizice.nume, persoane_fizice.prenume, persoane_fizice.cnp, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_fizice on persoane_fizice.id_client=clienti.id_client where cnp='"+tbCI.Text+"'";
            else if (cbTipClient.Text == "Persoana juridica")
                sqlcmd = "select clienti.id_client, persoane_juridice.denumire, persoane_juridice.cui, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_juridice on persoane_juridice.id_client=clienti.id_client where cui='" + tbCI.Text + "'";
            DataTable clientGasit = new DataTable();
            try
            {
                con.Open();
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(clientGasit);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                con.Close();
            }

            if (clientGasit.Rows.Count > 0)
            {
                MessageBox.Show("Clientul a fost gasit! Se vor completa informatiile.");
                idClientGasit = clientGasit.Rows[0]["id_client"].ToString();
                if (cbTipClient.Text == "Persoana fizica")
                {
                    tbNume.Text = clientGasit.Rows[0]["nume"].ToString();
                    tbPrenume.Text = clientGasit.Rows[0]["prenume"].ToString();
                }

                else if (cbTipClient.Text == "Persoana juridica")
                {
                    tbNume.Text = clientGasit.Rows[0]["denumire"].ToString();
                }

                tbEmail.Text = clientGasit.Rows[0]["email"].ToString();
                tbTelefon.Text = clientGasit.Rows[0]["telefon"].ToString();
                tbCodPostal.Text = clientGasit.Rows[0]["cod_postal"].ToString();
                tbAdresa.Text = clientGasit.Rows[0]["adresa"].ToString();

                
                cbCategorieClient.Text = clientGasit.Rows[0]["tip_client"].ToString();

                tbNume.Enabled = false;
                tbPrenume.Enabled = false;
                tbEmail.Enabled = false;
                tbTelefon.Enabled = false;
                tbCodPostal.Enabled = false;
                tbAdresa.Enabled = false;
                cbCategorieClient.Enabled = false;
                tbCI.Enabled = false;
                cbTipClient.Enabled = false;

                btnStergeDate.Visible = true;
                btnCautaClient.Enabled = false;
            }
            else
            {
                MessageBox.Show("Clientul cu codul de identitate introdus nu exista in baza de date.");
            }
        }

        private void btnStergeDate_Click(object sender, EventArgs e)
        {
            idClientGasit = null;

            tbNume.Enabled = true;
            tbPrenume.Enabled = true;
            tbEmail.Enabled = true;
            tbTelefon.Enabled = true;
            tbCodPostal.Enabled = true;
            tbAdresa.Enabled = true;
            cbCategorieClient.Enabled = true;
            tbCI.Enabled = true;
            cbTipClient.Enabled = true;
            cbCategorieClient.SelectedIndex = 0;

            btnStergeDate.Visible = false;
            btnCautaClient.Enabled = true;

            tbNume.Clear();
            tbPrenume.Clear();
            tbEmail.Clear();
            tbTelefon.Clear();
            tbCodPostal.Clear();
            tbAdresa.Clear();
            tbCI.Clear();

            btnCautaClient.Visible = true;
        }

        private void btnConfirmaCazare_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd;
                if (idClientGasit == null)
                {
                    sqlcmd = "insert into clienti output inserted.id_client values ('"+tbEmail.Text+"', '"+
                        tbTelefon.Text+"', '"+tbAdresa.Text+"', '"+tbCodPostal.Text+"', '"+cbTipClient.Text+"')";
                    if (cbCategorieClient.Text == "Niciuna")
                        sqlcmd = "insert into clienti output inserted.id_client values ('" + tbEmail.Text +
                            "', '" + tbTelefon.Text + "', '" + tbAdresa.Text + "', '" + tbCodPostal.Text + "', '"+cbCategorieClient.Text+"')";
                    cmd = new SqlCommand(sqlcmd, con);

                    idClientGasit = Convert.ToString(cmd.ExecuteScalar());

                    if(cbTipClient.Text=="Persoana fizica")
                        sqlcmd ="insert into persoane_fizice values ('"+idClientGasit+"', '"+tbNume.Text+"', '"+
                            tbPrenume.Text+"', '"+tbCI.Text+"')";
                    else if(cbTipClient.Text == "Persoana juridica")
                        sqlcmd = "insert into persoane_juridice values ('" + idClientGasit + "', '" + tbNume.Text +
                            "', '" + tbCI.Text + "')";
                    cmd = new SqlCommand(sqlcmd, con);
                    cmd.ExecuteNonQuery();
                }

                sqlcmd = "insert into cazari output inserted.id_cazare values ('" + idClientGasit + "', '" +
                    dataInceputCazare + "', '" + dataSfarsitCazare + "', '" + cbModPlata.Text + "', '" +
                    totalLei.ToString() + "', '"+id_angajat+"', '"+nrOaspeti.ToString()+"')";
                cmd = new SqlCommand(sqlcmd, con);

                int idCazare = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (DataRow cameraSelectata in camereSelectate)
                {
                    sqlcmd = "insert into camere_cazari values('" + idCazare + "', '" +
                        cameraSelectata["id_camera"].ToString() + "')";
                    cmd = new SqlCommand(sqlcmd, con);
                    cmd.ExecuteNonQuery();
                }

                foreach (DataRow serviciuSelectat in serviciiSelectate.Rows)
                {
                    sqlcmd = "insert into servicii_cazari values('" + idCazare + "', '" +
                        serviciuSelectat["id_serviciu"].ToString() + "', '" + serviciuSelectat["data_inceput"].ToString() +
                        "', '" + serviciuSelectat["data_sfarsit"].ToString() + "', '"+serviciuSelectat["nr_beneficiari"].ToString()+"')";
                    cmd = new SqlCommand(sqlcmd, con);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Inserat!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dgvCamere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string categorieCameraSelectata = dgvCamere.Rows[e.RowIndex].Cells["categorie"].Value.ToString();

                labelReducereCameraSelectata.Visible = false;
                foreach (DataRow cameraCuReducere in ds.Tables["ReduceriCamere"].Rows)
                {
                    if (cameraCuReducere["denumire"].ToString() == categorieCameraSelectata)
                    {
                        labelReducereCameraSelectata.Text = "Camera selectata beneficiaza de o reducere de pret de "+cameraCuReducere["procent"].ToString()+"%.";
                        labelReducereCameraSelectata.Visible = true;
                        break;
                    }
                }
            }
        }

        private void cbCategoriiCamere_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCategoriiCamere.SelectedIndex != 0)
            {
                labelNrCamereDisponibile.Visible = true;
                labelNrCamereDisponibile.Text = "Se pot selecta maxim " + camereDisponibile[cbCategoriiCamere.Text] + " camere de tip " + cbCategoriiCamere.Text + ".";
            }
            else
                labelNrCamereDisponibile.Visible = false;
        }

        private void nrBeneficiari_ValueChanged(object sender, EventArgs e)
        {
            if (tipCazare == "fara rezervare")
            {
                labelPretTotal.Text = "Pret total: " + ((Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days)) * nrBeneficiari.Value).ToString() + " lei";
                if (dataSfarsitServiciu.Visible == false) //daca este serviciu ocazional
                    labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * nrBeneficiari.Value).ToString() + " lei"; //se scoate diferenta de zile pentru a nu fi inmultit cu 0
                labelPretTotal.Text += " (" + nrBeneficiari.Value.ToString() + " pers.)";
            }
        }
    }
}
