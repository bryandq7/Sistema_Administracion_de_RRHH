using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class DeduccionCN
    {
        private static DeduccionCD obj = new DeduccionCD();
        public static List<DeduccionCE> ListarDeducciones()
        {
            return obj.ListarDeducciones();
        }

        public static DeduccionCE ObtenerDetalleDeduccion(int idDeduccion)
        {
            return obj.ObtenerDetalleDeduccion(idDeduccion);
        }

        public static void Editar(DeduccionCE deduccion)
        {
            obj.Editar(deduccion);
        }
    }
}
