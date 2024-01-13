using System;
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
    public partial class DeschideIstoricRezervari : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        public DeschideIstoricRezervari()
        {
            InitializeComponent();
        }

        private void DeschideIstoricRezervari_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            cbTipClient.SelectedIndex = 0;
        }

        private void btnCautaRezervari_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (ds.Tables.Contains("Rezervari"))
                    ds.Tables["Rezervari"].Clear();

                con.Open();
                if (cbTipClient.Text == "Persoana fizica")
                    sqlcmd = "select rezervari.id_rezervare, rezervari.id_client, persoane_fizice.nume + ' ' + persoane_fizice.prenume as nume_client, data_rezervare, data_inceput as checkin, data_sfarsit as checkout, rezervari.id_angajat, angajati.nume + ' '+ angajati.prenume as nume_angajat, nr_oaspeti from rezervari join persoane_fizice on persoane_fizice.id_client = rezervari.id_client join angajati on angajati.id_angajat=rezervari.id_angajat where persoane_fizice.cnp='" + tbCI.Text + "'";
                else if (cbTipClient.Text == "Persoana juridica")
                    sqlcmd = "select rezervari.id_rezervare, rezervari.id_client, persoane_juridice.denumire as nume_client, data_rezervare, data_inceput as checkin, data_sfarsit as checkout, rezervari.id_angajat, angajati.nume + ' '+ angajati.prenume as nume_angajat, nr_oaspeti from rezervari join persoane_juridice on persoane_juridice.id_client = rezervari.id_client join angajati on angajati.id_angajat=rezervari.id_angajat where persoane_juridice.cui='" + tbCI.Text + "'";

                //de facut sqlcmd pt pers juridica de extras numele
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "Rezervari");

                if (ds.Tables["Rezervari"].Rows.Count > 0)
                {
                    foreach (DataRow cazare in ds.Tables["Rezervari"].Rows)
                    {
                        cazare["checkin"] = DateTime.Parse(cazare["checkin"].ToString()).Date;
                        cazare["checkout"] = DateTime.Parse(cazare["checkout"].ToString()).Date;
                    }

                    dgvRezervari.DataSource = ds.Tables["Rezervari"];

                    dgvRezervari.Columns["id_rezervare"].Visible = false;
                    dgvRezervari.Columns["id_client"].Visible = false;
                    dgvRezervari.Columns["nume_client"].HeaderText = "Nume client";
                    dgvRezervari.Columns["data_rezervare"].HeaderText = "Data rezervarii";
                    dgvRezervari.Columns["checkin"].HeaderText = "Checkin";
                    dgvRezervari.Columns["checkout"].HeaderText = "Checkout";
                    dgvRezervari.Columns["id_angajat"].Visible = false;
                    dgvRezervari.Columns["nume_angajat"].HeaderText = "Nume receptioner";

                    dgvRezervari.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Clientul cu codul de identitate introdus nu exista sau nu are cazari.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message+" "+err.StackTrace);
            }
            finally
            {
                con.Close();
            }
        }
        

        private void cbTipClient_TextChanged(object sender, System.EventArgs e)
        {
            if (cbTipClient.Text == "Persoana juridica")
            {
                labelCI.Text = "CUI:";
                btnCautaRezervari.Text = "Cauta rezervari dupa CUI";
            }
            else
            {
                labelCI.Text = "CNP:";
                btnCautaRezervari.Text = "Cauta rezervari dupa CNP";
            }
        }

        DataGridViewRow rezervareSelectata;
        private void btnDetaliiRezervare_Click(object sender, System.EventArgs e)
        {
            if (dgvRezervari.SelectedRows.Count > 0)
            {
                rezervareSelectata = dgvRezervari.Rows[dgvRezervari.CurrentCell.RowIndex];
                string tipClient = cbTipClient.Text;
                //Cazare istoricCazare = new Cazare(Convert.ToDateTime(cazareSelectata.Cells["checkin"].Value), Convert.ToDateTime(cazareSelectata.Cells["checkout"].Value), Convert.ToInt32(cazareSelectata.Cells["id_cazare"].Value), tipClient, Convert.ToInt32(cazareSelectata.Cells["nr_oaspeti"].Value));
                //MessageBox.Show("Id cazare: " + cazareSelectata.Cells["id_cazare"].Value.ToString() + "\ndata inceput: " + cazareSelectata.Cells["checkin"].Value.ToString() + "\ndata sfarsit: " + cazareSelectata.Cells["checkout"].Value.ToString());
                MessageBox.Show("ID rezervare: "+Convert.ToString(rezervareSelectata.Cells["id_rezervare"].Value)+"\nData inceput: "+Convert.ToString(rezervareSelectata.Cells["checkin"].Value)+"\nData sfarsit: "+Convert.ToString(rezervareSelectata.Cells["checkout"].Value)+"\nNr oaspeti: "+Convert.ToString(rezervareSelectata.Cells["nr_oaspeti"].Value));
                Rezervare istoricRezervare = new Rezervare(Convert.ToInt32(rezervareSelectata.Cells["id_rezervare"].Value), Convert.ToDateTime(rezervareSelectata.Cells["checkin"].Value), Convert.ToDateTime(rezervareSelectata.Cells["checkout"].Value), Convert.ToInt32(rezervareSelectata.Cells["nr_oaspeti"].Value), "istoric",cbTipClient.Text);
                this.Hide();
                istoricRezervare.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Nu ai selectat o cazare");
        }
    }
}
