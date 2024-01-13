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
    public partial class GalerieCategoriiCamere : Form
    {
        public DataTable galerie { get; set; }
        public bool galerieModificata { get; set; }
        public string pathString { get; set; }
        DataTable galerieNoua;
        string path;
        int index;
        string categorie;
        int idCategorie;
        DialogResult raspunsDialog;

        SqlConnection con;
        SqlDataAdapter da;
        string sqlcmd = "";

        public GalerieCategoriiCamere(int idCategorie, string denumireCategorie)
        {
            InitializeComponent();
            categorie = denumireCategorie;
            this.idCategorie = idCategorie;
        }

        private void GalerieCategoriiCamere_Load(object sender, EventArgs e)
        {
            
            galerieModificata = false;
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";

            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 20));
            pathString = path;

            galerieNoua = galerie.Clone();

            for (int i = 0; i < galerie.Rows.Count; i++)
            {
                galerieNoua.Rows.Add(galerie.Rows[i].ItemArray);
                galerieNoua.Rows[i][1] = path + galerieNoua.Rows[i][1];
            }

            index = 0;
            btnInapoi.Enabled = false;
            if (galerieNoua.Rows.Count < 2)
                btnInainte.Enabled = false;

            if (galerieNoua.Rows.Count > 0)
                pictureBoxImagine.ImageLocation = galerieNoua.Rows[index][1].ToString();
            else
                pictureBoxImagine.ImageLocation = path + "\\ClassRepository\\imagini\\camere\\default.jpg";

            labelPozitie.Text = "Poza " + (index + 1) + " din " + galerie.Rows.Count.ToString();
            labelDenumireCategorie.Text = categorie;

            this.CenterToScreen();
        }

        private void btnInainte_Click(object sender, EventArgs e)
        {
            index = index + 1;
            if (index == galerieNoua.Rows.Count - 1)
                btnInainte.Enabled = false;

            pictureBoxImagine.ImageLocation = galerieNoua.Rows[index][1].ToString();

            if (btnInapoi.Enabled == false)
                btnInapoi.Enabled = true;

            labelPozitie.Text = "Poza " + (index + 1) + " din " + galerieNoua.Rows.Count.ToString();
        }

        private void btnInapoi_Click(object sender, EventArgs e)
        {
            index = index - 1;
            if (index == 0)
                btnInapoi.Enabled = false;

            pictureBoxImagine.ImageLocation = galerieNoua.Rows[index][1].ToString();

            if (btnInainte.Enabled == false)
                btnInainte.Enabled = true;

            labelPozitie.Text = "Poza " + (index + 1) + " din " + galerieNoua.Rows.Count.ToString();
        }

        OpenFileDialog dialog;
        private void btnAdaugaImg_Click(object sender, EventArgs e)
        {
            
            dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.Multiselect = true;
            int nrImaginiExistente = 0;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fisier in dialog.FileNames)
                {
                    DataRow verificaFisier = galerieNoua.Select("imagine='" + fisier + "'").FirstOrDefault();
                    //MessageBox.Show(fisier);

                    if (verificaFisier == null)
                    {
                        DataRow imagine = galerieNoua.NewRow();
                        imagine["id_categorie"] = idCategorie;
                        imagine["imagine"] = fisier;

                        galerieNoua.Rows.Add(imagine);
                        galerieNoua.AcceptChanges(); //https://stackoverflow.com/a/35182312
                        //MessageBox.Show(file + "\n"+path);
                    }
                    else
                        nrImaginiExistente++;
                }

                if (nrImaginiExistente > 0)
                    MessageBox.Show(nrImaginiExistente + " din " + dialog.FileNames.Count() + " imagini selectate sunt deja introduse!", "Adaugare imagini", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (btnInainte.Enabled == false)
                    btnInainte.Enabled = true;

                labelPozitie.Text = "Poza " + (index + 1) + " din " + galerieNoua.Rows.Count.ToString();
            }
        }

        private void btnStergeImg_Click(object sender, EventArgs e)
        {
            if (galerieNoua.Rows.Count > 1)
            {
                if (galerieNoua.Rows.Count == 2)
                {
                    btnInapoi.Enabled = false;
                    btnInainte.Enabled = false;
                }
                galerieNoua.Rows[index].Delete();
                galerieNoua.AcceptChanges();

                if (index > 0)
                    index = index - 1;

                pictureBoxImagine.ImageLocation = galerieNoua.Rows[index][1].ToString();
                labelPozitie.Text = "Poza " + (index + 1) + " din " + galerieNoua.Rows.Count.ToString();

                if (index == 2)
                {
                    btnInapoi.Enabled = false;
                }
            }
            else
            {
                raspunsDialog = MessageBox.Show("ATENTIE! Doriti sa setati imaginea implicita (default)?", "Modificare imagini", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (raspunsDialog == DialogResult.Yes)
                {
                    seteazaImgDefault();
                }
            }
        }

        void seteazaImgDefault()
        {
            galerieNoua.Clear();

            DataRow imagine = galerieNoua.NewRow();
            imagine["id_categorie"] = idCategorie;
            imagine["imagine"] = path + "\\ClassRepository\\imagini\\camere\\default.jpg";

            galerieNoua.Rows.Add(imagine);
            galerieNoua.AcceptChanges(); //https://stackoverflow.com/a/35182312

            pictureBoxImagine.ImageLocation = galerieNoua.Rows[0][1].ToString();
        }

        private void btnSeteazaImg_Click(object sender, EventArgs e)
        {
            if (galerieNoua.Rows.Count > 1 && index > 0)
            {
                //imaginea de pe pozitia 0 va fi salvata intr-un row auxiliar, iar restul imaginilor isi vor modifica indexul cu +1
                DataRow imgRep = galerieNoua.NewRow();
                imgRep.ItemArray = galerieNoua.Rows[index].ItemArray;
                galerieNoua.Rows.Remove(galerieNoua.Rows[index]);
                galerieNoua.Rows.InsertAt(imgRep, 0);

                index = 0;
                pictureBoxImagine.ImageLocation = galerieNoua.Rows[index][1].ToString();
                labelPozitie.Text = "Poza " + (index + 1) + " din " + galerieNoua.Rows.Count.ToString();

                btnInainte.Enabled = true;
                btnInapoi.Enabled = false;
            }
            else
            {
                MessageBox.Show("Imaginea curenta este deja setata!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                sqlcmd = "delete from imagini_categorii_camere where id_categorie=" + idCategorie;
                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete db");

                sqlcmd = "insert into imagini_categorii_camere values(" + idCategorie + ", @Pozitie)";
                cmd = new SqlCommand(sqlcmd, con);

                cmd.Parameters.Add("@Pozitie", SqlDbType.NVarChar);

                string denumireImagine = @"" + idCategorie + "_*";
                string[] imaginiDeSters = System.IO.Directory.GetFiles(path + "\\ClassRepository\\imagini\\camere\\", denumireImagine);
                foreach (string pathImagine in imaginiDeSters)
                {
                    DataRow imagineExistenta = galerieNoua.Select("imagine='" + pathImagine + "'").FirstOrDefault();
                    if (imagineExistenta == null)
                        System.IO.File.Delete(pathImagine);
                    else
                    {
                        string newFileName = Path.GetFileNameWithoutExtension(pathImagine) + "temp" + Path.GetExtension(pathImagine);

                        System.IO.File.Move(pathImagine, path + "\\ClassRepository\\imagini\\camere\\" + newFileName);
                        imagineExistenta["imagine"] = path + "\\ClassRepository\\imagini\\camere\\" + newFileName;
                    }
                }

                int pozitie = -1;
                foreach (DataRow imagineNoua in galerieNoua.Rows)
                {
                    string extensie = imagineNoua["imagine"].ToString().Substring(imagineNoua["imagine"].ToString().LastIndexOf('.'));
                    pozitie = pozitie + 1;
                    System.IO.File.Copy(imagineNoua["imagine"].ToString(), path + "\\ClassRepository\\imagini\\camere\\" +
                        idCategorie + "_" + pozitie + extensie);

                    cmd.Parameters["@Pozitie"].Value = "\\ClassRepository\\imagini\\camere\\" + idCategorie + "_" + pozitie + extensie;
                    imagineNoua["imagine"] = path + "\\ClassRepository\\imagini\\camere\\" + idCategorie + "_" + pozitie + extensie;
                    cmd.ExecuteNonQuery();
                }

                denumireImagine = @"*temp*";
                imaginiDeSters = System.IO.Directory.GetFiles(path + "\\ClassRepository\\imagini\\camere\\", denumireImagine);
                foreach (string pathImagine in imaginiDeSters)
                {
                    System.IO.File.Delete(pathImagine);
                }

                galerie = galerieNoua.Copy();
                galerieModificata = true;
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

        private void buttonStergeGalerie_Click(object sender, EventArgs e)
        {
            raspunsDialog = MessageBox.Show("ATENTIE! Daca stergeti galeria se va seta imaginea implicita!", "Modificare imagini", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (raspunsDialog == DialogResult.Yes)
            {
                seteazaImgDefault();
                btnInainte.Enabled = false;
                btnInapoi.Enabled = false;
                index = 0;
                labelPozitie.Text = "Poza " + (index + 1) + " din " + galerieNoua.Rows.Count.ToString();
            }
        }
    }
}
