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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd="";
        DialogResult raspunsDialog;
             
        public Form1()
        {
            InitializeComponent();
        }

        public bool gasesteUtilitateInLista(string utilitate,Control lista)
        {
            if(lista is ListBox)
            {
                foreach (var item in (lista as ListBox).Items)
                {
                    if (item.ToString().ToUpper() == utilitate.ToUpper())
                    {
                        return true;
                    }
                }
            }
            else if (lista is ComboBox)
            {
                foreach (var item in (lista as ComboBox).Items)
                {
                    if (item.ToString().ToUpper() == utilitate.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void updateDsTipCamere()
        {
            ds.Tables["CategoriiCamere"].Clear();
            sqlcmd = "select denumire, nr_persoane, nr_paturi, tip_pat, dimensiune from categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "CategoriiCamere");
        }

        public void updateDsUtilitati()
        {
            ds.Tables["Utilitati"].Clear();
            sqlcmd = "select * from utilitati";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Utilitati");
        }

        public void updateDsUtilitatiCamere()
        {
            ds.Tables["UtilitatiCamere"].Clear();
            sqlcmd = "select (select denumire from categorii_camere where categorii_camere.id=utilitati_camere.id_categorie_camera), (select denumire from utilitati where id=utilitati_camere.id_utilitate) from utilitati_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "UtilitatiCamere");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            sqlcmd = "select denumire, nr_persoane, nr_paturi, tip_pat, dimensiune from categorii_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "CategoriiCamere");

            sqlcmd = "select (select denumire from categorii_camere where categorii_camere.id=utilitati_camere.id_categorie_camera), (select denumire from utilitati where id=utilitati_camere.id_utilitate) from utilitati_camere";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "UtilitatiCamere");

            sqlcmd = "select * from utilitati";
            da = new SqlDataAdapter(sqlcmd, con);
            da.Fill(ds, "Utilitati");

            con.Close();

            //adaug tipul camerelor in lista
            foreach (DataRow dr in ds.Tables["CategoriiCamere"].Rows)
            {
                listBoxTipCamere.Items.Add(dr[0]);
            }

            //adauga toate utilitatile disponibile in lista utilitati si combobox utilitati camere
            foreach (DataRow dr in ds.Tables["Utilitati"].Rows)
            {
                cbUtilitati.Items.Add(dr[1].ToString());
                listBoxUtilitati.Items.Add(dr[1].ToString());
            }

            //selecteaza prima camera onload
            if(listBoxTipCamere.Items.Count!=0)
            {
                listBoxTipCamere.SelectedIndex = 0;
            }

            cbTipPat.Text = "Single";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //lista pentru verificarea utilitatilor care se regasesc in lista utilitati camere si in combo box
        List<string> lista_utilitati_duplicate = new List<string>();
        private void listBoxTipCamere_SelectedValueChanged(object sender, EventArgs e)
        {
            btnDeleteUtilitate.Enabled = false;

            if (listBoxTipCamere.SelectedIndex != -1)
            {
                foreach (DataRow dr in ds.Tables["CategoriiCamere"].Rows)
                {
                    //cand camera selectata corespunde cu inregistrarea din tabelul din setul de date
                    if (dr[0].ToString() == listBoxTipCamere.SelectedItem.ToString() && listBoxTipCamere.SelectedItem != null)
                    {
                        //completeaza dataliile camerei selectate
                        textBoxDenumire.Text = dr[0].ToString();
                        numericNrPers.Value = Convert.ToInt32(dr[1]);
                        numericNrPaturi.Value = Convert.ToInt32(dr[2]);
                        cbTipPat.Text = dr[3].ToString();
                        numericDimensiuni.Value = Convert.ToInt32(dr[4]);

                        //completeaza lista utilitatilor aferente camerei selectate
                        listBoxUtilitatiCamera.Items.Clear();
                        foreach (DataRow dr2 in ds.Tables["UtilitatiCamere"].Rows)
                        {
                            if (dr2[0].ToString() == listBoxTipCamere.SelectedItem.ToString())
                            {
                                listBoxUtilitatiCamera.Items.Add(dr2[1].ToString());
                            }
                        }

                        //sterge si adauga din nou toate utilitatile disponibile in combobox
                        //pentru cazul in care se modifica dataset-ul
                        cbUtilitati.Items.Clear();
                        lista_utilitati_duplicate.Clear();
                        foreach (DataRow dr3 in ds.Tables["Utilitati"].Rows)
                        {
                            cbUtilitati.Items.Add(dr3[1].ToString());
                        }

                        //memoreaza intr-o lista toate utilitatile din combobox care se regasesc si in lista utilitatilor camerei selectate
                        foreach (var item in cbUtilitati.Items)
                        {
                            foreach (var item2 in listBoxUtilitatiCamera.Items)
                            {
                                if (item.ToString() == item2.ToString())
                                {
                                    lista_utilitati_duplicate.Add(item.ToString());
                                }
                            }
                        }

                        //sterge din combobox-ul utilitatilor pe cele care se repeta pentru a le lasa doar pe cele nefolosite
                        foreach (string utilitate in lista_utilitati_duplicate)
                        {
                            cbUtilitati.Items.Remove(utilitate);
                        }

                        //daca camera nu are toate utilitatile disponibile se va putea selecta din utilitatile ramase
                        if (cbUtilitati.Items.Count != 0)
                        {
                            cbUtilitati.Enabled = true;
                            cbUtilitati.SelectedIndex = 0;
                        }
                        else //daca le are pe toate, controlul se va dezactiva 
                        {
                            cbUtilitati.Enabled = false;
                        }

                        //daca exista utilitati de adaugat atunci se va activa si butonul pentru a le adauga
                        if (cbUtilitati.Enabled)
                        {
                            btnAdaugaUtilitateCamera.Enabled = true;
                        }
                        else
                        {
                            btnAdaugaUtilitateCamera.Enabled = false;
                        }
                        break;
                    }
                }
            }
        }

        private void listBoxUtilitatiCamera_SelectedValueChanged(object sender, EventArgs e)
        {
            //daca s-a selectat o utilitate aferenta unei camere, se activeaza butonul pentru stergere
            if(listBoxUtilitatiCamera.SelectedIndex!=-1)
            {
                btnDeleteUtilitate.Enabled = true;
            }
        }

        private void btnDeleteUtilitate_Click(object sender, EventArgs e)
        {
            try
            {
                //se sterge dupa id-ul tipului de camera si id-ul aferent utilitatii selectate
                sqlcmd = "delete from utilitati_camere where id_categorie_camera=(select id from categorii_camere where denumire='" + listBoxTipCamere.SelectedItem.ToString() + "') and id_utilitate=(select id from utilitati where denumire='" + listBoxUtilitatiCamera.SelectedItem.ToString() + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                cmd.ExecuteNonQuery();

                updateDsUtilitatiCamere();

                //se actualizeaza combobox si lista utilitatilor camerei selectate
                cbUtilitati.Items.Add(listBoxUtilitatiCamera.SelectedItem.ToString());
                listBoxUtilitatiCamera.Items.RemoveAt(listBoxUtilitatiCamera.SelectedIndex);
                
                //daca controlul era dezactivat, se va activa
                if(cbUtilitati.Enabled == false)
                {
                    cbUtilitati.Enabled = true;
                }

                //daca camera selectata mai are utilitati, dupa stergere se va selecta prima utilitate
                //daca butonul adauga a fost dezactivat inainte ca lista sa aibe nicio utilitate, se va activa inapoi
                if(listBoxUtilitatiCamera.Items.Count!=0)
                {
                    listBoxUtilitatiCamera.SelectedIndex = 0;
                    if(btnAdaugaUtilitateCamera.Enabled == false)
                    {
                        btnAdaugaUtilitateCamera.Enabled = true;
                    }
                }
                else
                {
                    btnDeleteUtilitate.Enabled = false;
                }

                //dupa stergere daca mai exista utilitati se va selecta prima
                if (cbUtilitati.Items.Count != 0)
                {
                    cbUtilitati.SelectedIndex = 0;
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

        private void btnAdaugaUtilitateCamera_Click(object sender, EventArgs e)
        {
            if (listBoxTipCamere.SelectedIndex == -1)
            {
                MessageBox.Show("Nu ati selectat un tip de camera pentru a adauga utilitati!", "Adaugare utilitate camera");
            }
            else
            {
                if (listBoxTipCamere.SelectedIndex == -1)
                {
                    MessageBox.Show("Nu ati selectat o utilitate pentru a o adauga!", "Adaugare utilitate camera");
                }
                else
                {
                    try
                    {
                        sqlcmd = "insert into utilitati_camere values((select id from categorii_camere where denumire='" + listBoxTipCamere.SelectedItem.ToString() + "'),(select id from utilitati where denumire='" + cbUtilitati.SelectedItem.ToString() + "'))";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        //se recompleteaza dataset-ul
                        updateDsUtilitatiCamere();

                        //se actualizeaza lista utilitatilor si combobox
                        listBoxUtilitatiCamera.Items.Add(cbUtilitati.SelectedItem.ToString());
                        cbUtilitati.Items.Remove(cbUtilitati.SelectedItem.ToString());

                        //dupa daugare daca nu existau alte utilitati, se vor activa controalele
                        if (cbUtilitati.Items.Count == 0)
                        {
                            cbUtilitati.Enabled = false;
                            btnAdaugaUtilitateCamera.Enabled = false;
                        }
                        else
                        {
                            cbUtilitati.SelectedIndex = 0;
                            cbUtilitati.Enabled = true;
                            btnAdaugaUtilitateCamera.Enabled = true;
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
        }

        private void btnDeleteCamera_Click(object sender, EventArgs e)
        {
            if (listBoxTipCamere.SelectedIndex == -1)
            {
                MessageBox.Show("Nu ati selectat un tip de camera pentru a fi sters!", "Stergere tip camera");
            }
            else
            {
                raspunsDialog = MessageBox.Show("Doriti sa stergeti tipul '" + listBoxTipCamere.SelectedItem.ToString() + "' din baza de date?", "Stergere tip camera", MessageBoxButtons.YesNo);

                if (raspunsDialog == DialogResult.No)
                {
                    MessageBox.Show("Anulat!", "Stergere tip camera");
                }
                else
                {
                    try
                    {

                        sqlcmd = "delete from utilitati_camere where id_categorie_camera=(select id from categorii_camere where denumire='" + listBoxTipCamere.SelectedItem.ToString() + "');delete from categorii_camere where denumire='" + listBoxTipCamere.SelectedItem.ToString() + "'";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        listBoxTipCamere.Items.RemoveAt(listBoxTipCamere.SelectedIndex);

                        updateDsUtilitatiCamere();
                        updateDsTipCamere();

                        if (listBoxTipCamere.Items.Count != 0)
                        {
                            listBoxTipCamere.SelectedIndex = 0;
                        }

                        //verifica daca nu exista nicio camera -> se va dezactiva butonul pt stergere
                        if (listBoxTipCamere.Items.Count == 0)
                        {
                            btnDeleteCamera.Enabled = false;
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        con.Close();
                        MessageBox.Show("Tipul de camera a fost sters!", "Stergere tip camera");
                    }
                }
            }
        }

        private void btnAdaugaCamera_Click(object sender, EventArgs e)
        {
            if(textBoxDenumire.Text.Count()==0)
            {
                MessageBox.Show("Completati denumirea tipului de camera!", "Adaugare tip camera");
            }
            else
            {
                if (gasesteUtilitateInLista(textBoxDenumire.Text, listBoxTipCamere) == true)
                {
                    MessageBox.Show("Denumirea tipului de camera introdus exista deja in baza de date!", "Adaugare tip camera");
                }
                else
                {
                    raspunsDialog = MessageBox.Show("Doriti sa adaugati urmatorul tip de camera in baza de date?\n\nDenumire: " + textBoxDenumire.Text + "\nPersoane: " + numericNrPers.Value + "\nPaturi: " + numericNrPaturi.Value + " de tip " + cbTipPat.Text + "\nDimensiuni: " + numericDimensiuni.Value + " metri patrati", "Adaugare tip camera", MessageBoxButtons.YesNo);

                    if (raspunsDialog == DialogResult.No)
                    {
                        MessageBox.Show("Anulat!", "Adaugare tip camera");
                    }
                    else
                    {
                        try
                        {
                            sqlcmd = "insert into categorii_camere(denumire, nr_persoane, nr_paturi, tip_pat, dimensiune) values('" + textBoxDenumire.Text + "','" + numericNrPers.Value + "','" + numericNrPaturi.Value + "','" + cbTipPat.Text + "','" + numericDimensiuni.Value + "')";
                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            listBoxTipCamere.Items.Add(textBoxDenumire.Text);
                            updateDsTipCamere();

                            //activeaza butonul de stergere daca este dezactivat si s-a adaugat o camera
                            if (btnDeleteCamera.Enabled == false)
                            {
                                btnDeleteCamera.Enabled = true;
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        finally
                        {
                            MessageBox.Show("Adaugat!");
                            con.Close();
                        }
                    }
                }
            }
        }

        private void btnEditCamera_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcmd = "update categorii_camere set denumire='"+textBoxDenumire.Text+"' where denumire='"+listBoxTipCamere.SelectedItem.ToString()+"';";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                MessageBox.Show("Modificat!");
                con.Close();
            }
        }

        private void listBoxUtilitati_SelectedValueChanged(object sender, EventArgs e)
        {
            //cand se selecteaza o utilitate se completeaza textbox-ul
            if (listBoxUtilitati.SelectedItem != null)
            {
                textBoxDenumireUtilitate.Text = listBoxUtilitati.SelectedItem.ToString();
            }
        }

        private void btnAdaugaUtilitate_Click(object sender, EventArgs e)
        {
            //1. verifica daca s-a introdus text in textbox
            if (textBoxDenumireUtilitate.Text.Count() == 0)
            {
                MessageBox.Show("Nu ati introdus o utilitate!", "Adaugare utilitate");
            }
            else
            {
                //2. verifica daca textul introdus in textbox se regaseste in listbox
                if (gasesteUtilitateInLista(textBoxDenumireUtilitate.Text,listBoxUtilitati)==true)
                {
                    MessageBox.Show("Utilitatea introdusa exista deja!", "Adaugare utilitate");
                }
                else
                {
                    //3. cere confirmarea userului pentru adaugare
                    raspunsDialog = MessageBox.Show("Doriti sa adaugati utilitatea "+textBoxDenumireUtilitate.Text+" in baza de date?", "Adaugare utilitate", MessageBoxButtons.YesNo);

                    if (raspunsDialog == DialogResult.No)
                    {
                        MessageBox.Show("Anulat!");
                    }
                    else
                    {
                        //MessageBox.Show("Se va adauga!");
                        //4. adauga in baza de date, adauga in cbutilitati, adauga in lista utilitati*/

                        try
                        {
                            sqlcmd = "insert into utilitati values('"+textBoxDenumireUtilitate.Text+"')";
                            con.Open();
                            SqlCommand cmd = new SqlCommand(sqlcmd, con);
                            cmd.ExecuteNonQuery();

                            //se reactualizeaza dataset-ul aferent utilitatilor
                            updateDsUtilitati();

                            listBoxUtilitati.Items.Add(textBoxDenumireUtilitate.Text);
                            cbUtilitati.Items.Add(textBoxDenumireUtilitate.Text);

                            if(cbUtilitati.Enabled==false)
                            {
                                cbUtilitati.Enabled = true;
                                btnAdaugaUtilitateCamera.Enabled = true;
                            }
                        }
                        catch(Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                        finally
                        {
                            con.Close();
                            MessageBox.Show("Utilitatea a fost adaugata in baza de date!", "Adaugare utilitate");
                        }
                    }
                }
            }
        }

        private void btnEditUtilitate_Click(object sender, EventArgs e)
        {
            if (listBoxUtilitati.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati o utilitate din lista pentru a o modifica!", "Modificare utilitate");
            }
            else
            {
                if(textBoxDenumireUtilitate.Text.Count()==0)
                {
                    MessageBox.Show("Completati campul pentru modificarea denumirii!", "Modificare utilitate");
                }
                else
                {
                    if (gasesteUtilitateInLista(textBoxDenumireUtilitate.Text,listBoxUtilitati)==true)
                    {
                        MessageBox.Show("Utilitatea introdusa exista deja!", "Modificare utilitate");
                    }
                    else
                    {
                        raspunsDialog = MessageBox.Show("Doriti sa modificati utilitatea selectata (" + listBoxUtilitati.SelectedItem.ToString() + ") cu cea introdusa (" + textBoxDenumireUtilitate.Text + ")?", "Modificare utilitate", MessageBoxButtons.YesNo);

                        if (raspunsDialog == DialogResult.No)
                        {
                            MessageBox.Show("Anulat!");
                        }
                        else
                        {
                            try
                            {
                                
                                sqlcmd = "update utilitati set denumire='"+textBoxDenumireUtilitate.Text+"' where denumire='"+listBoxUtilitati.SelectedItem.ToString()+"'";
                                con.Open();
                                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                                cmd.ExecuteNonQuery();

                                //se reactualizeaza dataset-ul aferent utilitatilor
                                updateDsUtilitati();

                                //se actualizeaza dataset-ul aferent utilitatilor camerelor
                                updateDsUtilitatiCamere();

                                //daca se regaseste, se sterge si adauga noua utilitate
                                if (gasesteUtilitateInLista(listBoxUtilitati.SelectedItem.ToString(),cbUtilitati)==true)
                                {
                                    cbUtilitati.Items.Remove(listBoxUtilitati.SelectedItem.ToString());
                                    cbUtilitati.Items.Add(textBoxDenumireUtilitate.Text);
                                    cbUtilitati.SelectedIndex = cbUtilitati.FindStringExact(textBoxDenumireUtilitate.Text);
                                }
                                //daca a fost adaugata, se actualizeaza denumirea in listbox utilitati camere
                                else
                                {
                                    foreach (var item in listBoxUtilitatiCamera.Items)
                                    {
                                        if (item.ToString() == listBoxUtilitati.SelectedItem.ToString())
                                        {
                                            listBoxUtilitatiCamera.Items.Remove(item.ToString());
                                            listBoxUtilitatiCamera.Items.Add(textBoxDenumireUtilitate.Text);
                                            break;
                                        }
                                    }
                                }

                                //se actualizeaza listele din formular
                                listBoxUtilitati.Items[listBoxUtilitati.SelectedIndex] = textBoxDenumireUtilitate.Text;

                            }
                            catch(Exception err)
                            {
                                MessageBox.Show(err.Message);
                            }
                            finally
                            {
                                con.Close();
                                MessageBox.Show("Denumirea utilitatii a fost modificata!");
                            }
                        }
                    }
                }
            }
        }

        private void btnStergeUtilitate_Click(object sender, EventArgs e)
        {
            //1. verifica daca a selectat o optiune din lista utilitati
            if (listBoxUtilitati.SelectedIndex == -1)
            {
                MessageBox.Show("Nu ati selectat o utilitate din lista pentru a o putea sterge!", "Stergere utilitate");
            }
            else
            {
                //2. confirmare daca vrea sa stearga utilitatea selectata
                raspunsDialog = MessageBox.Show("Doriti sa stergeti utilitatea selectata ('"+listBoxUtilitati.SelectedItem.ToString()+"')?", "Stergere utilitate", MessageBoxButtons.YesNo);
                if (raspunsDialog == DialogResult.No)
                {
                    MessageBox.Show("Anulat!");
                }
                else
                {
                    try
                    {
                        //3. delete from utilitati_camere
                        con.Open();
                        sqlcmd = "delete from utilitati_camere where id_utilitate=(select id from utilitati where denumire='" + listBoxUtilitati.SelectedItem.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        
                        //4. delete from utilitati
                        sqlcmd = "delete from utilitati where denumire='" + listBoxUtilitati.SelectedItem.ToString() + "'";
                        cmd = new SqlCommand(sqlcmd, con);
                        cmd.ExecuteNonQuery();

                        //se reactualizeaza dataset-ul aferent utilitatilor
                        updateDsUtilitati();

                        //se actualizeaza dataset-ul aferent utilitatilor camerelor
                        updateDsUtilitatiCamere();

                        //6. daca se regaseste in combobox se sterge
                        if (gasesteUtilitateInLista(listBoxUtilitati.SelectedItem.ToString(),cbUtilitati)==true)
                        {
                            cbUtilitati.Items.Remove(listBoxUtilitati.SelectedItem.ToString());
                        }
                        //daca a fost adaugata, se sterge din listbox
                        else
                        {
                            foreach (var item in listBoxUtilitatiCamera.Items)
                            {
                                if (item.ToString() == listBoxUtilitati.SelectedItem.ToString())
                                {
                                    listBoxUtilitatiCamera.Items.Remove(item.ToString());
                                    break;
                                }
                            }
                        }

                        //7. se sterge din lista utilitatilor
                        listBoxUtilitati.Items.Remove(listBoxUtilitati.SelectedItem.ToString());

                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        con.Close();
                        MessageBox.Show("Utilitatea a fost stearsa!");
                    }
                }
                        
            }
        }
    }
}
