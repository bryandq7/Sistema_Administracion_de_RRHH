using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class ProvinciaCN
    {
        private static ProvinciaCD obj = new ProvinciaCD();
        public static List<Provincia> ListarProvincias()
        {
            return obj.ListarProvincias();
        }
    }
}
