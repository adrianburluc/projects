using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.App
{
    public partial class GestiuneTarifeCamere : Form
    {
        public GestiuneTarifeCamere()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void GestiuneTarifeCamere_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            sqlcmd = "select id_categorie_camera as Id, cod_tarif, valoare_lei, data_inceput, data_sfarsit from tarife where id_serviciu is NULL";

            //sqlcmd = "select categorii_camere.Id, tarife.cod_tarif, tarife.valoare_lei, tarife.data_inceput, tarife.data_sfarsit from categorii_camere inner join tarife_categorii_camere on tarife_categorii_camere.id_categorie_camera=categorii_camere.Id inner join tarife on tarife_categorii_camere.cod_tarif=tarife.cod_tarif";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Tarife");

            sqlcmd = "select Id, denumire from categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "CategoriiCamere");

            sqlcmd = "select * from imagini_categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "ImaginiCategorii");

            con.Close();


            listBoxCategoriiCamere.DataSource = ds.Tables["CategoriiCamere"];
            listBoxCategoriiCamere.DisplayMember = "denumire";
            listBoxCategoriiCamere.ValueMember = "Id";

            dgvTarifeProgramate.DataSource = ds.Tables["Tarife"];
            dgvTarifeProgramate.Columns[0].Visible = false;
            dgvTarifeProgramate.Columns[1].Visible = false;
            dgvTarifeProgramate.Columns[2].ValueType = typeof(System.Int32);
            dgvTarifeProgramate.Columns["valoare_lei"].HeaderText = "Valoare lei";
            dgvTarifeProgramate.Columns["data_inceput"].HeaderText = "Data inceput";
            dgvTarifeProgramate.Columns["data_sfarsit"].HeaderText = "Data sfarsit";
            //dgvTarifeProgramate.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
            //dgvTarifeProgramate.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";

            dateFiltruDataSfarsit.Checked = false;
            dateFiltruDataSfarsit.MinDate = dateFiltruDataInceput.Value;

            tabControl1.SelectedTab = tabControl1.TabPages[1];
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            this.CenterToScreen();
        }

        private void buttonUpdateTarif_Click(object sender, EventArgs e)
        {
            
        }
        DataRow tarifCurent = null;
        DataRow tarifProgramat = null;
        string path = null;
        private void listBoxCategoriiCamere_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cand se selecteaza o camera, se vor returna tariful curent si tariful programat (daca exista)
            numericTarif.Value = 0;

            var viewTabelTarife = ds.Tables["Tarife"].DefaultView;
            viewTabelTarife.RowFilter = "Id=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString();
            viewTabelTarife.Sort = "data_sfarsit DESC";
            
            //returnare tarif curent
            tarifCurent = ds.Tables["Tarife"].Select("Id=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString() + " AND data_inceput<= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();
            
            labelCategorieCamera.Text = ((DataRowView)listBoxCategoriiCamere.SelectedItem)[1].ToString();

            dgvTarifeProgramate.ClearSelection();

            //returnare tarif programat
            tarifProgramat = ds.Tables["Tarife"].Select("Id=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString() + " AND data_inceput>= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();
            
            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 20));
            //MessageBox.Show(path + "\\ClassRepository\\imagini\\camere\\"+((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString()+"_0.*");

            DataRow imagineCategorie = ds.Tables["ImaginiCategorii"].Select("id_categorie=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString()).FirstOrDefault();

            if(imagineCategorie!=null)
                pictureCategorie.ImageLocation=path+imagineCategorie[1].ToString();
            else
                pictureCategorie.ImageLocation=path+"\\ClassRepository\\imagini\\camere\\default.jpg";

            /*if(tarifProgramat!=null && tarifCurent!=null)
                MessageBox.Show("tarif actual: " + tarifCurent["valoare_lei"].ToString());*/

            if (tarifCurent != null)
            {
                //labelTarif.Text = ((decimal)tarifCurent[2]).ToString("0.####") + " lei";
                labelTarif.Text = tarifCurent[2].ToString() + " lei";

                string data = ((DateTime)tarifCurent[4]).ToShortDateString();
                evidentiazaTarifActual();
            }
            else
            {
                labelTarif.Text = "-";
            }
        }

        private void buttonAplicaFiltru_Click(object sender, EventArgs e)
        {
                string testTime = "5/1/2021";
            DateTime date2 = DateTime.Parse(testTime);


            ds.Tables[0].DefaultView.RowFilter = "";
            string filtru = "Id='" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString() + "' AND data_sfarsit> '" + dateFiltruDataInceput.Value.ToShortDateString() + "'";

            if (dateFiltruDataSfarsit.Checked == true)
            {
                filtru = "Id='" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString() + "' AND (('" + dateFiltruDataInceput.Value.ToShortDateString() + "' >= data_inceput AND '" + dateFiltruDataInceput.Value.ToShortDateString() + "' < data_sfarsit) OR (data_inceput >= '" + dateFiltruDataInceput.Value.ToShortDateString() + "' AND data_inceput <= '" + dateFiltruDataSfarsit.Value.ToShortDateString() + "'))";
            }

            ds.Tables[0].DefaultView.RowFilter = filtru;
            ds.Tables[0].DefaultView.Sort = "data_sfarsit DESC";

            if(tarifCurent!=null)
                evidentiazaTarifActual();
        }

        private void evidentiazaTarifActual()
        {
            if (tarifCurent != null)
            {
                foreach (DataGridViewRow row2 in dgvTarifeProgramate.Rows)
                {
                    if (tarifCurent[1].ToString() == row2.Cells[1].Value.ToString())
                    {
                        row2.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    }
                }
            }
        }

        private void buttonResetFiltru_Click(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "Id=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString();
            ds.Tables[0].DefaultView.Sort = "data_sfarsit DESC";
            
            if (tarifCurent != null)
                evidentiazaTarifActual();
        }

        private void dgvTarifeProgramate_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (tarifCurent != null)
                evidentiazaTarifActual();
        }

        DataRow ultimulTarif=null;
        private void buttonSeteazaTarif_Click(object sender, EventArgs e)
        {
            if (numericTarif.Value == 0)
            {
                MessageBox.Show("Nu ati introdus un tarif!", "Setare tarif", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                //verifica daca are tarif
                //DataRow tarifCurent = ds.Tables["Tarife"].Select("Id=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString() + " AND data_inceput > '" + DateTime.Today.AddDays(+1).ToShortDateString() + "'").FirstOrDefault();

                //MessageBox.Show(DateTime.Today.AddDays(+1).ToShortDateString() + " " + DateTime.Today.AddDays(-1).ToShortDateString());

                //Algoritm pentru obtinerea noului cod_tarif:
                //1. se verifica daca exista tariful T_C1_
                //2. daca exista, se extrage id-ul ultimei inregistrari si se incrementeaza cu 1
                //3. daca nu, se introduce T_C1_1


                //daca are tarif programat, atunci e intrebat de update
                string idCategorie = ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString();
                ultimulTarif = ds.Tables["Tarife"].Select("cod_tarif Like '%T_C" + idCategorie + "_%'", "cod_tarif DESC").FirstOrDefault();
                decimal tarif = Convert.ToDecimal(numericTarif.Value);
                if (tarifProgramat == null)
                {
                    MessageBox.Show("Insert");

                    string codTarifNou;

                    if (ultimulTarif != null)
                    {
                        string ultimulCodTarif = ultimulTarif["cod_tarif"].ToString();
                        int idTarif = Convert.ToInt32(ultimulCodTarif.Substring(ultimulCodTarif.LastIndexOf('_') + 1)); //https://stackoverflow.com/a/3255737
                        codTarifNou = "T_C" + idCategorie + "_" + (idTarif + 1).ToString();
                    }
                    else
                    {
                        codTarifNou = "T_C" + idCategorie + "_1";
                    }

                    try
                    {
                        con.Open();
                        string data = DateTime.Now.AddDays(1).Date.ToString();
                        sqlcmd = "insert into tarife values('" + codTarifNou + "', '" + tarif + "', '" + data + "', '9/9/9999')";
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        sqlcmd = "insert into tarife_categorii_camere values('" + idCategorie + "','" + codTarifNou + "')";
                        cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        DataRow tarifNou = ds.Tables["Tarife"].NewRow();
                        tarifNou["Id"] = idCategorie;
                        tarifNou["cod_tarif"] = codTarifNou;
                        tarifNou["valoare_lei"] = tarif;
                        tarifNou["data_inceput"] = data;
                        tarifNou["data_sfarsit"] = "9/9/9999";

                        ds.Tables["Tarife"].Rows.Add(tarifNou);

                        tarifProgramat = ds.Tables["Tarife"].Select("Id=" + ((DataRowView)listBoxCategoriiCamere.SelectedItem)[0].ToString() + " AND data_inceput>= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();

                        if (ultimulTarif != null)//daca a mai avut tarife, se face update pe ultimul
                        {
                            sqlcmd = "update tarife set data_sfarsit='" + data + "' where cod_tarif='" + ultimulTarif["cod_tarif"] + "'";
                            cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            ultimulTarif["data_sfarsit"] = data;
                        }

                        ds.Tables["Tarife"].AcceptChanges();

                        //labelTarif.Text = numericTarif.Value.ToString();
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
                else
                {
                    try
                    {
                        con.Open();
                        sqlcmd = "update tarife set valoare_lei=" + tarif + " where cod_tarif='" + tarifProgramat["cod_tarif"].ToString() + "'";
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        tarifProgramat["valoare_lei"] = tarif;

                        ds.Tables["Tarife"].AcceptChanges();
                    }
                    catch(SqlException err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        con.Close();
                        MessageBox.Show("Actualizat!");
                    }
                }
                evidentiazaTarifActual();
                
            }
        }

        private void buttonStergeTarif_Click(object sender, EventArgs e)
        {
            if (tarifCurent == null)
            {
                MessageBox.Show("Nu exista niciun tarif programat pentru a putea fi sters!", "Stergere tarif programat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ultimulTarif["cod_tarif"].ToString() == tarifCurent["cod_tarif"].ToString()) //daca nu exista tarif programat
                {
                    MessageBox.Show("Nu exista niciun tarif programat pentru a putea fi sters!", "Stergere tarif programat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Doriti sa stergeti tariful programat maine?\n\nTarif: " + ultimulTarif["valoare_lei"].ToString() + " lei\nData inceput: " + ((DateTime)ultimulTarif["data_inceput"]).ToShortDateString(), "Stergere tarif programat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            sqlcmd = "delete from tarife_categorii_camere where cod_tarif='" + ultimulTarif["cod_tarif"].ToString() + "'";
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            sqlcmd = "delete from tarife where cod_tarif='" + ultimulTarif["cod_tarif"].ToString() + "'";
                            cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Sters!");

                            ultimulTarif.Delete();
                            ds.Tables["Tarife"].AcceptChanges();
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
                }
            }
        }

        private void dateFiltruDataInceput_ValueChanged(object sender, EventArgs e)
        {
            //deoarece data devine checked atunci cand se modifica valoarea din cod
            //se verifica daca a fost checked inainte de a apela metoda, pentru a restabili statusul
            //se seteaza limita max pentru data sfarsit -> data inceput

            bool endDateChecked = dateFiltruDataSfarsit.Checked;
            dateFiltruDataSfarsit.MinDate = dateFiltruDataInceput.Value;
            //dateFiltruDataSfarsit.Value = dateFiltruDataInceput.Value;
            
            if(endDateChecked==false)
                dateFiltruDataSfarsit.Checked = false;
        }
    }
}
