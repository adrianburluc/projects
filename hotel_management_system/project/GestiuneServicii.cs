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
using System.IO;

namespace Hotel.App
{
    public partial class GestiuneServicii : Form
    {
        public GestiuneServicii()
        {
            InitializeComponent();
        }
        
        //TODO
        //cand apas pe header > clearselection
        //de rezolvat la update, in caz ca se schimba denumirea atunci se deselecteaza serviciul


        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;
        string path;

        private void GestiuneServicii_Load(object sender, EventArgs e)
        {
            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 20));

            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";

            con.Open();
            sqlcmd = "select id_serviciu, denumire, tip, imagine, descriere, status from servicii";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Servicii");
            con.Close();

            

            dgvServicii.DataSource = ds.Tables["Servicii"];
            dgvServicii.Columns[0].Visible = false;
            dgvServicii.Columns[1].HeaderText = "Denumire";
            dgvServicii.Columns[2].HeaderText = "Tip";
            dgvServicii.Columns[3].Visible = false;
            dgvServicii.Columns[4].HeaderText = "Descriere";
            dgvServicii.Columns[5].HeaderText = "Status";
            
            //dgvServicii.Sort(dgvServicii.Columns["denumire"], ListSortDirection.Ascending);

            //pentru a deselecta optiunea selectata
            tabControlDescriere.SelectedTab = tabControlDescriere.TabPages[1];
            tabControlDescriere.SelectedTab = tabControlDescriere.TabPages[0];
            dgvServicii.ClearSelection();

            cbTipServiciu.SelectedIndex = 0;
            this.CenterToScreen();
        }
        
            
        DataGridViewRow serviciuSelectat = null;
        int inregCurenta=-1;
        private void dgvServicii_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                inregCurenta = dgvServicii.CurrentCell.RowIndex;
                serviciuSelectat = dgvServicii.Rows[inregCurenta];

                textBoxDenumire.Text = serviciuSelectat.Cells[1].Value.ToString();
                cbTipServiciu.Text = serviciuSelectat.Cells[2].Value.ToString();
                textBoxDescriere.Text = serviciuSelectat.Cells[4].Value.ToString();


                if (serviciuSelectat.Cells[5].Value.ToString() == "inactiv")
                {
                    checkBoxActiv.Checked = true;
                }
                else
                {
                    checkBoxActiv.Checked = false;
                }

                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 20));
                pictureBoxImagine.ImageLocation = path+serviciuSelectat.Cells[3].Value.ToString();
            }
        }

        private void btnAdaugaServiciu_Click(object sender, EventArgs e)
        {
            if(textBoxDenumire.Text == "" || textBoxDescriere.Text == "")
            {
                MessageBox.Show("Completati toate campurile pentru a putea inregistra serviciul!", "Inregistrare servicii", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool denumireGasita = false;
                DataRow dr5 = ds.Tables["Servicii"].Select("denumire='" + textBoxDenumire.Text + "'").FirstOrDefault();
                if (dr5 != null)
                {
                    if (dr5[1].ToString().ToLower() == textBoxDenumire.Text.ToLower())
                        denumireGasita = true;
                }

                if (denumireGasita == true)
                {
                    MessageBox.Show("Denumirea serviciului exista deja!", "Inregistrare servicii", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (checkBoxActiv.Checked == false)
                    {
                        MessageBox.Show("Bifati optiunea 'Status categorie: inactiv' pentru a putea inregistra categoria!", "Inregistrare servicii", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        raspunsDialog = MessageBox.Show("ATENTIE! Serviciul va putea fi activ doar daca are tarif!\n\nDoriti sa inregistrati urmatorul serviciu?\n\nDenumire: "+textBoxDenumire.Text+"\nTip: "+cbTipServiciu.Text+"\nDescriere: "+textBoxDescriere.Text+"", "Inregistrare categorie camere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (raspunsDialog == DialogResult.Yes)
                        {
                            try
                            {
                                int idRandNou = 0;
                                if (ds.Tables["Servicii"].Rows.Count > 0)
                                    idRandNou = Convert.ToInt32(ds.Tables["Servicii"].Rows[ds.Tables["Servicii"].Rows.Count - 1][0]) + 1; //https://stackoverflow.com/a/13816531
                                else
                                    idRandNou = 1;

                                sqlcmd = "insert into servicii (id_serviciu, denumire, tip, imagine, descriere, status) values('"+idRandNou+"','"+textBoxDenumire.Text+"','"+cbTipServiciu.Text+"','\\ClassRepository\\imagini\\servicii\\default.jpg','"+textBoxDescriere.Text+"','inactiv')";

                                con.Open();
                                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                                cmd.ExecuteNonQuery();

                                DataRow row = ds.Tables["Servicii"].NewRow();
                                row["id_serviciu"] = idRandNou;
                                row["denumire"] = textBoxDenumire.Text;
                                row["tip"] = cbTipServiciu.Text;
                                row["imagine"] = "\\ClassRepository\\imagini\\servicii\\default.jpg";
                                row["descriere"] = textBoxDescriere.Text;
                                row["status"] = "inactiv";

                                ds.Tables["Servicii"].Rows.Add(row);

                                ds.Tables["Servicii"].AcceptChanges(); //https://stackoverflow.com/a/35182312


                                //se selecteaza serviciul adaugat
                                DataRow inregCautata = ds.Tables["Servicii"].Select("denumire='" + textBoxDenumire.Text + "'").FirstOrDefault();
                                if (inregCautata != null)
                                {
                                    inregCurenta=Convert.ToInt32(inregCautata[0].ToString())-1;
                                    dgvServicii.Rows[inregCurenta].Selected = true;
                                    serviciuSelectat = dgvServicii.Rows[inregCurenta];
                                }

                                //dgvServicii.ClearSelection();
                                //serviciuSelectat = null;
                                MessageBox.Show("Serviciul a fost adaugat!", "Inregistrare servicii");
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
        }


        private void btnUpdateServiciu_Click(object sender, EventArgs e)
        {
            if (serviciuSelectat == null)
            {
                MessageBox.Show("Nu ati selectat un serviciu pentru a il putea modifica!", "Actualizare informatii servicii", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool coincideStatus = true;
                if (checkBoxActiv.Checked)
                {
                    if (serviciuSelectat.Cells[5].Value.ToString() != "inactiv")
                        coincideStatus = false;
                }
                else
                {
                    if (serviciuSelectat.Cells[5].Value.ToString() == "inactiv")
                        coincideStatus = false;
                }

                if (serviciuSelectat.Cells[1].Value.ToString() == textBoxDenumire.Text && serviciuSelectat.Cells[1].Value.ToString() == textBoxDenumire.Text && serviciuSelectat.Cells[2].Value.ToString() == cbTipServiciu.Text && serviciuSelectat.Cells[5].Value.ToString() == textBoxDescriere.Text && coincideStatus == true)
                {
                    MessageBox.Show("Nu ati modificat informatiile pentru a le putea actualiza!", "Actualizare informatii servicii", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool denumireGasita = false;
                    DataRow[] inregCautate = ds.Tables["Servicii"].Select("denumire='" + textBoxDenumire.Text + "'");
                    if (inregCautate != null)
                    {
                        foreach (DataRow inregistrare in inregCautate)
                        {
                            if (inregistrare[0].ToString() != serviciuSelectat.Cells[0].Value.ToString())
                            {
                                if (inregistrare[1].ToString().ToLower() == textBoxDenumire.Text.ToLower())
                                {
                                    denumireGasita = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (denumireGasita == true)
                    {
                        MessageBox.Show("Exista deja un serviciu cu denumirea introdusa!", "Actualizare informatii servicii",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        textBoxDenumire.Text = serviciuSelectat.Cells[1].Value.ToString();
                    }
                    else
                    {
                        raspunsDialog = MessageBox.Show("Doriti sa actualizati informatiile serviciului '" + serviciuSelectat.Cells[1].Value.ToString() + "' cu cele introduse?", "Actualizare informatii servicii", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (raspunsDialog == DialogResult.Yes)
                        {
                            try
                            {
                                int idRandSelectat = Convert.ToInt32(serviciuSelectat.Cells[0].Value);

                                string status = "activ";
                                if (checkBoxActiv.Checked)
                                    status = "inactiv";

                                sqlcmd = "update servicii set denumire='"+textBoxDenumire.Text+"', tip='"+cbTipServiciu.Text+"', descriere='"+textBoxDescriere.Text+"', status='"+status+"' where id_serviciu='"+idRandSelectat+"'";

                                con.Open();
                                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                                cmd.ExecuteNonQuery();

                                DataRow dr = ds.Tables["Servicii"].Select("id_serviciu=" + Convert.ToInt32(serviciuSelectat.Cells[0].Value)).FirstOrDefault();
                                dr[1] = textBoxDenumire.Text;
                                dr[2] = cbTipServiciu.Text;
                                dr[4] = textBoxDescriere.Text;
                                dr[5] = status;

                                //algoritm pentru reselectarea serviciului daca nu s-a modificat denumirea
                                bool denumireDiferita = false;
                                if (serviciuSelectat.Cells[1].Value.ToString() != textBoxDenumire.Text)
                                {
                                    //MessageBox.Show("Alta denumire!");   
                                    denumireDiferita = true;
                                }
                                else
                                {
                                    //MessageBox.Show("Doar descrierea");
                                }

                                ds.Tables["Servicii"].AcceptChanges(); //https://stackoverflow.com/a/35182312
                                
                                dgvServicii.ClearSelection();
                                serviciuSelectat = null;
                                if (denumireDiferita == false)
                                {
                                    if (inregCurenta != -1)
                                    {
                                        dgvServicii.Rows[inregCurenta].Selected = true;
                                        serviciuSelectat = dgvServicii.Rows[inregCurenta];
                                    }
                                }
                                else
                                {
                                    textBoxDenumire.Text = null;
                                    cbTipServiciu.SelectedIndex = -1;
                                    textBoxDescriere.Text = null;
                                    checkBoxActiv.Checked = true;
                                    pictureBoxImagine.ImageLocation = path + "\\ClassRepository\\imagini\\servicii\\default.jpg";
                                }



                                MessageBox.Show("Informatii actualizate!", "Actualizare informatii servicii");
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
        }

        OpenFileDialog dialog;
        private void buttonSeteazaImagine_Click(object sender, EventArgs e)
        {
            if (serviciuSelectat == null)
            {
                MessageBox.Show("Nu ati selectat un serviciu pentru a putea modifica imaginea!", "Actualizare imagine servicii", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dialog.CheckFileExists)
                    {
                        //pictureBoxImagine.Image.Dispose();
                        //pictureBoxImagine.Image = Image.FromFile(System.IO.Path.GetFullPath(dialog.FileName));
                        pictureBoxImagine.ImageLocation = dialog.FileName;
                    }
                }
                else
                {
                    dialog = null;
                }
            }
        }

        private void buttonUpdateImagine_Click(object sender, EventArgs e)
        {
            if (serviciuSelectat == null)
            {
                MessageBox.Show("Nu ati selectat un serviciu!");
            }
            else
            {
                if (dialog == null)
                {
                    MessageBox.Show("Nu ai ales o imagine!", "Actualizare imagine serviciu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //algoritm pentru a verifica daca serviciul selectat are o imagine setata
                    string extensieImg = "";
                    bool areImagine = true;
                    if (System.IO.File.Exists(path + "\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + ".jpg"))
                    {
                        extensieImg = ".jpg";
                    }
                    else if (System.IO.File.Exists(path + "\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + ".jpeg"))
                    {
                        extensieImg = ".jpeg";
                    }
                    else if (System.IO.File.Exists(path + "\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + ".png"))
                    {
                        extensieImg = ".png";
                    }
                    else
                    {
                        areImagine = false;
                    }

                    bool trebuieActualizatBD = false;
                    if (areImagine == true)
                    {
                        //daca serviciul are imagine, se sterge pentru a adauga imaginea selectata
                        System.IO.File.Delete(path + "\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + extensieImg);

                        //algoritm pentru obtinerea extensiei imaginii serviciului selectat, din baza de date
                        int indexExtensie = (serviciuSelectat.Cells["imagine"].Value.ToString()).LastIndexOf('.');
                        string extensieImgServiciu = (serviciuSelectat.Cells["imagine"].Value.ToString()).Substring(indexExtensie);

                        if (extensieImgServiciu != Path.GetExtension(dialog.FileName))
                        {
                            //trebuie UPDATE cu noua extensie
                            trebuieActualizatBD = true;
                        }
                    }
                    else //daca nu are imagine setata, trebuie UPDATE pentru a o adauga
                    {
                        trebuieActualizatBD = true;
                    }

                    System.IO.File.Copy(dialog.FileName, path + "\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + Path.GetExtension(dialog.FileName));

                    if (trebuieActualizatBD)
                    {
                        //MessageBox.Show("se actualizeaza!");
                        try
                        {
                            con.Open();
                            sqlcmd = "update servicii set imagine='\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + System.IO.Path.GetExtension(dialog.FileName) + "' where id_serviciu='" + serviciuSelectat.Cells[0].Value.ToString() + "'";
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow dr = ds.Tables["Servicii"].Select("id_serviciu=" + Convert.ToInt32(serviciuSelectat.Cells[0].Value)).FirstOrDefault();
                            dr[3] = "\\ClassRepository\\imagini\\servicii\\" + serviciuSelectat.Cells[0].Value.ToString() + System.IO.Path.GetExtension(dialog.FileName);

                            ds.Tables["Servicii"].AcceptChanges();

                            dgvServicii.ClearSelection();
                            serviciuSelectat = null;

                            /*if (inregCurenta != -1)
                            {
                                dgvServicii.Rows[inregCurenta].Selected = true;
                                serviciuSelectat = dgvServicii.Rows[inregCurenta];
                            }*/

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

                    MessageBox.Show("Imaginea a fost actualizata!", "Actualizare imagine serviciu");
                    dialog = null;
                }
            }
        }

        private void dgvServicii_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvServicii.ClearSelection();
            //inregCurenta = -1;
            serviciuSelectat = null; //reseteaza randul selectat
            pictureBoxImagine.ImageLocation = path + "\\ClassRepository\\imagini\\servicii\\default.jpg";
        }

        private void buttonResetareImagine_Click(object sender, EventArgs e)
        {
            if (serviciuSelectat == null)
            {
                MessageBox.Show("Nu ati selectat un serviciu!");
            }
            else
            {
                if (serviciuSelectat.Cells[4].Value.ToString() == "\\ClassRepository\\imagini\\servicii\\default.jpg")
                {
                    MessageBox.Show("Nu se poate reseta");
                }
                else
                {
                    //MessageBox.Show(serviciuSelectat.Cells[4].Value.ToString() + "\n" + path + "\\ClassRepository\\imagini\\servicii\\default.jpg");
                    if (serviciuSelectat.Cells["imagine"].Value.ToString() != "\\ClassRepository\\imagini\\servicii\\default.jpg")
                    {
                        System.IO.File.Delete(path + serviciuSelectat.Cells["imagine"].Value.ToString());
                    }
                    try
                    {
                        sqlcmd = "update servicii set imagine='\\ClassRepository\\imagini\\servicii\\default.jpg' where id_serviciu='" + serviciuSelectat.Cells[0].Value.ToString() + "'";

                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();


                        DataRow row = ds.Tables["Servicii"].Select("id_serviciu=" + Convert.ToInt32(serviciuSelectat.Cells[0].Value)).FirstOrDefault();
                        row["imagine"] = "\\ClassRepository\\imagini\\servicii\\default.jpg";

                        ds.Tables["Servicii"].AcceptChanges(); //https://stackoverflow.com/a/35182312

                        serviciuSelectat = null;

                        pictureBoxImagine.ImageLocation = path + "\\ClassRepository\\imagini\\servicii\\default.jpg";

                        /*//se selecteaza serviciul adaugat
                        DataRow inregCautata = ds.Tables["Servicii"].Select("denumire='" + textBoxDenumire.Text + "'").FirstOrDefault();
                        if (inregCautata != null)
                        {
                            inregCurenta = Convert.ToInt32(inregCautata[0].ToString()) - 1;
                            dgvServicii.Rows[inregCurenta].Selected = true;
                            serviciuSelectat = dgvServicii.Rows[inregCurenta];
                        }

                        //dgvServicii.ClearSelection();
                        //serviciuSelectat = null;*/
                        MessageBox.Show("Imaginea a fost resetata!", "Resetare imagine serviciu");
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
}
