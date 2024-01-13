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
    public partial class OptiuniReduceri : Form
    {
        public OptiuniReduceri()
        {
            InitializeComponent();
        }

        private void OptiuniReduceri_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnGestiuneReduceriClienti_Click(object sender, EventArgs e)
        {
            GestiuneReduceriClienti form = new GestiuneReduceriClienti();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnGestiuneReduceriCamere_Click(object sender, EventArgs e)
        {
            GestiuneReduceriCamere form = new GestiuneReduceriCamere();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
