using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class DireccionCN
    {
        private static DireccionCD obj = new DireccionCD();
        public static DireccionCE ObtenerDireccion(int id_direccion)
        {
            return obj.ObtenerDireccion(id_direccion);
        }
    }
}
