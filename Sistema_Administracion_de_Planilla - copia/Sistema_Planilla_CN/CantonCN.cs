using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class CantonCN
    {
        private static CantonCD obj = new CantonCD();
        public static List<CantonCE> ObtenerCantones(int Id_Provincia)
        {
            return obj.ObtenerCantones(Id_Provincia);
        }
    }
}
