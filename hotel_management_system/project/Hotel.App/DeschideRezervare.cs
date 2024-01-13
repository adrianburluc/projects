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
    public partial class DeschideRezervare : Form
    {
        int id_angajat;
        public DeschideRezervare(int id_angajat)
        {
            this.id_angajat = id_angajat;
            InitializeComponent();
            MessageBox.Show(id_angajat + " id angajat");
        }

        private void btnContinua_Click(object sender, EventArgs e)
        {
            DateTime dataInceput = dataInceputSejur.Value;
            DateTime dataSfarsit = dataSfarsitSejur.Value;

            Rezervare form = new Rezervare(dataInceput, dataSfarsit, Convert.ToInt32(nrOaspeti.Value), id_angajat);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void DeschideRezervare_Load(object sender, EventArgs e)
        {
            dataInceputSejur.MinDate = DateTime.Today.AddDays(1);
            this.CenterToScreen();
        }

        private void dataInceputSejur_ValueChanged(object sender, EventArgs e)
        {
            dataSfarsitSejur.MinDate = dataInceputSejur.Value.AddDays(1);
        }
    }
}
