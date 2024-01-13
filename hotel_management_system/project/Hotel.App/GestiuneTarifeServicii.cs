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
    public partial class GestiuneTarifeServicii : Form
    {
        public GestiuneTarifeServicii()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void GestiuneTarifeServicii_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            sqlcmd = "select id_serviciu, cod_tarif, valoare_lei, data_inceput, data_sfarsit from tarife where id_categorie_camera is null";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Tarife");

            sqlcmd = "select id_serviciu, denumire, imagine from servicii";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Servicii");

            con.Close();

            listBoxServicii.DataSource = ds.Tables["Servicii"];
            listBoxServicii.DisplayMember = "denumire";
            listBoxServicii.ValueMember = "id_serviciu";

            dgvTarifeProgramate.DataSource = ds.Tables["Tarife"];
            dgvTarifeProgramate.Columns[0].Visible = false;
            dgvTarifeProgramate.Columns[1].Visible = false;
            dgvTarifeProgramate.Columns[2].ValueType = typeof(System.Int32);
            //dgvTarifeProgramate.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
            //dgvTarifeProgramate.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";

            dateFiltruDataSfarsit.Checked = false;
            dateFiltruDataSfarsit.MinDate = dateFiltruDataInceput.Value;

            tabControl1.SelectedTab = tabControl1.TabPages[1];
            tabControl1.SelectedTab = tabControl1.TabPages[0];

            this.CenterToScreen();
        }

        DataRow ultimulTarif = null;
        private void buttonSeteazaTarif_Click_1(object sender, EventArgs e)
        {
            if (numericTarif.Value == 0)
            {
                MessageBox.Show("Nu ati introdus un tarif!", "Setare tarif", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //verifica daca are tarif
                //DataRow tarifCurent = ds.Tables["Tarife"].Select("Id=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString() + " AND data_inceput > '" + DateTime.Today.AddDays(+1).ToShortDateString() + "'").FirstOrDefault();

                //MessageBox.Show(DateTime.Today.AddDays(+1).ToShortDateString() + " " + DateTime.Today.AddDays(-1).ToShortDateString());

                //Algoritm pentru obtinerea noului cod_tarif:
                //1. se verifica daca exista tariful T_C1_
                //2. daca exista, se extrage id-ul ultimei inregistrari si se incrementeaza cu 1
                //3. daca nu, se introduce T_C1_1

                //daca are tarif programat, atunci e intrebat de update
                string idServiciu = ((DataRowView)listBoxServicii.SelectedItem)[0].ToString();
                ultimulTarif = ds.Tables["Tarife"].Select("cod_tarif Like '%T_S" + idServiciu + "_%'", "cod_tarif DESC").FirstOrDefault();
                decimal tarif = Convert.ToDecimal(numericTarif.Value.ToString("#.00"));
                if (tarifProgramat == null)
                {
                    MessageBox.Show("Insert");
                    string codTarifNou;

                    if (ultimulTarif != null)
                    {
                        string ultimulCodTarif = ultimulTarif["cod_tarif"].ToString();
                        int idTarif = Convert.ToInt32(ultimulCodTarif.Substring(ultimulCodTarif.LastIndexOf('_') + 1)); //https://stackoverflow.com/a/3255737
                        codTarifNou = "T_S" + idServiciu + "_" + (idTarif + 1).ToString();
                    }
                    else
                    {
                        codTarifNou = "T_S" + idServiciu + "_1";
                    }

                    try
                    {
                        con.Open();
                        string data = DateTime.Now.AddDays(1).Date.ToString();
                        sqlcmd = "insert into tarife values('" + codTarifNou + "', '" + tarif + "', '" + data + "', '9/9/9999', NULL, '"+idServiciu+"')";
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        /*sqlcmd = "insert into tarife_servicii values('" + idServiciu + "','" + codTarifNou + "')";
                        cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();*/

                        DataRow tarifNou = ds.Tables["Tarife"].NewRow();
                        tarifNou["id_serviciu"] = idServiciu;
                        tarifNou["cod_tarif"] = codTarifNou;
                        tarifNou["valoare_lei"] = tarif;
                        tarifNou["data_inceput"] = data;
                        tarifNou["data_sfarsit"] = "9/9/9999";

                        ds.Tables["Tarife"].Rows.Add(tarifNou);

                        tarifProgramat = ds.Tables["Tarife"].Select("id_serviciu=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString() + " AND data_inceput>= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();

                        if (ultimulTarif != null)//daca a mai avut tarife, se face update pe ultimul
                        {
                            sqlcmd = "update tarife set data_sfarsit='" + data + "' where cod_tarif='" + ultimulTarif["cod_tarif"] + "'";
                            cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            ultimulTarif["data_sfarsit"] = data;
                        }

                        ds.Tables["Tarife"].AcceptChanges();

                        //labelTarif.Text = numericTarif.Value.ToString();

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        con.Close();
                        MessageBox.Show("Inserat!");
                    }
                }
                else //daca exista deja un tarif setat pentru maine, si se doreste modificarea sumei
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
                    catch (SqlException err)
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

        DataRow tarifCurent = null;
        DataRow tarifProgramat = null;
        string path = null;
        private void listBoxServicii_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cand se selecteaza o camera, se vor returna tariful curent si tariful programat (daca exista)
            numericTarif.Value = 0;

            var viewTabelTarife = ds.Tables["Tarife"].DefaultView;
            viewTabelTarife.RowFilter = "id_serviciu=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString();
            viewTabelTarife.Sort = "data_sfarsit DESC";

            //returnare tarif curent
            tarifCurent = ds.Tables["Tarife"].Select("id_serviciu=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString() + " AND data_inceput<= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();
            labelServiciu.Text = ((DataRowView)listBoxServicii.SelectedItem)[1].ToString();

            dgvTarifeProgramate.ClearSelection();

            //returnare tarif programat
            tarifProgramat = ds.Tables["Tarife"].Select("id_serviciu=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString() + " AND data_inceput>= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();

            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 20));
            //MessageBox.Show(path + "\\ClassRepository\\imagini\\camere\\"+((DataRowView)listBoxServicii.SelectedItem)[0].ToString()+"_0.*");

            DataRow imagineServiciu = ds.Tables["Servicii"].Select("id_serviciu=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString()).FirstOrDefault();
            
            if (imagineServiciu != null)
                pictureServiciu.ImageLocation = path + imagineServiciu[2].ToString();
            else
                pictureServiciu.ImageLocation = path + "\\ClassRepository\\imagini\\camere\\default.jpg";

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
            ds.Tables[0].DefaultView.RowFilter = "";
            string filtru = "id_serviciu='" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString() + "' AND data_sfarsit> '" + dateFiltruDataInceput.Value.ToShortDateString() + "'";

            if (dateFiltruDataSfarsit.Checked == true)
            {
                filtru = "id_serviciu='" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString() + "' AND (('" + dateFiltruDataInceput.Value.ToShortDateString() + "' >= data_inceput AND '" + dateFiltruDataInceput.Value.ToShortDateString() + "' < data_sfarsit) OR (data_inceput >= '" + dateFiltruDataInceput.Value.ToShortDateString() + "' AND data_inceput <= '" + dateFiltruDataSfarsit.Value.ToShortDateString() + "'))";
            }

            ds.Tables[0].DefaultView.RowFilter = filtru;
            ds.Tables[0].DefaultView.Sort = "data_sfarsit DESC";

            if (tarifCurent != null)
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
            ds.Tables[0].DefaultView.RowFilter = "id_serviciu=" + ((DataRowView)listBoxServicii.SelectedItem)[0].ToString();
            ds.Tables[0].DefaultView.Sort = "data_sfarsit DESC";

            if (tarifCurent != null)
                evidentiazaTarifActual();
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

        private void dgvTarifeProgramate_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (tarifCurent != null)
                evidentiazaTarifActual();
        }
    }
}
