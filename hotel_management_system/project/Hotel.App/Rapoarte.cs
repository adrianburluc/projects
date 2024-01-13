using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hotel.App
{
    public partial class Rapoarte : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string sqlcmd;

        public Rapoarte()
        {
            InitializeComponent();
        }

        private void Rapoarte_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
            cbTipRaport.SelectedIndex = 0;
        }

        private void btnGenereazaGrafic_Click(object sender, EventArgs e)
        {
            if (cbTipRaport.SelectedIndex == 0)
            {
                try
                {
                    grafic.Series.RemoveAt(0);
                    grafic.Series.Add("Luni");
                    con.Open();
                    sqlcmd = "select id_cazare, total_achitat_lei, checkin, checkout from cazari where ('" + dataInceputRaport.Value + "'>checkin and  '" + dataInceputRaport.Value + "' < checkout) or ('" + dataInceputRaport.Value + "'<=checkin and '" + dataSfarsitRaport.Value + "' > checkin) order by checkin asc";
                    da = new SqlDataAdapter(sqlcmd, con);
                    da.Fill(ds, "Cazari");

                    //((date1.Year - date2.Year) * 12) + date1.Month - date2.Month

                    Dictionary<String, decimal> dict = new Dictionary<String, decimal>();
                    //int nrLuni = ((dataSfarsitRaport.Value.Year - dataInceputRaport.Value.Year) * 12) + dataSfarsitRaport.Value.Month - dataInceputRaport.Value.Month;
                    for (int luna = dataInceputRaport.Value.Month; luna < dataSfarsitRaport.Value.Month; luna++)
                    {
                        
                        //grafic.Series["Luni"].Points.AddXY(luna.ToString(), 30);
                    }

                    foreach (DataRow cazare in ds.Tables["Cazari"].Rows)
                    {
                        string lunaCazarii = DateTime.Parse(cazare["checkin"].ToString()).Month.ToString();

                        DateTime test = DateTime.Parse(cazare["checkin"].ToString());
                        string numeLuna = test.ToString("MMMM");
                            

                        if (dict.ContainsKey(numeLuna))
                        {
                            MessageBox.Show("exista deja");
                            dict[numeLuna] = dict[numeLuna] + Convert.ToDecimal(cazare["total_achitat_lei"]);
                        }
                        else
                        {
                            dict.Add(numeLuna, Convert.ToDecimal(cazare["total_achitat_lei"]));
                        }
                    }

                    foreach(KeyValuePair<String, decimal> keyvaluepair in dict)
                    {
                        MessageBox.Show(keyvaluepair.Value+" "+ keyvaluepair.Key);
                        grafic.Series["Luni"].Points.AddXY(keyvaluepair.Key, keyvaluepair.Value);
                    }
                    grafic.Titles.Add("Veniturile cazarilor existente pentru fiecare luna din perioada selectata");
                    grafic.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 18f);

                    //MessageBox.Show(ds.Tables["Cazari"].Rows.Count.ToString()+" "+nrLuni.ToString());
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

            
            //grafic.Series.Add("Test");
            //grafic.Series["Age"].Points.AddXY("Test1", 10);
            //grafic.Series["Age"].Points.AddXY("Test2", 20);
            //grafic.Series["Age"].Points.AddXY("Test3", 30);
            //grafic.Series["Test"].Points.AddY(10);
            //grafic.Series["Test"].Points.AddY(7);
            //grafic.Series["Test"].Points.AddY(4);
        }

        private void btnSavePdf_Click(object sender, EventArgs e)
        {
            grafic.SaveImage("C:\\Users\\Adrian\\Documents\\Facultate\\Licenta\\Hotel\\ClassRepository\\imagini\\imagini_salvate\\grafic.png", ChartImageFormat.Png);
        }
    }
}
