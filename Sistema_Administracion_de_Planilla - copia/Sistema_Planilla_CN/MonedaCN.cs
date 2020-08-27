using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class MonedaCN
    {
        private static MonedaCD obj = new MonedaCD();
        public static List<Moneda> ListarMonedas()
        {
            return obj.ListarMonedas();
        }
    }
}
