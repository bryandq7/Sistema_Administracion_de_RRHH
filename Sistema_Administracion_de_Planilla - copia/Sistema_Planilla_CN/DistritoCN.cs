using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class DistritoCN
    {
        private static DistritoCD obj = new DistritoCD();
        public static List<Distrito> ListarDistritos()
        {
            return obj.ListarDistritos();
        }

        public static  List<DistritoCE> ObtenerDistritos(int Id_Canton)
        {
            return obj.ObtenerDistritos(Id_Canton);
        }
    }
}
