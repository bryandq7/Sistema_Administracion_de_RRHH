using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class IncapacidadCN
    {
        private static IncapacidadCD obj = new IncapacidadCD();

        public static List<IncapacidadCE> ListarIncapacidades()
        {
            return obj.ListarIncapacidades();
        }

        public static void Crear(IncapacidadCE incapacidad1)
        {
            obj.Crear(incapacidad1);
        }
    }
}
