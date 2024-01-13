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
    public partial class DeschideIstoricCazari : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        public DeschideIstoricCazari()
        {
            InitializeComponent();
        }

        private void DeschideIstoricCazari_Load(object sender, System.EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            cbTipClient.SelectedIndex = 0;
        }

        private void btnCautaCazari_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds.Tables.Contains("Cazari"))
                    ds.Tables["Cazari"].Clear();

                con.Open();
                if(cbTipClient.Text=="Persoana fizica")
                    sqlcmd = "select id_cazare, cazari.id_client, persoane_fizice.nume + ' ' + persoane_fizice.prenume as nume_client, checkin, checkout, mod_plata, total_achitat_lei, cazari.id_angajat, angajati.nume + ' '+ angajati.prenume as nume_angajat, nr_oaspeti from cazari join persoane_fizice on persoane_fizice.id_client = cazari.id_client join angajati on angajati.id_angajat=cazari.id_angajat where persoane_fizice.cnp='" + tbCI.Text + "'";
                else if(cbTipClient.Text=="Persoana juridica")
                    sqlcmd = "select id_cazare, persoane_juridice.denumire as nume_client, cazari.id_client, checkin, checkout, mod_plata, total_achitat_lei, cazari.id_angajat, angajati.nume + ' '+ angajati.prenume as nume_angajat, nr_oaspeti from cazari join persoane_juridice on persoane_juridice.id_client = cazari.id_client join angajati on angajati.id_angajat=cazari.id_angajat where persoane_juridice.cui='" + tbCI.Text + "'";

                //de facut sqlcmd pt pers juridica de extras numele
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "Cazari");

                if (ds.Tables["Cazari"].Rows.Count > 0)
                {
                    foreach (DataRow cazare in ds.Tables["Cazari"].Rows)
                    {
                        cazare["checkin"] = DateTime.Parse(cazare["checkin"].ToString()).Date;
                        cazare["checkout"] = DateTime.Parse(cazare["checkout"].ToString()).Date;
                    }

                    dgvCazari.DataSource = ds.Tables["Cazari"];

                    dgvCazari.Columns["id_cazare"].Visible = false;
                    dgvCazari.Columns["id_client"].Visible = false;
                    dgvCazari.Columns["nume_client"].HeaderText = "Nume client";
                    dgvCazari.Columns["checkin"].HeaderText = "Checkin";
                    dgvCazari.Columns["checkout"].HeaderText = "Checkout";
                    dgvCazari.Columns["mod_plata"].HeaderText = "Mod. plata";
                    dgvCazari.Columns["total_achitat_lei"].HeaderText = "Total achitat lei";
                    dgvCazari.Columns["id_angajat"].Visible = false;
                    dgvCazari.Columns["nume_angajat"].HeaderText = "Nume receptioner";
                    dgvCazari.Columns["nr_oaspeti"].HeaderText = "Nr. oaspeti";
                    
                    dgvCazari.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Clientul cu codul de identitate introdus nu exista sau nu are cazari.");
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
        }

        private void cbTipClient_TextChanged(object sender, System.EventArgs e)
        {
            if (cbTipClient.Text == "Persoana juridica")
            {
                labelCI.Text = "CUI:";
                btnCautaCazari.Text = "Cauta cazari dupa CUI";
            }
            else
            {
                labelCI.Text = "CNP:";
                btnCautaCazari.Text = "Cauta cazari dupa CNP";
            }
            
        }
        DataGridViewRow cazareSelectata;
        private void btnDetaliiCazare_Click(object sender, System.EventArgs e)
        {
            if (dgvCazari.SelectedRows.Count > 0)
            {
                cazareSelectata = dgvCazari.Rows[dgvCazari.CurrentCell.RowIndex];
                string tipClient = cbTipClient.Text;
                Cazare istoricCazare = new Cazare(Convert.ToDateTime(cazareSelectata.Cells["checkin"].Value), Convert.ToDateTime(cazareSelectata.Cells["checkout"].Value), Convert.ToInt32(cazareSelectata.Cells["id_cazare"].Value), tipClient, Convert.ToInt32(cazareSelectata.Cells["nr_oaspeti"].Value));
                //MessageBox.Show("Id cazare: " + cazareSelectata.Cells["id_cazare"].Value.ToString() + "\ndata inceput: " + cazareSelectata.Cells["checkin"].Value.ToString() + "\ndata sfarsit: " + cazareSelectata.Cells["checkout"].Value.ToString());
                this.Hide();
                istoricCazare.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Nu ai selectat o cazare");
                
            //

        }
    }
}
