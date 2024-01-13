using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRepository
{
    public class PatCamera
    {
        public int idCategorieCamera { get; set; }
        public int idPat { get; set; }
        public string denumirePat { get; set; }
        public int numarPaturi { get; set; }

        public PatCamera(int idCategorieCamera, int idPat, string denumirePat, int numarPaturi)
        {
            this.idCategorieCamera = idCategorieCamera;
            this.idPat = idPat;
            this.denumirePat = denumirePat;
            this.numarPaturi = numarPaturi;
        }
    }
}
