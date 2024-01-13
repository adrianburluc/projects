using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.App
{
    public partial class AlocarePaturi : Form
    {
        public AlocarePaturi()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void AlocarePaturi_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            sqlcmd = "select denumire from categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "CategoriiCamere");

            sqlcmd = "select denumire from paturi";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Paturi");

            sqlcmd = "select (select denumire from categorii_camere where id=paturi_categorii_camere.id_categorie_camera), (select denumire from paturi where id_tip_pat=paturi_categorii_camere.id_tip_pat), nr_paturi from paturi_categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "PaturiTipCamere");

            con.Close();

            foreach (DataRow row in ds.Tables["CategoriiCamere"].Rows)
            {
                listBoxTipCamere.Items.Add(row[0].ToString());
            }

            foreach (DataRow row in ds.Tables["Paturi"].Rows)
            {
                cbTipPat.Items.Add(row[0].ToString());
            }

            if (cbTipPat.Items.Count != 0)
            {
                cbTipPat.SelectedIndex = 0;
            }

            this.CenterToScreen();
        }

        private void listBoxTipCamere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTipCamere.SelectedIndex != -1)
            {
                listBoxTipPaturi.Items.Clear();
                foreach (DataRow row in ds.Tables["PaturiTipCamere"].Rows)
                {
                    if (row[0].ToString() == listBoxTipCamere.SelectedItem.ToString())
                    {
                        listBoxTipPaturi.Items.Add(row[2].ToString()+"x "+ row[1].ToString());
                    }
                }
            }
        }

        private void listBoxTipPaturi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string optiune = listBoxTipPaturi.SelectedItem.ToString();
            string[] separator = new string[] {"x "};
            string[] result;

            result=optiune.Split(separator,StringSplitOptions.None);

            numericNrPaturi.Value = Convert.ToInt32(result.GetValue(0));
            cbTipPat.Text = result.GetValue(1).ToString();
        }

        private void buttonAdaugaPat_Click(object sender, EventArgs e)
        {
            //1. se verifica daca s-a selectat un tip de camera
            if (listBoxTipCamere.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati un tip de camera pentru a aloca paturi!", "Alocare paturi");
            }
            else
            {
                //2. se verifica daca patul selectat exista deja in lista
                bool item_gasit = false;
                int nr_paturi=0;
                string denumire_pat=null;
                int index_pat=-1;
                string[] result;
                foreach (var item in listBoxTipPaturi.Items)
                {
                    int index_separator = item.ToString().IndexOf("x ");
                    if (item.ToString().Substring(index_separator + 2) == cbTipPat.SelectedItem.ToString())
                    {
                        item_gasit = true;
                        index_pat = listBoxTipPaturi.Items.IndexOf(item.ToString());

                        //salveaza datele patului gasit
                        string detalii_pat = item.ToString();
                        string[] separator = new string[] { "x " };

                        result = detalii_pat.Split(separator, StringSplitOptions.None);

                        nr_paturi = Convert.ToInt32(result.GetValue(0));
                        denumire_pat = result.GetValue(1).ToString();

                        break;
                    }
                }
                if (item_gasit == true)
                {
                    string morfologie_paturi_gasite = "paturi";

                    if (nr_paturi == 1)
                    {
                        morfologie_paturi_gasite = "pat";
                    }

                    string morfologie_paturi_introduse = "paturi";
                    if (numericNrPaturi.Value == 1)
                    {
                        morfologie_paturi_introduse = "pat";
                    }
                    raspunsDialog = MessageBox.Show(listBoxTipCamere.SelectedItem.ToString()+" are deja "+nr_paturi+" "+morfologie_paturi_gasite+" de tip '"+denumire_pat.ToLower()+"'!\n\nDoriti sa mai adaugati "+numericNrPaturi.Value+" "+morfologie_paturi_introduse+"?", "Alocare paturi", MessageBoxButtons.YesNo);

                    if (raspunsDialog == DialogResult.Yes)
                    {
                        //2.1. se actualizeaza item-ul din lista paturilor camerei
                        //2.2. se face update modificand doar cantitatea aferenta
                        //MessageBox.Show("UPDATE!", "Alocare paturi");
                        try
                        {
                            sqlcmd = "update paturi_categorii_camere set nr_paturi='" + (numericNrPaturi.Value + nr_paturi) + "' where id_categorie_camera=(select Id from categorii_camere where denumire = '" + listBoxTipCamere.SelectedItem.ToString() + "') and id_tip_pat=(select id_tip_pat from paturi where denumire = '" + cbTipPat.Text + "')";
                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Modificat!", "Alocare paturi");

                            ds.Tables["PaturiTipCamere"].Clear();
                            sqlcmd = "select (select denumire from categorii_camere where id=paturi_categorii_camere.id_categorie_camera), (select denumire from paturi where id_tip_pat=paturi_categorii_camere.id_tip_pat), nr_paturi from paturi_categorii_camere";
                            da = new SqlDataAdapter(sqlcmd, con);
                            da.Fill(ds, "PaturiTipCamere");

                            if (index_pat != -1)
                            {
                                listBoxTipPaturi.Items[index_pat] = (nr_paturi + numericNrPaturi.Value) + "x " + denumire_pat;
                            }

                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
                else
                {
                    //2.3 se adauga in lista si se face insert in tabel
                    //MessageBox.Show("INSERT!", "Alocare paturi");

                    string morfologie_paturi_introduse="paturi";
                    if (numericNrPaturi.Value == 1)
                    {
                        morfologie_paturi_introduse = "pat";
                    }

                    raspunsDialog = MessageBox.Show("Doriti sa adaugati "+numericNrPaturi.Value+" "+morfologie_paturi_introduse+" de tip '"+cbTipPat.SelectedItem.ToString()+"'", "Alocare paturi", MessageBoxButtons.YesNo);

                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            sqlcmd = "insert into paturi_categorii_camere values((select Id from categorii_camere where denumire = '" + listBoxTipCamere.SelectedItem.ToString() + "'), (select id_tip_pat from paturi where denumire = '" + cbTipPat.Text + "'), '" + numericNrPaturi.Value + "')";
                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Adaugat!", "Alocare paturi");

                            ds.Tables["PaturiTipCamere"].Clear();
                            sqlcmd = "select (select denumire from categorii_camere where id=paturi_categorii_camere.id_categorie_camera), (select denumire from paturi where id_tip_pat=paturi_categorii_camere.id_tip_pat), nr_paturi from paturi_categorii_camere";
                            da = new SqlDataAdapter(sqlcmd, con);
                            da.Fill(ds, "PaturiTipCamere");

                            listBoxTipPaturi.Items.Add(numericNrPaturi.Value + "x " + cbTipPat.Text);
                            //listBoxTipPaturi.Sorted = true;

                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
        }

        private void buttonStergePat_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificaPat_Click(object sender, EventArgs e)
        {
            if (listBoxTipPaturi.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati tipul de pat pentru a putea modifica numarul de paturi!", "Modificare numar paturi");
            }
            else
            {
                if (listBoxTipPaturi.SelectedItem.ToString() == (numericNrPaturi.Value + "x " + cbTipPat.Text))
                {
                    MessageBox.Show("Nu ati modificat numarul pentru a putea actualiza!","Modificare numar paturi");
                }
                else
                {
                    raspunsDialog = MessageBox.Show("Doriti sa modificati numarul de paturi pentru tipul de pat selectat cu "+numericNrPaturi.Value+"", "Modificare numar paturi", MessageBoxButtons.YesNo);

                    if (raspunsDialog == DialogResult.No)
                    {
                        MessageBox.Show("Anulat!", "Adaugare paturi");
                    }
                    else
                    { }

                }
            }
        }
    }
}
