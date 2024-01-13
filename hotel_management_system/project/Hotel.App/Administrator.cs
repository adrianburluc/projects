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
    public partial class Administrator : Form
    {
        int id_angajat;
        public Administrator(int id_angajat)
        {
            this.id_angajat = id_angajat;
            InitializeComponent();
            MessageBox.Show("id angajat: " + id_angajat);
        }

        private void btnGestiuneTipCamere_Click(object sender, EventArgs e)
        {
            GestiuneCategoriiCamere form = new GestiuneCategoriiCamere();
            form.ShowDialog();
        }

        private void btnGestiuneCamere_Click(object sender, EventArgs e)
        {
            GestiuneCamere form5 = new GestiuneCamere();
            this.Hide();
            form5.ShowDialog();
            this.Show();
        }

        private void buttonAlocaPaturi_Click(object sender, EventArgs e)
        {
            AlocarePaturi form = new AlocarePaturi();
            form.ShowDialog();
        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnFormCategCamere_Click(object sender, EventArgs e)
        {
            GestiuneCategoriiCamere form = new GestiuneCategoriiCamere();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnFormOptiuniTarife_Click(object sender, EventArgs e)
        {
            OptiuniTarife form = new OptiuniTarife();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnGestiuneServicii_Click(object sender, EventArgs e)
        {
            GestiuneServicii form = new GestiuneServicii();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnGestiuneOferte_Click(object sender, EventArgs e)
        {
            OptiuniReduceri form = new OptiuniReduceri();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Cazare form = new Cazare();
            this.Hide();
            form.ShowDialog();
            this.Show();*/
        }

        private void btnGestiuneCazari_Click(object sender, EventArgs e)
        {
            /*Receptioner form = new Receptioner();
            this.Hide();
            form.ShowDialog();
            this.Show();*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GestiuneDatePersonale form = new GestiuneDatePersonale();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rapoarte form = new Rapoarte();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
