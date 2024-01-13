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
    public partial class Rezervare : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        DateTime dataInceputSejur;
        DateTime dataSfarsitSejur;

        string idClientGasit;
        int nrOaspeti;
        int id_angajat;

        Dictionary<string, int> camereDisponibile;

        DataTable camereSelectate;
        DataTable serviciiSelectate;
        int nrCrt=0;

        public Rezervare(DateTime dataInceputSejur, DateTime dataSfarsitSejur, int nrOaspeti, int id_angajat)
        {
            this.dataInceputSejur = dataInceputSejur;
            this.dataSfarsitSejur = dataSfarsitSejur;
            this.nrOaspeti = nrOaspeti;
            this.id_angajat = id_angajat;
            MessageBox.Show(id_angajat + " id angajat");
            InitializeComponent();
            MessageBox.Show(nrOaspeti.ToString());
        }

        string tipRezervare;
        int idRezervare;
        string tipClient;
        public Rezervare(int idRezervare, DateTime dataInceputSejur, DateTime dataSfarsitSejur, int nrOaspeti, string tipRezervare, string tipClient)
        {
            this.dataInceputSejur = dataInceputSejur;
            this.dataSfarsitSejur = dataSfarsitSejur;
            this.nrOaspeti = nrOaspeti;
            this.tipRezervare = tipRezervare;
            this.idRezervare = idRezervare;
            this.tipClient = tipClient;
            InitializeComponent();
        }

        decimal tarifCamera;
        decimal totalLei;
        private void Rezervare_Load(object sender, EventArgs e)
        {
            labelHeaderPerioada.Text = dataInceputSejur.ToShortDateString() + " - " + dataSfarsitSejur.ToShortDateString();

            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";

            idClientGasit = null;

            DisponibilitateCamere evidentaCamere = new DisponibilitateCamere();
            camereDisponibile = evidentaCamere.disponibilitateCamere(dataInceputSejur, dataSfarsitSejur);

            camereSelectate = new DataTable();

            try
            {   
                con.Open();
                sqlcmd = "select nume + ' ' + prenume as nume from angajati where id_angajat='" + id_angajat + "'";
                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                string nume_angajat = (string)cmd.ExecuteScalar();
                labelNumeReceptioner.Text = nume_angajat;
                if (tipRezervare != "istoric")
                {
                    sqlcmd = "select tarife.id_categorie_camera, categorii_camere.denumire, nr_oaspeti as capacitate_oaspeti, valoare_lei from tarife join categorii_camere on categorii_camere.Id=tarife.id_categorie_camera where id_categorie_camera is not null and data_inceput < '" + dataInceputSejur + "' and data_sfarsit > '" + dataInceputSejur + "'";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "CategoriiCamere");

                    foreach (DataRow categorieCamera in ds.Tables["CategoriiCamere"].Rows)
                    {
                        cbCategoriiCamere.Items.Add(categorieCamera["denumire"].ToString());
                    }
                    cbCategoriiCamere.SelectedIndex = 0;
                }
                else
                {
                    sqlcmd = "select categorii_camere.denumire, numar_camere, categorii_camere.nr_oaspeti as capacitate_oaspeti, tarife.valoare_lei from camere_rezervate join categorii_camere on categorii_camere.Id=camere_rezervate.id_tip_camera join tarife on tarife.id_categorie_camera=camere_rezervate.id_tip_camera where tarife.data_inceput < '" + dataInceputSejur + "' and tarife.data_sfarsit > '" + dataInceputSejur + "' and id_rezervare='" + idRezervare + "'";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "CategoriiCamere");
                }

                //se extrag reducerile aferente camerelor din perioada selectata
                sqlcmd = "select categorii_camere.denumire, procent from reduceri join categorii_camere on categorii_camere.Id=reduceri.id_categorie_camera where id_categorie_camera is not null and data_inceput<='" + dataInceputSejur + "' and data_sfarsit>'" + dataInceputSejur + "'";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "ReduceriCamere");

                //se actualizeaza pretul daca exista reducere
                foreach (DataRow categorieCamera in ds.Tables["CategoriiCamere"].Rows)
                {
                    foreach(DataRow cameraCuReducere in ds.Tables["ReduceriCamere"].Rows)
                    {
                        if (cameraCuReducere["denumire"].ToString() == categorieCamera["denumire"].ToString())
                        {
                            categorieCamera["valoare_lei"] = (Convert.ToDecimal(categorieCamera["valoare_lei"]) * ((100 - Convert.ToDecimal(cameraCuReducere["procent"].ToString())) / 100)).ToString("0.00");

                        }
                    }
                }
                

                if (tipRezervare != "istoric")
                {
                    tarifCamera = Convert.ToDecimal(ds.Tables["CategoriiCamere"].Rows[0]["valoare_lei"]);
                    totalLei = Convert.ToDecimal((dataSfarsitSejur - dataInceputSejur).Days * Convert.ToDecimal(ds.Tables["CategoriiCamere"].Rows[0]["valoare_lei"]) * nrCamere.Value);

                    labelTarif.Text = tarifCamera.ToString() + " lei";
                    labelTotalLei.Text = totalLei.ToString("0.00") + " lei";

                    if (camereDisponibile[cbCategoriiCamere.Text] == 0)
                        nrCamere.Enabled = false;
                    else
                    {
                        /*int nrCamereSelectabile = camereDisponibile[cbCategoriiCamere.Text];
                        foreach (DataRow cameraAdaugata in camereSelectate.Rows)
                        {
                            if (cameraAdaugata["denumire"].ToString() == cbCategoriiCamere.Text)
                                nrCamereSelectabile = nrCamereSelectabile - Convert.ToInt32(cameraAdaugata["nr_camere"]);
                        }
                        nrCamere.Maximum = nrCamereSelectabile;*/
                        nrCamere.Maximum = camereDisponibile[cbCategoriiCamere.Text];
                    }

                    nrCamere.Maximum = 5;

                    camereSelectate.Columns.Add("nr_crt", typeof(Int32));
                    camereSelectate.Columns.Add("id_categorie", typeof(Int32));
                    camereSelectate.Columns.Add("categorie", typeof(string));
                    camereSelectate.Columns.Add("nr_camere", typeof(Int32));
                    camereSelectate.Columns.Add("capacitate_oaspeti", typeof(Int32));
                    camereSelectate.Columns.Add("valoare_lei", typeof(decimal));
                    camereSelectate.Columns.Add("total_lei", typeof(decimal));

                    dgvCategoriiCamere.DataSource = camereSelectate;

                    dgvCategoriiCamere.Columns["nr_crt"].Visible = false;
                    dgvCategoriiCamere.Columns["id_categorie"].Visible = false;
                    dgvCategoriiCamere.Columns["categorie"].HeaderText = "Camera";
                    dgvCategoriiCamere.Columns["nr_camere"].HeaderText = "Nr. camere";
                    dgvCategoriiCamere.Columns["capacitate_oaspeti"].HeaderText = "Capacitate oaspeti / camera";
                    dgvCategoriiCamere.Columns["valoare_lei"].HeaderText = "Pret lei camera / noapte";
                    dgvCategoriiCamere.Columns["total_lei"].HeaderText = "Total lei " + (dataSfarsitSejur - dataInceputSejur).Days.ToString() + " nopti";

                    //extrage toate sle cu tarif
                    sqlcmd = "select servicii.id_serviciu, denumire, tip, tarife.valoare_lei from servicii join tarife on tarife.id_serviciu = servicii.id_serviciu where status = 'activ' and '" + dataInceputSejur + "' >= tarife.data_inceput and '" + dataInceputSejur + "' < tarife.data_sfarsit";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "Servicii");

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
                }
                else
                {
                    sqlcmd = "select servicii.denumire, nr_beneficiari, servicii_rezervari.data_inceput, servicii_rezervari.data_sfarsit, tarife.valoare_lei from servicii_rezervari join servicii on servicii.id_serviciu=servicii_rezervari.id_serviciu join tarife on tarife.id_serviciu = servicii.id_serviciu where status = 'activ' and '" + dataInceputSejur + "' >= tarife.data_inceput and '" + dataInceputSejur + "' < tarife.data_sfarsit and id_rezervare='" + idRezervare + "'";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "Servicii");
                    MessageBox.Show(ds.Tables["Servicii"].Rows.Count.ToString());

                    ds.Tables["Servicii"].Columns.Add("total_lei", typeof(decimal));
                    dgvServicii.DataSource = ds.Tables["Servicii"];

                    ds.Tables["CategoriiCamere"].Columns.Add("total_lei", typeof(decimal));
                    dgvCategoriiCamere.DataSource = ds.Tables["CategoriiCamere"];

                    dgvCategoriiCamere.Columns["denumire"].HeaderText = "Camera";
                    dgvCategoriiCamere.Columns["numar_camere"].HeaderText = "Nr. camere";
                    dgvCategoriiCamere.Columns["capacitate_oaspeti"].HeaderText = "Capacitate oaspeti / camera";
                    dgvCategoriiCamere.Columns["valoare_lei"].HeaderText = "Pret lei camera / noapte";
                    dgvCategoriiCamere.Columns["total_lei"].HeaderText = "Total lei " + (dataSfarsitSejur - dataInceputSejur).Days.ToString() + " nopti";

                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    btnStergeCamera.Visible = false;

                    foreach (DataRow cameraSelectata in ds.Tables["CategoriiCamere"].Rows)
                    {
                        cameraSelectata["total_lei"] = Convert.ToDecimal(cameraSelectata["valoare_lei"]) * (dataSfarsitSejur - dataInceputSejur).Days * Convert.ToInt32(cameraSelectata["numar_camere"]);
                    }

                    int diferentaNopti;
                    foreach (DataRow serviciu in ds.Tables["Servicii"].Rows)
                    {
                        diferentaNopti = (Convert.ToDateTime(serviciu["data_sfarsit"]) - Convert.ToDateTime(serviciu["data_inceput"])).Days;
                        if (diferentaNopti == 0)
                            diferentaNopti = 1;
                        serviciu["total_lei"] = Convert.ToDecimal(serviciu["valoare_lei"]) * Convert.ToInt32(serviciu["nr_beneficiari"]) * diferentaNopti;
                    }
                    btnStergeServiciu.Visible = false;

                    if (tipClient == "Persoana fizica")
                        sqlcmd = "select persoane_fizice.nume, persoane_fizice.prenume, persoane_fizice.cnp as CI, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_fizice on persoane_fizice.id_client=clienti.id_client join rezervari on rezervari.id_client=clienti.id_client where id_rezervare='" + idRezervare + "'";
                    else
                        sqlcmd = "select persoane_juridice.denumire as nume, persoane_juridice.cui as CI, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_juridice on persoane_juridice.id_client=clienti.id_client join rezervari on rezervari.id_client=clienti.id_client where id_rezervare='" + idRezervare + "'";

                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "Client");

                    cbTipClient.Text = tipClient;
                    tbCI.Text = ds.Tables["Client"].Rows[0]["CI"].ToString();
                    tbNume.Text = ds.Tables["Client"].Rows[0]["nume"].ToString();
                    if (tipClient == "Persoana fizica")
                        tbPrenume.Text = ds.Tables["Client"].Rows[0]["prenume"].ToString();
                    else if (tipClient == "Persoana juridica")
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

                
                dgvServicii.Columns["denumire"].HeaderText = "Serviciu";
                dgvServicii.Columns["nr_beneficiari"].HeaderText = "Nr. beneficiari";
                dgvServicii.Columns["data_inceput"].HeaderText = "Data inceput";
                dgvServicii.Columns["data_sfarsit"].HeaderText = "Data sfarsit";
                dgvServicii.Columns["valoare_lei"].HeaderText = "Pret lei / zi";
                dgvServicii.Columns["total_lei"].HeaderText = "Total lei";

                cbTipClient.SelectedIndex = 0;

                sqlcmd = "select procent, tip_client from reduceri where id_categorie_camera is null and data_inceput <= '" + dataInceputSejur + "' and data_sfarsit > '" + dataInceputSejur + "'";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "ReduceriClienti");

                sqlcmd = "select tip_client, categorie from categorii_clienti";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "CategoriiClienti");

                cbCategorieClient.SelectedIndex = 0;

                //MessageBox.Show(ds.Tables["CategoriiClienti"].Rows.Count.ToString());

                cbCategorieClient.Items.Clear();
                cbCategorieClient.Items.Add("Niciuna");
                cbCategorieClient.SelectedIndex = 0;
                foreach (DataRow categorieClient in ds.Tables["CategoriiClienti"].Rows)
                {
                    if (categorieClient["categorie"].ToString() == "Persoana fizica")
                        cbCategorieClient.Items.Add(categorieClient["tip_client"].ToString());
                }

                nrBeneficiari.Value = nrOaspeti;
                nrBeneficiari.Maximum = nrOaspeti;
                nrBeneficiari.Minimum = 1;

                labelNrOaspeti.Text = nrOaspeti.ToString();
                this.CenterToScreen();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message+" "+err.StackTrace);
            }
            finally
            {
                con.Close();
            }
        }

        int pageIndex = 1;
        private void btnInainte_Click(object sender, EventArgs e)
        {
            if (pageIndex == 1)
            {
                /*if (camereSelectate.Rows.Count > 0)
                    pageIndex++;
                else
                    MessageBox.Show("Nu ati selectat o camera");*/

                if (tipRezervare != "istoric")
                {
                    int totalLocuriSelectate = 0;
                    foreach (DataRow cameraSelectata in camereSelectate.Rows)
                    {
                        totalLocuriSelectate = totalLocuriSelectate + (Convert.ToInt32(cameraSelectata["nr_camere"]) * Convert.ToInt32(cameraSelectata["capacitate_oaspeti"]));
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
                if (tipRezervare != "istoric")
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
                else
                    pageIndex++;
            }
            else
                pageIndex++;

            switch (pageIndex)
            {
                case 2:
                    panel1.Visible = false;
                    panel2.Visible = true;
                    btnInapoi.Visible = true;
                    break;
                case 3:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    break;
                case 4:
                    panel3.Visible = false;
                    panel4.Visible = true;
                    btnInainte.Visible = false;
                    btnConfirmaRezervare.Visible = true;

                    labelNumeClient.Text = tbNume.Text;
                    if (cbTipClient.Text == "Persoana fizica")
                        labelNumeClient.Text = labelNumeClient.Text + " " + tbPrenume.Text;
                    labelPerioadaCazare.Text = dataInceputSejur.ToShortDateString() + " - " + dataSfarsitSejur.ToShortDateString();
                    //camereSelectate = ds.Tables["Camere"].Select("selectat='true'");
                    int nrCamereSelectate=0;
                    foreach (DataRow cameraSelectata in camereSelectate.Rows)
                    {
                        nrCamereSelectate = nrCamereSelectate + Convert.ToInt32(cameraSelectata["nr_camere"]);
                    }
                    if (tipRezervare != "istoric")
                    {
                        labelNrCamereSelectate.Text = nrCamereSelectate.ToString();
                        labelNrServiciiSelectate.Text = serviciiSelectate.Rows.Count.ToString();
                        totalLei = 0;
                        foreach (DataRow cameraAdaugata in camereSelectate.Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(cameraAdaugata["total_lei"]);
                        }
                        foreach (DataRow serviciuAdaugat in serviciiSelectate.Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(serviciuAdaugat["total_lei"]);
                        }
                    }
                    else
                    {
                        int totalCamereSelectate=0;
                        foreach (DataGridViewRow dgvRow in dgvCategoriiCamere.Rows)
                        {
                            totalCamereSelectate = totalCamereSelectate + Convert.ToInt32(dgvRow.Cells["numar_camere"].Value);
                        }
                        labelNrCamereSelectate.Text = totalCamereSelectate.ToString();
                        labelNrServiciiSelectate.Text = dgvServicii.Rows.Count.ToString();
                        totalLei = 0;
                        foreach (DataRow cameraAdaugata in ds.Tables["CategoriiCamere"].Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(cameraAdaugata["total_lei"]);
                        }
                        foreach (DataRow serviciuAdaugat in ds.Tables["Servicii"].Rows)
                        {
                            totalLei = totalLei + Convert.ToInt32(serviciuAdaugat["total_lei"]);
                        }
                        btnConfirmaRezervare.Visible = false;
                    }

                    labelTotalDeAchitat.Text = totalLei.ToString("0.00") + " lei";

                    foreach (DataRow reducere in ds.Tables["ReduceriClienti"].Rows)
                    {
                        if (reducere["tip_client"].ToString() == cbCategorieClient.Text)
                        {
                            totalLei = totalLei * ((100 - Convert.ToDecimal(reducere["procent"])) / 100);
                            labelTotalDeAchitat.Text = totalLei.ToString("0.00") + " lei (reducere " + reducere["procent"].ToString() + "% " + cbCategorieClient.Text + ")";
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
                    panel1.Visible = true;
                    panel2.Visible = false;
                    btnInapoi.Visible = false;
                    break;
                case 2:
                    panel2.Visible = true;
                    panel3.Visible = false;
                    break;
                case 3:
                    panel3.Visible = true;
                    panel4.Visible = false;
                    btnInainte.Visible = true;
                    btnConfirmaRezervare.Visible = false;
                    break;
            }
        }

        private void cbCategoriiCamere_SelectedValueChanged(object sender, EventArgs e)
        {
            tarifCamera = Convert.ToDecimal(ds.Tables["CategoriiCamere"].Rows[cbCategoriiCamere.SelectedIndex]["valoare_lei"]);
            totalLei = Convert.ToDecimal((dataSfarsitSejur - dataInceputSejur).Days * Convert.ToDecimal(ds.Tables["CategoriiCamere"].Rows[cbCategoriiCamere.SelectedIndex]["valoare_lei"])*nrCamere.Value);

            labelTarif.Text = tarifCamera.ToString() + " lei";
            labelTotalLei.Text = totalLei.ToString("0.00") + " lei";
            labelLimitaOaspeti.Text = ds.Tables["CategoriiCamere"].Rows[cbCategoriiCamere.SelectedIndex]["capacitate_oaspeti"].ToString();

            nrCamere.Value = 0;

            if (camereDisponibile[cbCategoriiCamere.Text] == 0)
                nrCamere.Enabled = false;
            else
            {
                actualizeazaLimitaNrCamereDisponibile();
            }
        }

        private void btnAdaugaCamera_Click(object sender, EventArgs e)
        {
            if(nrCamere.Value>0)
            {
                //verifica daca exista deja camera introdusa, pentru a modifica numarul
                bool cameraGasita = false;
                foreach (DataRow cameraAdaugata in camereSelectate.Rows)
                {
                    if(cameraAdaugata["categorie"].ToString()==cbCategoriiCamere.Text)
                    {
                        cameraGasita = true;
                        cameraAdaugata["total_lei"] = Convert.ToDecimal(cameraAdaugata["total_lei"]) + totalLei;
                        cameraAdaugata["nr_camere"] = Convert.ToInt32(cameraAdaugata["nr_camere"]) + nrCamere.Value;
                    }
                }

                if (cameraGasita==false)
                {
                    DataRow cameraSelectata = camereSelectate.NewRow();
                    foreach (DataRow categorieCamera in ds.Tables["CategoriiCamere"].Rows)
                    {
                        if (categorieCamera["denumire"].ToString() == cbCategoriiCamere.Text)
                        {
                            cameraSelectata["id_categorie"] = Convert.ToInt32(categorieCamera["id_categorie_camera"]);
                            break;
                        }
                    }
                    cameraSelectata["nr_crt"] = nrCrt++;
                    cameraSelectata["categorie"] = cbCategoriiCamere.Text;
                    cameraSelectata["nr_camere"] = nrCamere.Value;
                    cameraSelectata["valoare_lei"] = tarifCamera;
                    cameraSelectata["total_lei"] = totalLei;
                    cameraSelectata["capacitate_oaspeti"] = Convert.ToInt32(labelLimitaOaspeti.Text);
                    camereSelectate.Rows.Add(cameraSelectata);
                }

                camereSelectate.AcceptChanges();

                actualizeazaLimitaNrCamereDisponibile();
                dgvCategoriiCamere.ClearSelection();
            }
            else
            {
                MessageBox.Show("Nu ati selectat numarul de camere");
            }
        }
        public void actualizeazaLimitaNrCamereDisponibile()
        {
            int nrCamereSelectabile = camereDisponibile[cbCategoriiCamere.Text];
            foreach (DataRow cameraSelectata in camereSelectate.Rows)
            {
                if (cameraSelectata["categorie"].ToString() == cbCategoriiCamere.Text)
                    nrCamereSelectabile = nrCamereSelectabile - Convert.ToInt32(cameraSelectata["nr_camere"]);
            }
            nrCamere.Maximum = nrCamereSelectabile;
            nrCamere.Value = 0;
        }

        private void btnStergeCamera_Click(object sender, EventArgs e)
        {
            if (dgvCategoriiCamere.Rows.Count > 0)
            {
                if (dgvCategoriiCamere.CurrentCell.Selected == true)
                {
                    DataGridViewRow cameraSelectata = dgvCategoriiCamere.Rows[dgvCategoriiCamere.CurrentCell.RowIndex];

                    DataRow cameraDeSters = camereSelectate.Select("nr_crt='" + cameraSelectata.Cells["nr_crt"].Value.ToString() + "'").FirstOrDefault();
                    camereSelectate.Rows.Remove(cameraDeSters);
                    camereSelectate.AcceptChanges();

                    actualizeazaLimitaNrCamereDisponibile();
                }
            }
            else
            {
                MessageBox.Show("Nu ati selectat o camera");
            }
        }

        private void btnAdaugaServiciu_Click(object sender, EventArgs e)
        {
            DataRow serviciuGasit = serviciiSelectate.Select("denumire='" + cbServicii.Text + "' and data_inceput='" + dataInceputServiciu.Value.ToShortDateString() + "'").FirstOrDefault();
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
            if (cbServicii.SelectedIndex != -1)
            {
                if (tipRezervare != "istoric")
                {
                    serviciuSelectat = ds.Tables["Servicii"].Select("id_serviciu='" + Convert.ToInt32(cbServicii.SelectedValue.ToString()) + "'").FirstOrDefault();
                    //MessageBox.Show(serviciuSelectat["tip"].ToString());
                    nrBeneficiari.Value = nrOaspeti;
                    if (serviciuSelectat["tip"].ToString() == "zilnic")
                    {
                        dataInceputServiciu.Value = dataInceputSejur;
                        dataSfarsitServiciu.Value = dataSfarsitSejur;
                        dataInceputServiciu.Enabled = false;
                        dataSfarsitServiciu.Enabled = false;
                        dataSfarsitServiciu.Visible = true;
                        label6.Visible = true;
                        labelPretZilnic.Visible = true;
                        labelPretTotal.Text = "Pret total: " + ((Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days)) * nrBeneficiari.Value).ToString() + " lei";
                        labelPretTotal.Text += " (" + nrBeneficiari.Value.ToString() + " pers.)";
                        labelPretZilnic.Text = "Pret zilnic: " + serviciuSelectat["valoare_lei"].ToString() + " lei";
                        labelDataInceput.Text = "Data inceput:";
                        labelPretTotal.Location = new Point(18, 408);
                        labelNrBeneficiari.Location = new Point(18, 307);
                        nrBeneficiari.Location = new Point(210, 308);
                    }
                    else
                    {
                        dataInceputServiciu.MinDate = dataInceputSejur;
                        dataInceputServiciu.MaxDate = dataSfarsitSejur;

                        dataInceputServiciu.Value = dataInceputSejur;
                        dataSfarsitServiciu.Value = dataInceputSejur;

                        dataInceputServiciu.Enabled = true;
                        dataSfarsitServiciu.Enabled = true;

                        dataSfarsitServiciu.Visible = false;
                        label6.Visible = false;
                        labelPretZilnic.Visible = false;
                        labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * nrBeneficiari.Value).ToString() + " lei";
                        labelPretTotal.Text += " (" + nrBeneficiari.Value.ToString() + " pers.)";
                        labelDataInceput.Text = "Data:";
                        labelPretTotal.Location = new Point(18, 275);
                        labelNrBeneficiari.Location = new Point(18, 215);
                        nrBeneficiari.Location = new Point(210, 215);
                    }
                }
            }

            /*if (cbServicii.SelectedIndex != -1)
            {
                serviciuSelectat = ds.Tables["Servicii"].Select("id_serviciu='" + Convert.ToInt32(cbServicii.SelectedValue.ToString()) + "'").FirstOrDefault();
                if (serviciuSelectat["tip"].ToString() == "zilnic")
                {
                    dataInceputServiciu.Value = dataInceputSejur;
                    dataSfarsitServiciu.Value = dataSfarsitSejur;
                    dataInceputServiciu.Enabled = false;
                    dataSfarsitServiciu.Enabled = false;
                }
                else
                {
                    dataInceputServiciu.MinDate = dataInceputSejur;
                    dataInceputServiciu.MaxDate = dataSfarsitSejur;

                    dataInceputServiciu.Value = dataInceputSejur;
                    dataSfarsitServiciu.Value = dataInceputSejur;

                    dataInceputServiciu.Enabled = true;
                    dataSfarsitServiciu.Enabled = true;
                }
                labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days + 1)).ToString() + " lei";
                labelPretZilnic.Text = "Pret zilnic: " + serviciuSelectat["valoare_lei"].ToString() + " lei";
            }*/
        }

        private void dataInceputServiciu_ValueChanged(object sender, EventArgs e)
        {
            dataSfarsitServiciu.MinDate = dataInceputServiciu.Value;
            dataSfarsitServiciu.MaxDate = dataSfarsitSejur;

            labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days + 1)).ToString() + " lei";
        }

        private void dataSfarsitServiciu_ValueChanged(object sender, EventArgs e)
        {
            labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days + 1)).ToString() + " lei";
        }

        private void nrCamere_ValueChanged(object sender, EventArgs e)
        {
            totalLei = Convert.ToDecimal((dataSfarsitSejur - dataInceputSejur).Days * Convert.ToDecimal(ds.Tables["CategoriiCamere"].Rows[cbCategoriiCamere.SelectedIndex]["valoare_lei"])*nrCamere.Value);

            labelTotalLei.Text = totalLei.ToString("0.00") + " lei";
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
        }

        private void btnCautaClient_Click(object sender, EventArgs e)
        {
            if (cbTipClient.Text == "Persoana fizica")
                sqlcmd = "select clienti.id_client, persoane_fizice.nume, persoane_fizice.prenume, persoane_fizice.cnp, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_fizice on persoane_fizice.id_client=clienti.id_client where cnp='" + tbCI.Text + "'";
            else if (cbTipClient.Text == "Persoana juridica")
                sqlcmd = "select clienti.id_client, persoane_juridice.denumire, persoane_juridice.cui, email, telefon, adresa, cod_postal, tip_client from clienti join persoane_juridice on persoane_juridice.id_client=clienti.id_client where cui='" + tbCI.Text + "'";
            DataTable clientGasit = new DataTable();
            try
            {
                con.Open();
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(clientGasit);
            }
            catch (Exception err)
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
        }

        private void btnConfirmaRezervare_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd;
                if (idClientGasit == null)
                {
                    sqlcmd = "insert into clienti output inserted.id_client values ('" + tbEmail.Text + "', '" + tbTelefon.Text + "', '" + tbAdresa.Text + "', '" + tbCodPostal.Text + "', '" + cbTipClient.Text + "')";
                    if (cbCategorieClient.Text == "Niciuna")
                        sqlcmd = "insert into clienti output inserted.id_client values ('" + tbEmail.Text + "', '" + tbTelefon.Text + "', '" + tbAdresa.Text + "', '" + tbCodPostal.Text + "', NULL)";
                    cmd = new SqlCommand(sqlcmd, con);

                    idClientGasit = Convert.ToString(cmd.ExecuteScalar());

                    if (cbTipClient.Text == "Persoana fizica")
                        sqlcmd = "insert into persoane_fizice values ('" + idClientGasit + "', '" + tbNume.Text + "', '" + tbPrenume.Text + "', '" + tbCI.Text + "')";
                    else if (cbTipClient.Text == "Persoana juridica")
                        sqlcmd = "insert into persoane_juridice values ('" + idClientGasit + "', '" + tbNume.Text + "', '" + tbCI.Text + "')";
                    cmd = new SqlCommand(sqlcmd, con);
                    cmd.ExecuteNonQuery();
                }

                //MessageBox.Show("Se face insert in rezervari\n\nClient id: "+idClientGasit.ToString()+"\n");
                sqlcmd = "insert into rezervari output inserted.id_rezervare values ('"+idClientGasit+"', NULL, '"+DateTime.Now+"', '"+dataInceputSejur+"', '"+dataSfarsitSejur+"', '1','"+nrOaspeti.ToString()+"')";
                cmd = new SqlCommand(sqlcmd, con);

                int idRezervare = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show("Se face insert in camere_rezervari "+camereSelectate.Rows.Count.ToString());
                
                foreach (DataRow cameraSelectata in camereSelectate.Rows)
                {
                    MessageBox.Show("test");
                    MessageBox.Show("Numar camere: " + cameraSelectata["id_categorie"].ToString());
                    MessageBox.Show("id rezervare: " + idRezervare);
                    MessageBox.Show("Numar camere: " + cameraSelectata["nr_camere"].ToString());
                    sqlcmd = "insert into camere_rezervate values('" + cameraSelectata["id_categorie"].ToString() + "', '" + idRezervare + "', '"+cameraSelectata["nr_camere"].ToString()+"')";
                    cmd = new SqlCommand(sqlcmd, con);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Se face insert in servicii");
                foreach (DataRow serviciuSelectat in serviciiSelectate.Rows)
                {
                    sqlcmd = "insert into servicii_rezervari values('" + idRezervare + "', '" + serviciuSelectat["id_serviciu"].ToString() + "', '" + serviciuSelectat["data_inceput"].ToString() + "', '" + serviciuSelectat["data_sfarsit"].ToString() + "', '" + serviciuSelectat["nr_beneficiari"].ToString() + "')";
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

        private void nrBeneficiari_ValueChanged(object sender, EventArgs e)
        {
            if (tipRezervare != "istoric")
            {
                labelPretTotal.Text = "Pret total: " + ((Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * ((dataSfarsitServiciu.Value - dataInceputServiciu.Value).Days)) * nrBeneficiari.Value).ToString() + " lei";
                if (dataSfarsitServiciu.Visible == false) //daca este serviciu ocazional
                    labelPretTotal.Text = "Pret total: " + (Convert.ToDecimal(serviciuSelectat["valoare_lei"]) * nrBeneficiari.Value).ToString() + " lei"; //se scoate diferenta de zile pentru a nu fi inmultit cu 0
                labelPretTotal.Text += " (" + nrBeneficiari.Value.ToString() + " pers.)";
            }
        }
    }
}
