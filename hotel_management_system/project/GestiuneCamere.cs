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
    public partial class GestiuneCamere : Form
    {
        public GestiuneCamere()
        {
            InitializeComponent();
        }

        //DE ADAUGAT: CAMERA POATE DEVENI INACTIVA DOAR DACA ESTE LIBERA.
        //DACA CLIENTUL PRELUNGESTE CAZAREA PENTRU CAMERA CARE URMA SA DEVINA INACTIVA?

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void GestiuneCamere_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
                
            try
            {
                con.Open();

                sqlcmd = "select id_camera, numar, id_categorie_camere, categorii_camere.denumire, etaj, nr_camere, camere.status from camere join categorii_camere on camere.id_categorie_camere=categorii_camere.Id";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "Camere");

                ds.Tables["Camere"].DefaultView.Sort = "numar asc";
                //ds.Tables["Camere"].DefaultView.RowFilter = "status <> 'indisponibil'";

                sqlcmd = "select Id, denumire from categorii_camere";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "CategoriiCamere");

                con.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                con.Close();
            }

            dgvCamere.DataSource = ds.Tables["Camere"];
            dgvCamere.Columns[0].Visible = false;
            dgvCamere.Columns[2].Visible = false;
            dgvCamere.Columns[1].HeaderText = "Camera";
            dgvCamere.Columns[3].HeaderText = "Categorie";
            dgvCamere.Columns[4].HeaderText = "Etaj";
            dgvCamere.Columns[5].HeaderText = "Nr. camere";
            dgvCamere.Columns[6].HeaderText = "Status";

            //https://stackoverflow.com/a/26006620
            cbCategorieCamere.ValueMember = "Id";
            cbCategorieCamere.DisplayMember = "denumire";
            cbCategorieCamere.DataSource = ds.Tables["CategoriiCamere"];

            if (cbCategorieCamere.Items.Count > 0)
            {
                cbCategorieCamere.SelectedIndex = 0;
            }

            dgvCamere.Sort(dgvCamere.Columns["numar"], ListSortDirection.Ascending);
            textBoxNumarCamera.Controls[0].Hide();

            this.CenterToScreen();
        }

        DataGridViewRow cameraSelectata=null;
        private void dgvCamere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int inregCurenta = dgvCamere.CurrentCell.RowIndex;
                cameraSelectata = dgvCamere.Rows[inregCurenta];

                textBoxNumarCamera.Text = cameraSelectata.Cells[1].Value.ToString();
                cbCategorieCamere.Text = cameraSelectata.Cells[3].Value.ToString();
                numericEtaj.Value = Convert.ToInt32(cameraSelectata.Cells[4].Value);
                numericNrCamere.Value = Convert.ToInt32(cameraSelectata.Cells[5].Value);

                if (cameraSelectata.Cells[6].Value.ToString() == "inactiv")
                {
                    checkBoxActiv.Checked = true;
                }
                else
                {
                    checkBoxActiv.Checked = false;
                }
            }
        }

        
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            /*
             * 1. verifica daca numarul camerei difera. daca da, va afisa un mesaj de atentionare explicativ
             * 2. verifica daca datele introduse exista deja - extrage un datarow
             * 2.1. daca contine 'activ' sau 'inactiv', inseamna ca camera exista deja si va afisa un mesaj de atentioare
             * 2.2. se verifica coloana status din datarow. daca contine 'istoric', se va modifica in activ iar camera selectata ...
             * ... va deveni istoric
             * 3. daca datele introduse nu se regasesc deloc, atunci se face update pe camera selectata cu status = 'istoric' ...
             * ... si se face insert cu datele introduse
            */

            if (cameraSelectata == null)
            {
                MessageBox.Show("Nu ati selectat o camera pentru a o putea modifica!", "Actualizare informatii camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //1. verifica daca numarul camerei difera. daca da, va afisa un mesaj de atentionare explicativ
                if (cameraSelectata.Cells["numar"].Value.ToString() != textBoxNumarCamera.Value.ToString()){
                    MessageBox.Show("Nu se poate modifica numarul camerelor!", "Actualizare informatii camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxNumarCamera.Value = Convert.ToInt32(cameraSelectata.Cells["numar"].Value);
                }
                else
                {
                    //2. verifica daca datele introduse exista deja
                    DataRow cameraGasita = ds.Tables["Camere"].Select("numar='" + textBoxNumarCamera.Value.ToString() + "' and denumire='" + cbCategorieCamere.Text + "' and etaj='" + numericEtaj.Value.ToString() + "' and nr_camere='"+numericNrCamere.Value.ToString()+"'").FirstOrDefault();

                    try
                    {
                        con.Open();

                        if (cameraGasita != null)
                        {
                            string statusSelectat = "activ";
                            if (checkBoxActiv.Checked)
                                statusSelectat = "inactiv";

                            if (cameraGasita["status"].ToString() != "indisponibil")
                            {
                                if (cameraGasita["status"].ToString() != statusSelectat)
                                {
                                    //se va face update pentru a actualiza statusul camerei
                                    sqlcmd = "update camere set status='" + statusSelectat + "' where id_camera='" + cameraGasita["id_camera"] + "'";
                                    SqlCommand cmd = new SqlCommand(sqlcmd, con);
                                    cmd.ExecuteNonQuery();

                                    cameraGasita["status"] = statusSelectat;
                                    
                                    ds.Tables["Camere"].AcceptChanges();

                                    dgvCamere.ClearSelection();
                                    cameraSelectata = null;

                                    MessageBox.Show("se va face update pentru a actualiza statusul camerei");
                                }
                                else
                                    MessageBox.Show("Camera exista deja");
                            }
                            else
                            {
                                //camera selectata devine indisponibila iar cea gasita devine activa
                                sqlcmd = "update camere set status='indisponibil' where id_camera='"+cameraSelectata.Cells["id_camera"].Value+"'";
                                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                                cmd.ExecuteNonQuery();

                                DataRow cameraSelectataDataRow = ds.Tables["Camere"].Select("id_camera='" + cameraSelectata.Cells["id_camera"].Value + "'").FirstOrDefault();
                                cameraSelectataDataRow["status"] = "indisponibil";

                                sqlcmd = "update camere set status='activ' where id_camera='" + cameraGasita["id_camera"] + "'";
                                cmd = new SqlCommand(sqlcmd, con);
                                cmd.ExecuteNonQuery();

                                cameraGasita["status"] = "activ";

                                ds.Tables["Camere"].AcceptChanges();

                                dgvCamere.ClearSelection();
                                cameraSelectata = null;

                                MessageBox.Show("camera selectata devine indisponibila iar cea gasita devine activa");
                            }

                        }

                        else
                        {
                            //Camera cu datele introduse nu exista. se face insert iar cea selectata devine indisponibila

                        }
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            /*if (cameraSelectata == null)
            {
                MessageBox.Show("Nu ati selectat o camera pentru a o putea modifica!", "Actualizare informatii camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string statusSelectat="activ";
                if (checkBoxActiv.Checked)
                    statusSelectat="inactiv";

                if (Convert.ToInt32(cameraSelectata.Cells[4].Value) == numericEtaj.Value && Convert.ToInt32(cameraSelectata.Cells[5].Value) == numericNrCamere.Value && cameraSelectata.Cells[6].Value.ToString()==statusSelectat)
                {
                    if (cameraSelectata.Cells[1].Value.ToString() != textBoxNumarCamera.Text)
                    {
                        MessageBox.Show("Nu se poate modifica numarul camerelor!", "Actualizare informatii camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxNumarCamera.Text = cameraSelectata.Cells[1].Value.ToString();
                    }
                    else if(cameraSelectata.Cells[3].Value.ToString()!=cbCategorieCamere.Text)
                    {
                        //algoritm pentru modificarea categoriei
                        try
                        {
                            con.Open();

                            sqlcmd = "update camere set status='indisponibil' where id_camera='" + cameraSelectata.Cells["id_camera"].Value + "'";
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow cameraUpdate = ds.Tables["Camere"].Select("id_camera='" + cameraSelectata.Cells["id_camera"].Value + "'").FirstOrDefault();
                            cameraUpdate["status"] = "indisponibil";

                            sqlcmd = "insert into camere  OUTPUT INSERTED.ID_Camera  values('" + textBoxNumarCamera.Text + "','" + cbCategorieCamere.SelectedValue + "', '" + numericEtaj.Value + "', '" + numericNrCamere.Value + "', 'activ')";
                            cmd = new SqlCommand(sqlcmd, con);
                            int idNou = Convert.ToInt32(cmd.ExecuteScalar());

                            DataRow cameraInserata = ds.Tables["Camere"].NewRow();
                            cameraInserata["id_camera"] = idNou;
                            cameraInserata["numar"] = textBoxNumarCamera.Text;
                            cameraInserata["id_categorie_camere"] = cbCategorieCamere.SelectedValue;
                            cameraInserata["denumire"] = cbCategorieCamere.Text;
                            cameraInserata["etaj"] = numericEtaj.Value;
                            cameraInserata["nr_camere"] = numericNrCamere.Value;
                            cameraInserata["status"] = "activ";

                            ds.Tables["Camere"].Rows.Add(cameraInserata);

                            ds.Tables["Camere"].AcceptChanges(); //https://stackoverflow.com/a/35182312

                            cameraSelectata = null;
                            dgvCamere.ClearSelection();

                            MessageBox.Show("Camera a fost modificata!", "Actualizare informatii camere", MessageBoxButtons.OK);
                        }
                        catch(Exception err)
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
                        MessageBox.Show("Nu ati modificat informatiile pentru a le putea actualiza!", "Actualizare informatii camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (cameraSelectata.Cells[1].Value.ToString() != textBoxNumarCamera.Text)
                    {
                        raspunsDialog = MessageBox.Show("ATENTIE! Nu se poate modifica numarul camerei!\n\nDoriti sa actualizati informatiile introduse FARA numarul / categoria camerei?", "Actualizare informatii camere", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        raspunsDialog = MessageBox.Show("Doriti sa actualizati informatiile camerei '" + cameraSelectata.Cells[1].Value.ToString() + "' cu cele introduse?", "Actualizare informatii camere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            //sqlcmd = "update categorii_camere set nr_oaspeti='" + numericNrPersoane.Value + "', dimensiune_mp='" + numericDimensiune.Value + "', descriere='" + textBoxDescriere.Text + "', status='" + checkBoxActiv.Text + "' where Id='" + cameraSelectata.Cells[0].Value + "'";
                            string status = "activ";
                            if (checkBoxActiv.Checked)
                                status = "inactiv";
                            sqlcmd = "update camere set etaj='" + numericEtaj.Value + "', nr_camere='" + numericNrCamere.Value + "', status='" + status + "' where id_camera='" + cameraSelectata.Cells["id_camera"].Value + "'";

                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow dr = ds.Tables["Camere"].Select("id_camera=" + cameraSelectata.Cells[0].Value).FirstOrDefault();
                            dr["etaj"] = numericEtaj.Value;
                            dr["nr_camere"] = numericNrCamere.Value;
                            dr["status"] = status;

                            ds.Tables["Camere"].AcceptChanges(); //https://stackoverflow.com/a/35182312

                            dgvCamere.ClearSelection();
                            cameraSelectata = null;
                            textBoxNumarCamera.Text = null;
                            cbCategorieCamere.SelectedIndex = -1;
                            numericEtaj.Value = 0;
                            numericNrCamere.Value = 1;

                            if (cameraCautata == true)
                            {
                                reseteazaRezultate();
                                cautaCamera(textBoxNrCameraCautata.Text);
                            }

                            MessageBox.Show("Informatii actualizate!", "Actualizare informatii camere");
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
            }*/
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            if (textBoxNumarCamera.Text == "" || cbCategorieCamere.SelectedIndex == -1 || numericEtaj.Value < 0 || numericNrCamere.Value < 1)
            {
                MessageBox.Show("Completati toate campurile pentru a putea inregistra camera!", "Inregistrare camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool numarGasit = false;
                    DataRow dr = ds.Tables["Camere"].Select("numar='" + textBoxNumarCamera.Text + "'").FirstOrDefault();
                    if (dr != null)
                    {
                        if (dr[1].ToString().ToLower() == textBoxNumarCamera.Text.ToLower())
                            numarGasit = true;
                    }

                    if (numarGasit == true)
                    {
                        MessageBox.Show("Numarul camerei exista deja!\n\nDaca doriti sa modificati informatiile folositi butonul 'Actualizare camera'.", "Inregistrare camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        /*if (checkBoxActiv.Checked == true)
                        {
                            MessageBox.Show("Debifati optiunea 'Status camera: inactiv' pentru a putea inregistra camera!\n\nCamerele inregistrate vor fi disponibile.\nStatusul poate fi modificat dupa inregistrare.", "Inregistrare camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            
                        }*/

                        raspunsDialog = MessageBox.Show("Doriti sa inregistrati urmatoarea camera?\n\nNumar camera: " + textBoxNumarCamera.Text + "\nCategorie: " + cbCategorieCamere.Text + "\nEtaj: " + numericEtaj.Value + "\nNumar camere: " + numericNrCamere.Value, "Inregistrare camere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (raspunsDialog == DialogResult.Yes)
                        {
                            try
                            {
                                sqlcmd = "insert into camere OUTPUT INSERTED.ID_Camera values('" + textBoxNumarCamera.Value + "', '" + cbCategorieCamere.SelectedValue + "', '" + numericEtaj.Value + "', '" + numericNrCamere.Value + "', 'activ')";

                                con.Open();
                                SqlCommand cmd = new SqlCommand(sqlcmd, con);

                                int idCamera = Convert.ToInt32(cmd.ExecuteScalar());
                                //cmd.ExecuteNonQuery();

                                DataRow row = ds.Tables["Camere"].NewRow();
                                row["id_camera"] = idCamera;
                                row["numar"] = textBoxNumarCamera.Value;
                                row["id_categorie_camere"] = cbCategorieCamere.SelectedValue;
                                row["denumire"] = cbCategorieCamere.Text;
                                row["etaj"] = numericEtaj.Value;
                                row["nr_camere"] = numericNrCamere.Value;
                                row["status"] = "activ";

                                ds.Tables["Camere"].Rows.Add(row);

                                ds.Tables["Camere"].AcceptChanges();


                                dgvCamere.ClearSelection();
                                cameraSelectata = null;

                                textBoxNumarCamera.Text = null;
                                cbCategorieCamere.SelectedIndex = -1;
                                numericEtaj.Value = 0;
                                numericNrCamere.Value = 1;

                                if (cameraCautata == true)
                                {
                                    reseteazaRezultate();
                                }

                                MessageBox.Show("Camera a fost adaugata!", "Inregistrare camere");
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

        bool cameraCautata = false;
        private void buttonCautareCamera_Click(object sender, EventArgs e)
        {

            if (textBoxNrCameraCautata.Text.Count() == 0)
            {
                reseteazaRezultate();
            }
            else
            {
                cautaCamera(textBoxNrCameraCautata.Text);
            }
        }

        private void buttonResetareRezutlate_Click(object sender, EventArgs e)
        {
            reseteazaRezultate();
        }

        public void reseteazaRezultate()
        {
            ds.Tables["Camere"].DefaultView.RowFilter = "status <> 'indisponibil'";
            dgvCamere.DataSource = ds.Tables["Camere"];
            dgvCamere.ClearSelection();
            cameraCautata = false;
            cameraSelectata = null;
        }

        public void cautaCamera(string numarCamera)
        {
            DataView dv = ds.Tables["Camere"].DefaultView;
            dv.RowFilter = string.Format("numar='{0}' and status <> 'indisponibil'", numarCamera);
            dgvCamere.DataSource = dv.ToTable();
            dgvCamere.ClearSelection();
            cameraCautata = true;
            cameraSelectata = null;
        }
    }
}
