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
    public partial class OptiuniTarife : Form
    {
        public OptiuniTarife()
        {
            InitializeComponent();
        }

        private void OptiuniTarife_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnTarifeServicii_Click(object sender, EventArgs e)
        {
            GestiuneTarifeServicii form = new GestiuneTarifeServicii();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnTarifeCamere_Click(object sender, EventArgs e)
        {
            GestiuneTarifeCamere form = new GestiuneTarifeCamere();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
