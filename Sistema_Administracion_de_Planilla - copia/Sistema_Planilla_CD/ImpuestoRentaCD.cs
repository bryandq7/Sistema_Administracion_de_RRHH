using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class ImpuestoRentaCD
    {
        public List<ImpuestoRenta> ListarImpuestoRenta()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.ImpuestoRenta.ToList();
            }
        }

        public void Editar(ImpuestoRenta customer)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.ImpuestoRenta.Find(customer.Id_ImpuestoRenta);
                origen.MontoMaximo_ImpuestoRenta = customer.MontoMaximo_ImpuestoRenta;
                origen.MontoMinimo_ImpuestoRenta = customer.MontoMinimo_ImpuestoRenta;
                origen.Porcentaje_ImpuestoRenta = customer.Porcentaje_ImpuestoRenta;
                db.SaveChanges();
            }

            var maxIdImpuesto = ObtenerMaxIdImpuestoRenta();
            var montoMinImprenta = customer.MontoMaximo_ImpuestoRenta;
            montoMinImprenta = montoMinImprenta + 1;
            var IdsiguienteImpuesto = customer.Id_ImpuestoRenta + 1;

            if (customer.Id_ImpuestoRenta<maxIdImpuesto)
            {
                using (var db = new RecursosHumanosDBContext())
                {
                    var origen2 = db.ImpuestoRenta.Find(IdsiguienteImpuesto);
                    origen2.MontoMinimo_ImpuestoRenta = montoMinImprenta ;
                    db.SaveChanges();
                }

            }

        }

        public int ObtenerMaxIdImpuestoRenta()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var Impuestomax = db.ImpuestoRenta
                    .Max(p => p.Id_ImpuestoRenta);

                return Impuestomax;
            }
        }

        public decimal? ObtenerMaxMontoSiguienteImpuestoRenta(int idImpuestoRenta)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var Impuestomax = db.ImpuestoRenta
                    .Where(p => p.Id_ImpuestoRenta == idImpuestoRenta).FirstOrDefault();
                

                return Impuestomax.MontoMaximo_ImpuestoRenta ;
            }
        }

    }
}
