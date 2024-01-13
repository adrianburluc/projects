﻿using System;
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
    public partial class GestiuneReduceriClienti : Form
    {
        public GestiuneReduceriClienti()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void GestiuneReduceriClienti_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            
            try
            {
                con.Open();
                sqlcmd = "select tip_client as Id, cod_reducere, procent, data_inceput, data_sfarsit from reduceri where tip_client is not null";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "Reduceri");

                sqlcmd = "select tip_client, categorie from categorii_clienti";
                da = new SqlDataAdapter(sqlcmd, con);
                da.Fill(ds, "CategoriiClienti");

                cbTipClient.SelectedIndex = 0;

                /*foreach (DataRow categorieClient in ds.Tables["CategoriiClienti"].Rows)
                {
                    if(categorieClient["categorie"].ToString()==cbTipClient.Text)
                    {
                        listBoxCategoriiClienti.Items.Add(categorieClient["tip_client"].ToString());
                    }
                }*/

                dgvReduceriProgramate.DataSource = ds.Tables["Reduceri"];
                
                dgvReduceriProgramate.Columns[0].Visible = false;
                dgvReduceriProgramate.Columns[1].Visible = false;
                dgvReduceriProgramate.Columns[2].ValueType = typeof(System.Int32);
                //dgvTarifeProgramate.Columns[3].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
                //dgvTarifeProgramate.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";

                dateFiltruDataSfarsit.Checked = false;
                dateFiltruDataSfarsit.MinDate = dateFiltruDataInceput.Value;

                tabControl1.SelectedTab = tabControl1.TabPages[1];
                tabControl1.SelectedTab = tabControl1.TabPages[0];

                dataDiscountInceput.MinDate = DateTime.Today;
                dataDiscountSfarsit.MinDate = dataDiscountInceput.Value.AddDays(1);
                dataDiscountSfarsit.Value = dataDiscountInceput.Value.AddDays(1);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message + " " + err.StackTrace);
            }
            finally
            {
                con.Close();
            }

            this.CenterToScreen();
        }

        DataRow discountCurent = null;
        DataRow discountProgramat = null;
        private void listBoxCategoriiClienti_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cand se selecteaza o camera, se vor returna tariful curent si tariful programat (daca exista)
            numericDiscount.Value = 0;

            var viewTabelTarife = ds.Tables["Reduceri"].DefaultView;
            viewTabelTarife.RowFilter = "Id='" + listBoxCategoriiClienti.SelectedItem.ToString() + "'";
            viewTabelTarife.Sort = "data_sfarsit DESC";

            //returnare tarif curent
            discountCurent = ds.Tables["Reduceri"].Select("Id='" + listBoxCategoriiClienti.SelectedItem.ToString() + "' AND data_inceput<= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();

            labelCategorieClient.Text = listBoxCategoriiClienti.SelectedItem.ToString();

            dgvReduceriProgramate.ClearSelection();

            //returnare tarif programat
            discountProgramat = ds.Tables["Reduceri"].Select("Id='" + listBoxCategoriiClienti.SelectedItem.ToString() + "' AND data_inceput>= '" + DateTime.Now.ToString() + "' AND data_sfarsit> '" + DateTime.Now.ToString() + "'").FirstOrDefault();

            if (discountCurent != null)
            {
                //labelTarif.Text = ((decimal)tarifCurent[2]).ToString("0.####") + " lei";
                labelReducere.Text = discountCurent[2].ToString() + "%";
                if (labelValabilPanaPe.Visible == false)
                    labelValabilPanaPe.Visible = true;
                labelValabilPanaPe.Text = "Valabila pana pe: " + DateTime.Parse(discountCurent[4].ToString()).ToShortDateString();

                string data = ((DateTime)discountCurent[4]).ToShortDateString();
                //evidentiazaTarifActual();
            }
            else
            {
                labelReducere.Text = "0%";

                if (labelValabilPanaPe.Visible == true)
                    labelValabilPanaPe.Visible = false;
            }
        }

        private void cbTipClient_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxCategoriiClienti.Items.Clear();
            foreach (DataRow categorieClient in ds.Tables["CategoriiClienti"].Rows)
            {
                if (categorieClient["categorie"].ToString() == cbTipClient.Text)
                {
                    listBoxCategoriiClienti.Items.Add(categorieClient["tip_client"].ToString());
                }
            }
        }

        private void buttonSeteazaReducere_Click(object sender, EventArgs e)
        {
            if (numericDiscount.Value == 0)
                MessageBox.Show("Nu ati introdus un procent de reducere!");
            else
            {
                //a.	daca exista deja un discount setat pentru intervalul dorit, este avertizat sa verifice discounturile sa nu se suprapuna
                try
                {
                    //se verifica daca exista reduceri in intervalul introdus
                    DataTable reduceriIntersectate = new DataTable();
                    con.Open();
                    sqlcmd = "select procent, data_inceput, data_sfarsit from reduceri where tip_client='" + listBoxCategoriiClienti.SelectedItem.ToString() + "' and ((data_inceput<='" + dataDiscountInceput.Value.ToString("yyyy-MM-dd") + "' and data_sfarsit > '" + dataDiscountInceput.Value.ToString("yyyy-MM-dd") + "') or (data_inceput >= '" + dataDiscountInceput.Value.ToString("yyyy-MM-dd") + "' and data_inceput < '" + dataDiscountSfarsit.Value.ToString("yyyy-MM-dd") + "'))";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(reduceriIntersectate);

                    //MessageBox.Show(listBoxCategoriiClienti.SelectedItem.ToString() + " " + dataDiscountInceput.Value.ToString("yyyy-MM-dd") + " " + dataDiscountSfarsit.Value.ToString("yyyy-MM-dd"));

                    if (reduceriIntersectate.Rows.Count == 0)
                    {
                        raspunsDialog = MessageBox.Show("Doriti sa inregistrati urmatorul discount pentru " + listBoxCategoriiClienti.SelectedItem.ToString() + "?\n\nProcent: " + numericDiscount.Value.ToString() + "%  (Data inceput: " + DateTime.Parse(dataDiscountInceput.Value.ToString()).ToShortDateString() + " - Data sfarsit: " + DateTime.Parse(dataDiscountSfarsit.Value.ToString()).ToShortDateString() + ")", "Inregistrare discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (raspunsDialog == DialogResult.Yes)
                        {
                            //se insereaza reducerea
                            //se obtine codul de reducere
                            string codDiscountNou;
                            string tipClient = listBoxCategoriiClienti.SelectedItem.ToString();

                            DataRow ultimulDiscount = ds.Tables["Reduceri"].Select("cod_reducere Like '%R_CL" + tipClient + "_%'", "cod_reducere DESC").FirstOrDefault();

                            if (ultimulDiscount != null)
                            {
                                string ultimulCodReducere = ultimulDiscount["cod_reducere"].ToString();
                                int idReducere = Convert.ToInt32(ultimulCodReducere.Substring(ultimulCodReducere.LastIndexOf('_') + 1));
                                codDiscountNou = "R_CL" + tipClient + "_" + (idReducere + 1).ToString();
                            }
                            else
                            {
                                codDiscountNou = "R_CL" + tipClient + "_1";
                            }

                            sqlcmd = "insert into reduceri values ('" + codDiscountNou + "','" + numericDiscount.Value.ToString() + "','" + DateTime.Parse(dataDiscountInceput.Value.ToString()).ToShortDateString() + "','" + DateTime.Parse(dataDiscountSfarsit.Value.ToString()).ToShortDateString() + "',NULL,'" + tipClient + "')";
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow discountNou = ds.Tables["Reduceri"].NewRow();
                            discountNou["Id"] = tipClient;
                            discountNou["cod_reducere"] = codDiscountNou;
                            discountNou["procent"] = numericDiscount.Value.ToString();
                            discountNou["data_inceput"] = DateTime.Parse(dataDiscountInceput.Value.ToString()).ToShortDateString();
                            discountNou["data_sfarsit"] = DateTime.Parse(dataDiscountSfarsit.Value.ToString()).ToShortDateString();

                            ds.Tables["Reduceri"].Rows.Add(discountNou);

                            ds.Tables["Reduceri"].AcceptChanges();

                            MessageBox.Show("Introdus!");
                        }

                        //sqlcmd = "insert into reduceri values('"++"', '"++"', '"++"', '"++"')";
                        //MessageBox.Show(codDiscountNou + " " + numericDiscount.Value.ToString() + " " + dataDiscountInceput.Value.ToShortDateString() + " " + dataDiscountSfarsit.Value.ToShortDateString());
                    }
                    else
                    {
                        string mesaj = "Atentie! Reducerea nu poate fi inregistrata deoarece se intersecteaza cu alte reduceri:\n\n";

                        int nrMesaje = reduceriIntersectate.Rows.Count;

                        if (reduceriIntersectate.Rows.Count > 5)
                            nrMesaje = 5;

                        for (int i = 0; i < nrMesaje; i++)
                        {
                            mesaj = mesaj + (i + 1).ToString() + ". Procent: " + reduceriIntersectate.Rows[i]["procent"] + "%  (Data inceput: " + DateTime.Parse(reduceriIntersectate.Rows[i]["data_inceput"].ToString()).ToShortDateString() + " - Data sfarsit: " + DateTime.Parse(reduceriIntersectate.Rows[i]["data_sfarsit"].ToString()).ToShortDateString() + ")\n";
                        }

                        MessageBox.Show(mesaj, "Eroare inregistrare discount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void dataDiscountInceput_ValueChanged(object sender, EventArgs e)
        {
            dataDiscountSfarsit.MinDate = dataDiscountInceput.Value.AddDays(1);
            labelNrZile.Text = ((DateTime.Parse(dataDiscountSfarsit.Value.ToShortDateString()) - DateTime.Parse(dataDiscountInceput.Value.ToShortDateString())).Days).ToString() + " zile";
        }

        private void dataDiscountSfarsit_ValueChanged(object sender, EventArgs e)
        {
            labelNrZile.Text = ((DateTime.Parse(dataDiscountSfarsit.Value.ToShortDateString()) - DateTime.Parse(dataDiscountInceput.Value.ToShortDateString())).Days).ToString() + " zile";
        }

        private void buttonAplicaFiltru_Click(object sender, EventArgs e)
        {
            string testTime = "5/1/2021";
            DateTime date2 = DateTime.Parse(testTime);


            ds.Tables[0].DefaultView.RowFilter = "";
            string filtru = "Id='" + listBoxCategoriiClienti.SelectedItem.ToString() + "' AND data_sfarsit> '" + dateFiltruDataInceput.Value.ToShortDateString() + "'";

            if (dateFiltruDataSfarsit.Checked == true)
            {
                filtru = "Id='" + listBoxCategoriiClienti.SelectedItem.ToString() + "' AND (('" + dateFiltruDataInceput.Value.ToShortDateString() + "' >= data_inceput AND '" + dateFiltruDataInceput.Value.ToShortDateString() + "' < data_sfarsit) OR (data_inceput >= '" + dateFiltruDataInceput.Value.ToShortDateString() + "' AND data_inceput <= '" + dateFiltruDataSfarsit.Value.ToShortDateString() + "'))";
            }

            ds.Tables[0].DefaultView.RowFilter = filtru;
            ds.Tables[0].DefaultView.Sort = "data_sfarsit DESC";
        }

        private void buttonResetFiltru_Click(object sender, EventArgs e)
        {
            ds.Tables[0].DefaultView.RowFilter = "Id='" + listBoxCategoriiClienti.SelectedItem.ToString()+"'";
            ds.Tables[0].DefaultView.Sort = "data_sfarsit DESC";
        }

        DataGridViewRow discountSelectat = null;
        private void buttonAnuleazaDiscount_Click(object sender, EventArgs e)
        {
            //1.	Daca este sters inainte sa inceapa atunci se sterge complet din baza de date

            if (discountSelectat != null)
            {
                DateTime date = DateTime.Parse("07/28/2021");

                if (date < DateTime.Parse(dgvReduceriProgramate.SelectedRows[0].Cells["data_inceput"].Value.ToString()))
                {
                    //MessageBox.Show("trebuie sters");
                    raspunsDialog = MessageBox.Show("Discountul selectat este programat incepand cu data de " + DateTime.Parse(dgvReduceriProgramate.SelectedRows[0].Cells["data_inceput"].Value.ToString()).ToShortDateString() + ".\n\nDoriti sa anulati discountul?", "Anulare discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {

                            con.Open();
                            sqlcmd = "delete from reduceri where cod_reducere='" + discountSelectat.Cells[1].Value.ToString() + "'";
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow discountDeSters = ds.Tables["Reduceri"].Select("cod_reducere='" + discountSelectat.Cells[1].Value.ToString() + "'").FirstOrDefault();
                            ds.Tables["Reduceri"].Rows.Remove(discountDeSters);
                            ds.Tables["Reduceri"].AcceptChanges();

                            discountSelectat = null;
                            dgvReduceriProgramate.ClearSelection();

                            MessageBox.Show("Sters!");
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
                else if (date >= DateTime.Parse(dgvReduceriProgramate.SelectedRows[0].Cells["data_inceput"].Value.ToString()) && date < DateTime.Parse(dgvReduceriProgramate.SelectedRows[0].Cells["data_sfarsit"].Value.ToString()))
                {
                    raspunsDialog = MessageBox.Show("Discountul selectat este activ.\n\nDoriti sa setati data sfarsit in " + DateTime.Today.AddDays(1).ToShortDateString() + "?", "Anulare discount", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (raspunsDialog == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            sqlcmd = "update reduceri set data_sfarsit='" + DateTime.Now + "' where cod_reducere='" + discountSelectat.Cells[1].Value.ToString() + "'";
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            DataRow discountDeSters = ds.Tables["Reduceri"].Select("cod_reducere='" + discountSelectat.Cells[1].Value.ToString() + "'").FirstOrDefault();

                            discountDeSters["data_sfarsit"] = DateTime.Today.ToShortDateString();
                            ds.Tables["Reduceri"].AcceptChanges();

                            labelReducere.Text = "0%";
                            labelValabilPanaPe.Visible = false;

                            discountSelectat = null;
                            dgvReduceriProgramate.ClearSelection();

                            MessageBox.Show("Finalizat!");
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
                    MessageBox.Show("Discountul selectat nu poate fi anulat deoarece nu mai este activ.", "Anulare discount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("Nu ati selectat un discount");
            //2.	Daca este sters in timpul reducerii atunci se face update data sfarsit din 30 in 10: data_inceput 8, data_sfarsit 10
        }

        private void dateFiltruDataInceput_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("modificat");
            dateFiltruDataSfarsit.MinDate = dateFiltruDataInceput.Value.AddDays(1);
            dateFiltruDataSfarsit.Value = dateFiltruDataInceput.Value.AddDays(1);
        }

        private void dgvReduceriProgramate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                discountSelectat = dgvReduceriProgramate.Rows[dgvReduceriProgramate.CurrentCell.RowIndex];

            }
        }
    }
}
