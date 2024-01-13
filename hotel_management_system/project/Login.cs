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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataTable contConectat;
        string sqlcmd = "";
        DialogResult raspunsDialog;

        private void Login_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            this.CenterToScreen();
        }


        private void btnConectare_Click(object sender, EventArgs e)
        {
            if(textBoxIdCont.Text.Count()==0 || textBoxParolaCont.Text.Count()==0)
            {
                MessageBox.Show("Introduceti datele contului pentru a va conecta!");
            }
            else
            {
                try
                {
                    con.Open();
                    sqlcmd = "select angajati.id_angajat, angajati.tip_angajat, id, parola from conturi join angajati on angajati.id_cont = conturi.id where id='"+textBoxIdCont.Text+"' and parola='"+textBoxParolaCont.Text+"'";
                    contConectat = new DataTable();
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(contConectat);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    con.Close();
                }

                if (contConectat.Rows.Count == 0)
                {
                    MessageBox.Show("Datele introduse nu sunt corecte!");
                }
                else
                {
                    if (contConectat.Rows[0][1].ToString() == "administrator")
                    {
                        Administrator form = new Administrator(Convert.ToInt32(contConectat.Rows[0]["id_angajat"]));
                        this.Hide();
                        form.ShowDialog();
                        this.Show();
                        textBoxIdCont.Clear();
                        textBoxParolaCont.Clear();
                    }
                    else
                    {
                        Receptioner form = new Receptioner(Convert.ToInt32(contConectat.Rows[0]["id_angajat"]));
                        this.Hide();
                        form.ShowDialog();
                        this.Show();
                        textBoxIdCont.Clear();
                        textBoxParolaCont.Clear();
                    }
                }
            }
        }
    }
}
