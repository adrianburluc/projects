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
using ClassRepository;

namespace Hotel.App
{
    public partial class GestiuneCategoriiCamere : Form
    {
        public GestiuneCategoriiCamere()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;
        public DataTable dtImagini { get; set; }


        private void GestiuneTipCamere_Load(object sender, EventArgs e)
        {   
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            sqlcmd = "select Id, denumire, nr_oaspeti, dimensiune_mp, descriere from categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "CategoriiCamere");

            sqlcmd = "select id_categorie_camera, paturi_categorii_camere.id_tip_pat, paturi.denumire, nr_paturi from paturi_categorii_camere join paturi on paturi_categorii_camere.id_tip_pat=paturi.id_tip_pat";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "PaturiCamere");

            sqlcmd = "select id_categorie_camere, utilitati_camere.id_utilitate, utilitati.denumire from utilitati_camere join utilitati on utilitati.Id=utilitati_camere.id_utilitate";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "UtilitatiCamere");

            sqlcmd = "select Id, denumire from utilitati";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Utilitati");

            sqlcmd = "select id_categorie, imagine from imagini_categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds,"Imagini");

            sqlcmd = "select id_tip_pat, denumire from paturi";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Paturi");

            con.Close();

            dgvCategoriiCamere.DataSource = ds.Tables["CategoriiCamere"];
            dgvCategoriiCamere.Columns["id"].Visible = false;
            dgvCategoriiCamere.Columns[1].HeaderText = "Categorie";
            dgvCategoriiCamere.Columns[2].HeaderText = "Limita oaspeti";
            dgvCategoriiCamere.Columns[3].HeaderText = "Dimensiune";
            dgvCategoriiCamere.Columns[4].HeaderText = "Descriere";
            //dgvCategoriiCamere.Columns[5].HeaderText = "Status";

            dgvCategoriiCamere.ClearSelection();

            //https://stackoverflow.com/a/26006620
            cbPaturi.ValueMember = "id_tip_pat";
            cbPaturi.DisplayMember = "denumire";
            cbPaturi.DataSource = ds.Tables["Paturi"];

            cbUtilitati.ValueMember = "Id";
            cbUtilitati.DisplayMember = "denumire";
            cbUtilitati.DataSource = ds.Tables["Utilitati"];


            if (cbUtilitati.Items.Count > 0)
            {
                cbUtilitati.SelectedIndex = 0;
            }

            //dgvCategoriiCamere.Sort(dgvCategoriiCamere.Columns["status"], ListSortDirection.Ascending);

            this.CenterToScreen();
        }

        DataGridViewRow categorieSelectata = null;
        private void dgvCategoriiCamere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int inregCurenta = dgvCategoriiCamere.CurrentCell.RowIndex;
                categorieSelectata = dgvCategoriiCamere.Rows[inregCurenta];

                textBoxDenumire.Text = categorieSelectata.Cells[1].Value.ToString();
                numericNrPersoane.Value = Convert.ToInt32(categorieSelectata.Cells[2].Value);
                numericDimensiune.Value = Convert.ToInt32(categorieSelectata.Cells[3].Value);
                textBoxDescriere.Text = categorieSelectata.Cells[4].Value.ToString();

                /*if (categorieSelectata.Cells[5].Value.ToString() == "inactiv")
                {
                    checkBoxActiv.Checked = true;
                }
                else
                {
                    checkBoxActiv.Checked = false;
                }*/

                listBoxPaturi.Items.Clear();
                foreach (DataRow datarow in ds.Tables["PaturiCamere"].Rows)
                {
                    if (datarow[0].ToString() == categorieSelectata.Cells[0].Value.ToString())
                    {
                        listBoxPaturi.Items.Add(datarow[3].ToString() + " x " + datarow[2].ToString());
                    }
                }

                listBoxUtilitati.Items.Clear();
                foreach (DataRow datarow in ds.Tables["UtilitatiCamere"].Rows)
                {
                    if (datarow[0].ToString() == categorieSelectata.Cells[0].Value.ToString())
                    {
                        listBoxUtilitati.Items.Add(datarow[2].ToString());
                    }
                }

                labelPaturi.Text = "Paturi " + categorieSelectata.Cells[1].Value.ToString().ToLower()+":";
                labelUtilitati.Text = "Utilitati " + categorieSelectata.Cells[1].Value.ToString().ToLower() + ":";
            }
        }

        private void listBoxTipCamere_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxPaturi.SelectedIndex != -1)
            {
                foreach (DataRow row in ds.Tables["CategoriiCamere"].Rows)
                {
                    if (row[0].ToString() == listBoxPaturi.SelectedItem.ToString())
                    {
                        textBoxDenumire.Text = row[0].ToString();
                        textBoxDescriere.Text = row[1].ToString();
                        numericNrPersoane.Value = Convert.ToInt32(row[2]);
                        numericDimensiune.Value = Convert.ToInt32(row[5]);
                        break;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (categorieSelectata == null)
            {
                MessageBox.Show("Nu ati selectat o categorie pentru a o putea modifica!","Actualizare informatii categorie camere",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                /*string status = "activ";
                if (checkBoxActiv.Checked)
                {
                    status = "inactiv";
                }*/
                if (Convert.ToInt32(categorieSelectata.Cells[2].Value) == numericNrPersoane.Value && Convert.ToInt32(categorieSelectata.Cells[3].Value) == numericDimensiune.Value && categorieSelectata.Cells[4].Value.ToString() == textBoxDescriere.Text)// && categorieSelectata.Cells[5].Value.ToString() == status)
                {
                    if (categorieSelectata.Cells[1].Value.ToString() != textBoxDenumire.Text)
                    {
                        MessageBox.Show("Nu se poate modifica denumirea categoriilor!", "Actualizare informatii categorie camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxDenumire.Text = categorieSelectata.Cells[1].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nu ati modificat informatiile pentru a le putea actualiza!", "Actualizare informatii categorie camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (categorieSelectata.Cells[1].Value.ToString() != textBoxDenumire.Text)
                    {
                        raspunsDialog = MessageBox.Show("ATENTIE! Nu se poate modifica denumirea categoriei!\n\nDoriti sa actualizati informatiile introduse FARA denumire?", "Actualizare informatii categorie camere", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        raspunsDialog = MessageBox.Show("Doriti sa actualizati informatiile categoriei '" + categorieSelectata.Cells[1].Value.ToString() + "' cu cele introduse?", "Actualizare informatii categorie camere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    
                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            int idRandSelectat = Convert.ToInt32(categorieSelectata.Cells[0].Value);
                            sqlcmd = "update categorii_camere set nr_oaspeti='" + numericNrPersoane.Value + "', dimensiune_mp='" + numericDimensiune.Value + "', descriere='" + textBoxDescriere.Text + "' where Id='" + categorieSelectata.Cells[0].Value + "'";//"', status='" + status + "' where Id='" + categorieSelectata.Cells[0].Value + "'";
                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow dr = ds.Tables["CategoriiCamere"].Select("Id=" + idRandSelectat).FirstOrDefault();
                            dr[2] = numericNrPersoane.Value;
                            dr[3] = numericDimensiune.Value;
                            dr[4] = textBoxDescriere.Text;
                            //dr[5] = status;

                            ds.Tables["CategoriiCamere"].AcceptChanges(); //https://stackoverflow.com/a/35182312

                            dgvCategoriiCamere.ClearSelection();
                            categorieSelectata = null; //reseteaza randul selectat
                            textBoxDenumire.Text = "";
                            textBoxDescriere.Text = "";
                            numericNrPersoane.Value = 0;
                            numericDimensiune.Value = 0;
                            textBoxDescriere.Text = "";

                            MessageBox.Show("Informatii actualizate!", "Actualizare informatii categorie camere");
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

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            if (textBoxDenumire.Text == "" || numericNrPersoane.Value == 0 || numericDimensiune.Value == 0 || textBoxDescriere.Text == "")
            {
                MessageBox.Show("Completati toate campurile pentru a putea inregistra categoria!", "Inregistrare categorie camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool denumireGasita = false;
                DataRow dr = ds.Tables["CategoriiCamere"].Select("denumire='" + textBoxDenumire.Text + "'").FirstOrDefault();
                if (dr != null)
                {
                    if (dr[1].ToString().ToLower() == textBoxDenumire.Text.ToLower())
                        denumireGasita = true;
                }

                if (denumireGasita == true)
                {
                    MessageBox.Show("Denumirea categoriei exista deja!", "Inregistrare categorie camere", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    raspunsDialog = MessageBox.Show("Doriti sa inregistrati urmatoarea categorie de camere?\n\nDenumire: " + textBoxDenumire.Text + "\nDescriere: " + textBoxDescriere.Text + "\nNumar locuri: " + numericNrPersoane.Value + "\nDimensiune: " + numericDimensiune.Value + "", "Inregistrare categorie camere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            int idCategorieNoua = 0;
                            if (ds.Tables["CategoriiCamere"].Rows.Count > 0)
                                idCategorieNoua = Convert.ToInt32(ds.Tables["CategoriiCamere"].Rows[ds.Tables["CategoriiCamere"].Rows.Count - 1][0]) + 1; //https://stackoverflow.com/a/13816531
                            else
                                idCategorieNoua = 1;

                            sqlcmd = "insert into categorii_camere values('" + idCategorieNoua + "', '" + textBoxDenumire.Text + "', '" + numericNrPersoane.Value + "', '" + numericDimensiune.Value + "', '" + textBoxDescriere.Text + "')";

                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            sqlcmd = "insert into imagini_categorii_camere values('" + idCategorieNoua + "','\\ClassRepository\\imagini\\camere\\default.jpg')";
                            cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow imaginiCategorie = ds.Tables["Imagini"].NewRow();
                            imaginiCategorie["id_categorie"] = idCategorieNoua;
                            imaginiCategorie["imagine"] = "\\ClassRepository\\imagini\\camere\\default.jpg";

                            ds.Tables["Imagini"].Rows.Add(imaginiCategorie);
                            ds.Tables["Imagini"].AcceptChanges();

                            DataRow categorie = ds.Tables["CategoriiCamere"].NewRow();
                            categorie["Id"] = idCategorieNoua;
                            categorie["denumire"] = textBoxDenumire.Text;
                            categorie["nr_oaspeti"] = numericNrPersoane.Value;
                            categorie["dimensiune_mp"] = numericDimensiune.Value;
                            categorie["descriere"] = textBoxDescriere.Text;
                            //categorie["status"] = checkBoxActiv.Text;

                            ds.Tables["CategoriiCamere"].Rows.Add(categorie);

                            ds.Tables["CategoriiCamere"].AcceptChanges(); //https://stackoverflow.com/a/35182312


                            dgvCategoriiCamere.ClearSelection();
                            categorieSelectata = null;
                            textBoxDenumire.Text = "";
                            textBoxDescriere.Text = "";
                            numericNrPersoane.Value = 0;
                            numericDimensiune.Value = 0;
                            textBoxDescriere.Text = "";
                            MessageBox.Show("Categoria a fost adaugata!", "Inregistrare categorie camere");
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

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dgvCategoriiCamere_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvCategoriiCamere.ClearSelection();
            //inregCurenta = -1;
            categorieSelectata = null; //reseteaza randul selectat
        }


        
        private void buttonAdaugaPat_Click(object sender, EventArgs e)
        {
            bool itemGasit = false;
            int indexItem = 0;
            string[] informatiiPatSelectat = null;
            string[] separator = { " x " };
            int nrPaturiExistente = 0;
            int nrPaturiAdaugate = 0;
            string morfologiePaturiExistente = "pat";
            string morfologiePaturiAdaugate = "pat";

            if (listBoxPaturi.Items.Count > 0)
            {
                foreach (var item in listBoxPaturi.Items)
                {
                    informatiiPatSelectat = item.ToString().Split(separator, StringSplitOptions.None);
                    if (informatiiPatSelectat[1] == cbPaturi.Text)
                    {
                        itemGasit = true;
                        indexItem = listBoxPaturi.Items.IndexOf(item);
                        break;
                    }
                }
            }

            if (itemGasit)
            {
                nrPaturiExistente = Convert.ToInt32(informatiiPatSelectat[0]);
                nrPaturiAdaugate = Convert.ToInt32(nrPaturi.Value);

                if (nrPaturiExistente > 1)
                    morfologiePaturiExistente = "paturi";

                if (nrPaturiAdaugate > 1)
                    morfologiePaturiAdaugate = "paturi";

                raspunsDialog = MessageBox.Show("ATENTIE! Categoria selectata include deja " + nrPaturiExistente + " " + morfologiePaturiExistente + " de tip '" + informatiiPatSelectat[1].ToLower() + "'!\n\nDoriti sa mai adaugati inca " + nrPaturiAdaugate + " " + morfologiePaturiAdaugate + "?\n\nTotal: " + (nrPaturi.Value + nrPaturiExistente) + " x "+informatiiPatSelectat[1], "Adaugare pat", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (raspunsDialog == DialogResult.Yes)
                {
                    try
                    {
                        sqlcmd = "update paturi_categorii_camere set nr_paturi='" + (nrPaturi.Value + nrPaturiExistente) + "' where id_categorie_camera='" + categorieSelectata.Cells[0].Value.ToString() + "' and id_tip_pat=(select id_tip_pat from paturi where denumire = '" + cbPaturi.Text + "')";

                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        DataRow dr = ds.Tables["PaturiCamere"].Select("id_categorie_camera='" + categorieSelectata.Cells[0].Value.ToString() + "' AND denumire='" + informatiiPatSelectat[1] + "'").FirstOrDefault();
                        dr[3] = nrPaturi.Value + nrPaturiExistente;

                        listBoxPaturi.Items[indexItem] = (nrPaturi.Value + nrPaturiExistente) + " x " + informatiiPatSelectat[1];

                        MessageBox.Show("Numarul a fost actualizat!", "Adaugare pat");
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
            else
            {
                if (categorieSelectata == null)
                {
                    MessageBox.Show("Nu ati selectat o categorie pentru a o putea adauga paturi!!", "Adaugare pat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    raspunsDialog = MessageBox.Show("Doriti sa adaugati " + nrPaturi.Value + " " + morfologiePaturiAdaugate + " de tip '" + cbPaturi.Text + "' pentru categoria '" + categorieSelectata.Cells[1].Value.ToString() + "'?", "Adaugare pat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            sqlcmd = "insert into paturi_categorii_camere values('" + categorieSelectata.Cells[0].Value.ToString() + "', '" + ((DataRowView)cbPaturi.SelectedItem)["id_tip_pat"].ToString() + "', '" + nrPaturi.Value + "')";

                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow row = ds.Tables["PaturiCamere"].NewRow();
                            row["id_categorie_camera"] = categorieSelectata.Cells[0].Value.ToString();
                            row["id_tip_pat"] = ((DataRowView)cbPaturi.SelectedItem)["id_tip_pat"].ToString(); //https://stackoverflow.com/a/33482983
                            row["denumire"] = cbPaturi.Text;
                            row["nr_paturi"] = nrPaturi.Value;

                            ds.Tables["PaturiCamere"].Rows.Add(row);

                            ds.Tables["PaturiCamere"].AcceptChanges(); //https://stackoverflow.com/a/35182312

                            listBoxPaturi.Items.Add(nrPaturi.Value + " x " + cbPaturi.Text);

                            MessageBox.Show("Adaugat: " + nrPaturi.Value + " " + morfologiePaturiAdaugate + " de tip '" + cbPaturi.Text + "'", "Adaugare pat");
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

        private void buttonStergePat_Click(object sender, EventArgs e)
        {
            if (listBoxPaturi.SelectedIndex == -1)
            {
                MessageBox.Show("Nu ati selectat un pat pentru a fi sters!", "Stergere pat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] separator = { " x " };
                string[] informatiiPatSelectat = listBoxPaturi.SelectedItem.ToString().Split(separator, StringSplitOptions.None);

                raspunsDialog = MessageBox.Show("Doriti sa stergeti toate paturile de tip '"+informatiiPatSelectat[1].ToLower()+"' pentru categoria '"+categorieSelectata.Cells[1].Value.ToString()+"'?", "Stergere pat", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (raspunsDialog == DialogResult.Yes)
                {
                    try
                    {
                        sqlcmd = "delete from paturi_categorii_camere where id_tip_pat=(select id_tip_pat from paturi where denumire ='" + informatiiPatSelectat[1] + "')";

                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        DataRow dr = ds.Tables["PaturiCamere"].Select("denumire='" + informatiiPatSelectat[1] + "'").FirstOrDefault();
                        dr.Delete();

                        ds.Tables["PaturiCamere"].AcceptChanges();

                        listBoxPaturi.Items.RemoveAt(listBoxPaturi.SelectedIndex);

                        MessageBox.Show("Sters!", "Stergere pat");
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

        private void buttonAdaugaUtilitate_Click(object sender, EventArgs e)
        {
            if (categorieSelectata == null)
            {
                MessageBox.Show("Nu ati selectat o categorie pentru a o putea adauga utilitati!", "Adaugare utilitati", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool itemGasit = false;
                foreach (var item in listBoxUtilitati.Items)
                {
                    if (item.ToString() == cbUtilitati.Text)
                    {
                        itemGasit = true;
                        break;
                    }
                }

                if (itemGasit)
                {
                    MessageBox.Show("Categoria '"+categorieSelectata.Cells[1].Value.ToString()+"' include deja utilitatea "+cbUtilitati.Text+"!","Adaugare utilitati",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    raspunsDialog = MessageBox.Show("Doriti sa adaugati " + cbUtilitati.Text + " categoriei '" + categorieSelectata.Cells[1].Value.ToString() + "'?", "Adaugare utilitati", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            sqlcmd = "insert into utilitati_camere values('" + categorieSelectata.Cells[0].Value.ToString() + "', '" + ((DataRowView)cbUtilitati.SelectedItem)["Id"].ToString() + "')";

                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow row = ds.Tables["UtilitatiCamere"].NewRow();
                            row["id_categorie_camere"] = categorieSelectata.Cells[0].Value.ToString();
                            row["id_utilitate"] = ((DataRowView)cbUtilitati.SelectedItem)["Id"].ToString();
                            row["denumire"] = cbUtilitati.Text;

                            ds.Tables["UtilitatiCamere"].Rows.Add(row);

                            ds.Tables["UtilitatiCamere"].AcceptChanges(); //https://stackoverflow.com/a/35182312

                            listBoxUtilitati.Items.Add(cbUtilitati.Text);

                            MessageBox.Show("Adaugat!", "Adaugare utilitati");
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

        private void buttonStergeUtilitate_Click(object sender, EventArgs e)
        {
            if (listBoxUtilitati.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati o utilitate pentru a o sterge!", "Stergere utilitati", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                raspunsDialog = MessageBox.Show("Doriti sa stergeti utilitatea '"+listBoxUtilitati.SelectedItem.ToString()+"' pentru categoria '"+categorieSelectata.Cells[1].Value.ToString()+"'?", "Stergere utilitati", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (raspunsDialog == DialogResult.Yes)
                {
                    try
                    {
                        sqlcmd = "delete from utilitati_camere where id_utilitate=(select Id from utilitati where denumire='" + listBoxUtilitati.SelectedItem.ToString() + "')";

                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        DataRow dr = ds.Tables["UtilitatiCamere"].Select("denumire='" + listBoxUtilitati.SelectedItem.ToString() + "'").FirstOrDefault();
                        dr.Delete();

                        ds.Tables["UtilitatiCamere"].AcceptChanges();

                        dgvCategoriiCamere.ClearSelection();

                        listBoxUtilitati.Items.RemoveAt(listBoxUtilitati.SelectedIndex);

                        MessageBox.Show("Sters!", "Stergere utilitati", MessageBoxButtons.OK);
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

        private void buttonGalerie_Click(object sender, EventArgs e)
        {
            if(categorieSelectata==null)
            {
                MessageBox.Show("Nu ati selectat o categorie!");
            }
            else
            {
                DataRow[] imaginiGasite = ds.Tables["imagini"].Select("id_categorie=" + categorieSelectata.Cells[0].Value.ToString());

                GalerieCategoriiCamere meniuGalerie = new GalerieCategoriiCamere((int)categorieSelectata.Cells[0].Value, categorieSelectata.Cells[1].Value.ToString());
                if(imaginiGasite.Count()!=0)
                    meniuGalerie.galerie = imaginiGasite.CopyToDataTable();
                meniuGalerie.ShowDialog();

                if (meniuGalerie.galerieModificata == true)
                {
                    //algoritm pentru a actualiza imaginile categoriei selectate dupa inchiderea galeriei
                    //se intampla indiferent daca s-au modificat sau nu imaginile

                    //sterge imaginile categoriei
                    foreach (DataRow row in imaginiGasite)
                    {
                        ds.Tables["Imagini"].Rows.Remove(row);
                    }

                    //adauga imaginile ramase din galerie
                    foreach (DataRow row in meniuGalerie.galerie.Rows)
                    {
                        row[1] = row[1].ToString().Substring(meniuGalerie.pathString.Count());//se scoate path-ul aplicatiei
                        ds.Tables["Imagini"].Rows.Add(row.ItemArray);
                    }
                    ds.Tables["Imagini"].AcceptChanges();
                }
            }
        }
    }
}
