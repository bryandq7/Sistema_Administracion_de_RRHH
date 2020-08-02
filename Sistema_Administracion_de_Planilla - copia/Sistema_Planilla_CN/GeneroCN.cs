using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class GeneroCN
    {
        private static GeneroCD obj = new GeneroCD();
        public static List<Genero> ListarGeneros()
        {
            return obj.ListarGeneros();
        }
    }
}
