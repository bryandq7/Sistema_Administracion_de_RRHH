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
                origen.Porcentaje_ImpuestoRenta = 1;
                //var user = db.ImpuestoRenta.Find(id);
                //db.Entry(user).Property(propertyName).CurrentValue = value;
                db.SaveChanges();



            }

        }
    }
}
