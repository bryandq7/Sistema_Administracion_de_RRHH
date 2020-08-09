using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class PeriodoDePagoCN
    {
        private static PeriodoDePagoCD obj = new PeriodoDePagoCD();
        public static List<PeriodoDePagoCE> ObtenerPeriododePago()
        {
            return obj.ObtenerPeriododePago();
        }

        public static PeriodoDePagoCE ObtenerPeriodoPosterior()
        {
            return obj.ObtenerPeriodoPosterior();
        }

        public static PeriodoDePagoCE ObtenerPeriodoAnterior()
        {
            return obj.ObtenerPeriodoAnterior();
        }

    }
}
