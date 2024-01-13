using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.App
{
    public partial class SelectareCamere : Form
    {
        public SelectareCamere(string categorie)
        {
            InitializeComponent();
            labelCamereDisponibile.Text = categorie + " - camere disponibile:";
        }

        public int test { get; set; }
        public DataTable camereDisponibile { get; set; }
        public DataTable camereAdaugate { get; set; }
        public DataTable camereSelectate { get; set; }

        private void SelectareCamere_Load(object sender, EventArgs e) //https://stackoverflow.com/a/5233526
        {
            foreach (DataRow cameraAdaugata in camereAdaugate.Rows)
            {
                DataRow row = camereDisponibile.Select("Camera="+cameraAdaugata[1].ToString()).FirstOrDefault();
                if(row!=null)
                    camereDisponibile.Rows.Remove(row);
            }
            dgvCamereLibere.DataSource = camereDisponibile;
            dgvCamereLibere.Columns[2].Visible = false;
            dgvCamereLibere.Columns[6].Visible = false;

            for (int i = 1; i < 7; i++)
            {
                dgvCamereLibere.Columns[i].ReadOnly = true;
            }

            this.CenterToScreen();
        }

        private void buttonAdaugaCamere_Click(object sender, EventArgs e)
        {
            camereSelectate = camereDisponibile.Clone();
            DataRow[] camereBifate = camereDisponibile.Select("selectat='true'");

            foreach (DataRow cameraBifata in camereBifate) //ppentru fiecare camera selectata
            {
                camereSelectate.Rows.Add(cameraBifata.ItemArray);
            }

            /*DataRow[] camereBifate = camereDisponibile.Select("selectat='true'");
            if (camereBifate == null)
            {
                MessageBox.Show("Nu ati selectat");
            }
            else
            {
                bool camereIntroduseDeja = false;
                foreach (DataRow cameraBifata in camereBifate) //ppentru fiecare camera selectata
                {
                    //verifica daca exista inregistrarea in cele selectate
                    foreach (DataRow cameraAdaugata in camereAdaugate.Rows) //pentru fiecare camera adaugata deja
                    {
                        if (cameraAdaugata[1].ToString() == cameraBifata[1].ToString()) //daca au acelasi id nu se va adauga din nou
                        {
                            //MessageBox.Show(cameraAdaugata[1] + "exista deja!");
                            camereIntroduseDeja = true;
                            break;
                        }
                        //MessageBox.Show(cameraAdaugata[1] + " " + cameraBifata[1]);
                    }
                    camereSelectate.Rows.Add(cameraBifata.ItemArray);
                }
            }*/

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonAnuleaza_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCamereLibere_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int inregCurenta = dgvCamereLibere.CurrentCell.RowIndex;
                DataGridViewRow cameraSelectata = dgvCamereLibere.Rows[inregCurenta];

                textBoxDescriere.Text = "Descriere camera " + cameraSelectata.Cells[1].Value.ToString() + ": " + cameraSelectata.Cells[6].Value.ToString();
            }
        }
    }
}
