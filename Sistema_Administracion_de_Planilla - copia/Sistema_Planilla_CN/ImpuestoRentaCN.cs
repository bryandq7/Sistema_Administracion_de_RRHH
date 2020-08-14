using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class ImpuestoRentaCN
    {

        private static ImpuestoRentaCD obj = new ImpuestoRentaCD();

        public static List<ImpuestoRenta> ListarImpuestoRenta()
        {
            return obj.ListarImpuestoRenta();
        }

        public static void Editar(ImpuestoRenta customer)
        {
            obj.Editar(customer);
        }

        public static int ObtenerMaxIdImpuestoRenta()
        {
            return obj.ObtenerMaxIdImpuestoRenta();
        }

        public static decimal? ObtenerMaxMontoSiguienteImpuestoRenta(int idImpuestoRenta)
        {
            idImpuestoRenta = idImpuestoRenta + 1;
            return obj.ObtenerMaxMontoSiguienteImpuestoRenta(idImpuestoRenta);
        }

    }
}
