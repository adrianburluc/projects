using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel.App
{
    public partial class DeschideCazare : Form
    {
        int id_angajat;
        public DeschideCazare(int id_angajat)
        {
            this.id_angajat = id_angajat;
            InitializeComponent();
            MessageBox.Show(id_angajat + " angajat id");
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void DeschideCazare_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                con.Open();
                sqlcmd = "select denumire from categorii_camere join tarife on tarife.id_categorie_camera=categorii_camere.Id where data_inceput <='" + DateTime.Today + "' and data_sfarsit > '" + DateTime.Today + "'";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "CategoriiCamere");

                if(ds.Tables["CategoriiCamere"].Rows.Count>0)
                {
                    foreach (DataRow categorieCamera in ds.Tables["CategoriiCamere"].Rows)
                    {
                        cbCategoriiCamere.Items.Add(categorieCamera["denumire"].ToString());
                    }
                    cbCategoriiCamere.SelectedIndex = 0;
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

            DataTable rezervari = new DataTable("Rezervari");
            ds.Tables.Add(rezervari);

            cbTipClient.Items.Add("Persoana fizica");
            cbTipClient.Items.Add("Persoana juridica");
            cbTipClient.SelectedIndex = 0;
            this.CenterToScreen();
        }

        private void btnContinua_Click(object sender, EventArgs e)
        {
            if (tabTipCazare.SelectedTab == tabFaraRezervare)
            {
                int numarNopti = Convert.ToInt32(nrNopti.Value);
                int numarOaspeti = Convert.ToInt32(nrOaspeti.Value);

                Cazare form = new Cazare(numarNopti, numarOaspeti,id_angajat);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else if (tabTipCazare.SelectedTab == tabCuRezervare)
            {
                string codIdentitate=tbCodIdentitate.Text;

                ds.Tables["Rezervari"].Clear();

                try
                {
                    con.Open();
                    if(cbTipClient.Text=="Persoana fizica")
                        sqlcmd = "select rezervari.id_rezervare, persoane_fizice.cnp from rezervari join persoane_fizice on rezervari.id_client=persoane_fizice.id_client where persoane_fizice.cnp='" + tbCodIdentitate.Text + "' and ((rezervari.data_inceput <= '" + DateTime.Now + "' or rezervari.data_inceput >= '" + DateTime.Now + "') and rezervari.data_sfarsit > '" + DateTime.Now + "') and rezervari.id_cazare is null";
                    else
                        sqlcmd = "select rezervari.id_rezervare, persoane_juridice.cui from rezervari join persoane_juridice on rezervari.id_client=persoane_juridice.id_client where persoane_juridice.cui='" + tbCodIdentitate.Text + "' and ((rezervari.data_inceput <= '" + DateTime.Now + "' or rezervari.data_inceput >= '" + DateTime.Now + "') and rezervari.data_sfarsit > '" + DateTime.Now + "') and rezervari.id_cazare is null";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "Rezervari");
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

                if (ds.Tables["Rezervari"].Rows.Count != 0)
                {
                    /*MessageBox.Show(ds.Tables["Rezervari"].Rows[0]["id_rezervare"].ToString());

                    Cazare istoricCazare = new Cazare(Convert.ToDateTime(cazareSelectata.Cells["checkin"].Value), Convert.ToDateTime(cazareSelectata.Cells["checkout"].Value), Convert.ToInt32(cazareSelectata.Cells["id_cazare"].Value), tipClient, Convert.ToInt32(cazareSelectata.Cells["nr_oaspeti"].Value));
                    this.Hide();
                    istoricCazare.ShowDialog();
                    this.Show();*/
                }
                else
                    MessageBox.Show("CNP-ul introdus nu are o rezervare");

                //se verifica daca exista rezervari cu codul de identitate introdus

                

                /*Cazare form = new Cazare(codIdentitate);
                this.Hide();
                form.ShowDialog();
                this.Show();*/
            }
        }

        private void cbTipClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipClient.SelectedIndex == 1)
                labelCNP.Text = "CUI:";
            else
                labelCNP.Text = "CNP:";
        }
    }
}
