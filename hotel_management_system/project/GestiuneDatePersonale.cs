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
    public partial class GestiuneDatePersonale : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";

        public GestiuneDatePersonale()
        {
            InitializeComponent();
        }

        private void GestiuneDatePersonale_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            cbTipPersoana.SelectedIndex = 0;
        }

        private void cbTipPersoana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipPersoana.SelectedIndex == 0)
            {
                groupBoxDateCont.Visible = false;
                tbPrenume.Visible = true;
                labelPrenume.Visible = true;
                labelCI.Text = "CNP:";
                btnCautaPersoana.Text = "Cauta dupa CNP";
                tbCodPostal.Visible = true;
                tbAdresa.Visible = true;
                labelCodPostal.Visible = true;
                labelAdresa.Visible = true;
            }
            else if(cbTipPersoana.SelectedIndex==1)
            {
                groupBoxDateCont.Visible = false;
                tbPrenume.Visible = false;
                labelPrenume.Visible = false;
                labelCI.Text = "CUI:";
                btnCautaPersoana.Text = "Cauta dupa CUI";
                tbCodPostal.Visible = true;
                tbAdresa.Visible = true;
                labelCodPostal.Visible = true;
                labelAdresa.Visible = true;
            }
            else if(cbTipPersoana.SelectedIndex==2)
            {
                groupBoxDateCont.Visible = true;
                tbPrenume.Visible = true;
                labelPrenume.Visible = true;
                labelCI.Text = "CNP:";
                btnCautaPersoana.Text = "Cauta dupa CNP";
                tbCodPostal.Visible = false;
                tbAdresa.Visible = false;
                labelCodPostal.Visible = false;
                labelAdresa.Visible = false;
            }
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            tbNume.Clear();
            tbPrenume.Clear();
            tbEmail.Clear();
            tbPrenume.Clear();
            tbTelefon.Clear();
            tbCodPostal.Clear();
            tbAdresa.Clear();
            tbIdCont.Clear();
            tbParolaCont.Clear();

            /*if (groupBoxDateCont.Visible == true)
                groupBoxDateCont.Visible = false;*/

            groupBoxDatePersonale.Enabled = false;

            cbTipPersoana.Enabled = true;
            btnCautaPersoana.Enabled = true;
            groupBoxDateCont.Enabled = false;
        }

        int id_client;
        private void btnCautaPersoana_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (cbTipPersoana.SelectedIndex == 0)
                {
                    sqlcmd = "select id_client, persoane_fizice.nume, persoane_fizice.prenume, email, telefon, adresa, cod_postal from clienti join persoane_fizice on persoane_fizice.id_client=clienti.id_client where persoane_fizice.cnp = '" + tbCI.Text + "'";
                }
                else if (cbTipPersoana.SelectedIndex == 1)
                {
                    sqlcmd = "select id_client, persoane_juridice.denumire, email, telefon, adresa, cod_postal from clienti join persoane_juridice on persoane_juridice.id_client=clienti.id_client where persoane_juridice.cui= '" + tbCI.Text + "'";
                }   
                else
                {
                    sqlcmd = "select id_angajat, nume, prenume, email, telefon from angajati where cnp = '" + tbCI.Text + "'";
                }
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "datePersonale");

                if(ds.Tables["datePersonale"].Rows.Count>0)
                {
                    if (cbTipPersoana.SelectedIndex == 0)
                    {
                        tbNume.Text = ds.Tables["datePersonale"].Rows[0]["nume"].ToString();
                        tbPrenume.Text = ds.Tables["datePersonale"].Rows[0]["prenume"].ToString();
                        tbEmail.Text = ds.Tables["datePersonale"].Rows[0]["email"].ToString();
                        tbCodPostal.Text = ds.Tables["datePersonale"].Rows[0]["cod_postal"].ToString();
                        tbTelefon.Text = ds.Tables["datePersonale"].Rows[0]["telefon"].ToString();
                        tbAdresa.Text = ds.Tables["datePersonale"].Rows[0]["adresa"].ToString();
                        groupBoxDatePersonale.Enabled = true;
                        btnCautaPersoana.Enabled = false;
                        cbTipPersoana.Enabled = false;
                        
                    }
                    else if (cbTipPersoana.SelectedIndex == 1)
                    {
                        tbNume.Text = ds.Tables["datePersonale"].Rows[0]["denumire"].ToString();
                        tbEmail.Text = ds.Tables["datePersonale"].Rows[0]["email"].ToString();
                        tbCodPostal.Text = ds.Tables["datePersonale"].Rows[0]["cod_postal"].ToString();
                        tbTelefon.Text = ds.Tables["datePersonale"].Rows[0]["telefon"].ToString();
                        tbAdresa.Text = ds.Tables["datePersonale"].Rows[0]["adresa"].ToString();
                        groupBoxDatePersonale.Enabled = true;
                        btnCautaPersoana.Enabled = false;
                        cbTipPersoana.Enabled = false;
                    }
                    else
                    {
                        groupBoxDateCont.Enabled = true;
                        tbNume.Text = ds.Tables["datePersonale"].Rows[0]["nume"].ToString();
                        tbPrenume.Text = ds.Tables["datePersonale"].Rows[0]["prenume"].ToString();
                        tbEmail.Text = ds.Tables["datePersonale"].Rows[0]["email"].ToString();
                        tbTelefon.Text = ds.Tables["datePersonale"].Rows[0]["telefon"].ToString();
                        groupBoxDatePersonale.Enabled = true;
                        btnCautaPersoana.Enabled = false;
                        cbTipPersoana.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Nu exista persoane inregistrate cu codul de identitate introdus");
                }
                ds.Tables["datePersonale"].Clear();

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message + " " + err.StackTrace);
            }
            finally
            {
                con.Close();
            }

            /*if(cbTipPersoana.SelectedIndex==2)
                groupBoxDateCont.Enabled = true;*/
        }

        private void btnUpdateDate_Click(object sender, EventArgs e)
        {
        }
    }
}
