using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassRepository
{
    public class TipCamera
    {
        public int id {get; set; }
        public string denumire { get; set; }
        public int nr_oaspeti { get; set; }
        public int dimensiune_mp { get; set; }
        public string descriere { get; set; }
        public bool status { get; set; }

        /*public TipCamera(int id, string denumire, int nr_oaspeti, int dimensiune_mp, string descriere, string status)
        {
            this.id = id;
            this.denumire = denumire;
            this.nr_oaspeti = nr_oaspeti;
            this.dimensiune_mp = dimensiune_mp;
            this.descriere = descriere;
            this.status = boolParse(status);
        }*/

        public TipCamera(int id, string denumire, int nr_oaspeti, int dimensiune_mp, string descriere)
        {
            this.id = id;
            this.denumire = denumire;
            this.nr_oaspeti = nr_oaspeti;
            this.dimensiune_mp = dimensiune_mp;
            this.descriere = descriere;
        }

        public bool boolParse(string status)
        {
            if (status == "activ")
            {
                return true;
            }
            return false;
        }

        public static string updateTipCamera(TipCamera tipCamera, SqlConnection con)
        {
            string msg = null;

            try
            {
                string sqlcmd = "update categorii_camere set denumire='"+tipCamera.denumire+"', nr_oaspeti='"+tipCamera.nr_oaspeti+"', dimensiune_mp='"+tipCamera.dimensiune_mp+"', descriere='"+tipCamera.descriere+"' where Id='"+tipCamera.id+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
    }
}
