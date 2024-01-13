using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel.App
{
    class DisponibilitateCamere
    {
        SqlConnection sqlCon;
        SqlDataAdapter dataAdapter;
        DataSet dataSet = new DataSet();

        public DisponibilitateCamere()
        {
            sqlCon = new SqlConnection();
            sqlCon.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Adrian\Documents\Hotel.Database.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private void Main(string[] args)
        {
            disponibilitateCamere(DateTime.Today, DateTime.Today);
        }

        public Dictionary<string, Int32> disponibilitateCamere(DateTime data_inceput, DateTime data_sfarsit)
        {
            Dictionary<string, Int32> camereDisponibile = new Dictionary<string, Int32>();

            string data_inceputString = data_inceput.ToString("yyyy-MM-dd HH:mm:ss");
            string data_sfarsitString = data_sfarsit.ToString("yyyy-MM-dd");

            try{
                sqlCon.Open();

                string sqlcmd = "select 'Cazare' as tip, (select denumire from categorii_camere"+
                    " where Id=camere.id_categorie_camere) as categorie_camere, cazari.checkin as data_inceput, " +
                    "cazari.checkout as data_sfarsit, 1 as numar_camere from camere_cazari "+
                    "join camere on camere_cazari.id_camera=camere.id_camera "+
                    "join cazari on camere_cazari.id_cazare=cazari.id_cazare "+
                    "where '" + data_inceputString + "' > checkin and '" + data_inceputString + "' < checkout "+
                    "order by data_inceput asc";

                dataAdapter = new SqlDataAdapter(sqlcmd, sqlCon);
                dataAdapter.Fill(dataSet, "CamereOcupate");

                sqlcmd = "select 'Rezervare' as tip, (select denumire from categorii_camere "+
                    "where Id = camere_rezervate.id_tip_camera) as categorie_camere, data_inceput, data_sfarsit, "+
                    "camere_rezervate.numar_camere from rezervari "+
                    "join camere_rezervate on rezervari.id_rezervare=camere_rezervate.id_rezervare "+
                    "where '"+data_inceputString+"' <= data_inceput and '"+data_sfarsitString+"' > data_inceput "+
                    "order by data_inceput asc";

                dataAdapter = new SqlDataAdapter(sqlcmd, sqlCon);
                dataAdapter.Fill(dataSet, "CamereRezervate");

                sqlcmd = "select denumire from categorii_camere";
                dataAdapter = new SqlDataAdapter(sqlcmd, sqlCon);
                dataAdapter.Fill(dataSet, "CategoriiCamere");

                sqlcmd = "select denumire from camere join categorii_camere on categorii_camere.Id = camere.id_categorie_camere"+
                    " where status='activ'";
                dataAdapter = new SqlDataAdapter(sqlcmd, sqlCon);
                dataAdapter.Fill(dataSet, "CategoriiCamereActive");

                dataSet.Tables["CamereOcupate"].Merge(dataSet.Tables["CamereRezervate"]);
            }
            catch(Exception err){
                MessageBox.Show(err.Message);
            }
            finally{
                sqlCon.Close();
            }

            DataTable CamereOcupate = dataSet.Tables["CamereOcupate"].Clone();
            foreach (DataRow cameraOcupata in dataSet.Tables["CamereOcupate"].Rows)
            {
                if(Convert.ToInt32(cameraOcupata["numar_camere"]) > 1)
                {
                    for (int i = 0; i < Convert.ToInt32(cameraOcupata["numar_camere"]); i++)
                    {
                        CamereOcupate.ImportRow(cameraOcupata);
                    }
                }
                else
                {
                    CamereOcupate.ImportRow(cameraOcupata);
                }
            }

            dataSet.Tables["CamereOcupate"].Columns.Add("alocat", typeof(bool));
            CamereOcupate.Columns.Add("alocat", typeof(bool));

            foreach (DataRow categorieCamere in dataSet.Tables["CategoriiCamere"].Rows)
            {
                List<DataRow> camereOcupateDinCategorie = CamereOcupate.Select("categorie_camere='" +
                    categorieCamere["denumire"].ToString() + "'").ToList();

                int nrCamereNecesare = 0;
                DateTime dataInceput;
                DateTime dataSfarsit;
                foreach (DataRow cameraOcupata in camereOcupateDinCategorie)
                {
                    if (cameraOcupata["alocat"].ToString() != "True")
                    {
                        dataInceput = DateTime.Parse(cameraOcupata["data_inceput"].ToString()).Date;
                        dataSfarsit = DateTime.Parse(cameraOcupata["data_sfarsit"].ToString()).Date;
                        nrCamereNecesare++;

                        cameraOcupata["alocat"] = true;

                        foreach (DataRow cameraOcupata2 in camereOcupateDinCategorie)
                        {
                            if (cameraOcupata2["alocat"].ToString() != "True")
                            {
                                if (DateTime.Parse(cameraOcupata2["data_inceput"].ToString()).Date >= dataSfarsit)
                                {
                                    dataSfarsit = DateTime.Parse(cameraOcupata2["data_sfarsit"].ToString()).Date;

                                    cameraOcupata2["alocat"] = true;
                                }
                            }
                        }
                    }
                }

                int nrCamereActive=0;
                foreach (DataRow row in dataSet.Tables["CategoriiCamereActive"].Rows)
                {
                    if (row["denumire"].ToString() == categorieCamere["denumire"].ToString())
                    {
                        nrCamereActive++;
                    }
                }

                camereDisponibile.Add(categorieCamere["denumire"].ToString(), nrCamereActive - nrCamereNecesare);
            }

            return camereDisponibile;
        }
    }
}
