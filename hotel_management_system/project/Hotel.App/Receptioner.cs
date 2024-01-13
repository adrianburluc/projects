using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Hotel.App
{
    public partial class Receptioner : Form
    {
        int id_angajat;
        public Receptioner(int id_angajat)
        {
            this.id_angajat = id_angajat;
            InitializeComponent();
            MessageBox.Show("id angajat: " + id_angajat);
        }

        private void Receptioner_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnCazare_Click(object sender, EventArgs e)
        {
            DeschideCazare form = new DeschideCazare(id_angajat);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            DisponibilitateCamere dc = new DisponibilitateCamere();

            dc.disponibilitateCamere(DateTime.Parse("2021/08/03"), DateTime.Parse("2021/08/25"));
        }

        private void btnRezervare_Click(object sender, EventArgs e)
        {
            DeschideRezervare form = new DeschideRezervare(id_angajat);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnIstoricCazari_Click(object sender, EventArgs e)
        {
            DeschideIstoricCazari form = new DeschideIstoricCazari();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnIstoricRezervari_Click(object sender, EventArgs e)
        {
            DeschideIstoricRezervari form = new DeschideIstoricRezervari();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
