using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class TipoContratoCD
    {
        public List<TipoContrato> ListarTipoContratos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.TipoContrato.ToList();
            }
        }

        public void Crear(TipoContrato tipocontrato)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.TipoContrato.Add(tipocontrato);
                db.SaveChanges();
            }
        }

        public TipoContrato ObtenerTipoContrato(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                //return db.Cargo.Where(p => p.Id_Cargo == id).FirstOrDefault();
                return db.TipoContrato.Find(id);
            }
        }

        public void Editar(TipoContrato tipocontrato)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.TipoContrato.Find(tipocontrato.Id_TipoContrato);
                origen.Detalle_TipoContrato = tipocontrato.Detalle_TipoContrato;
                origen.FechaActualizacion_TipoContrato = tipocontrato.FechaActualizacion_TipoContrato;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var tipocontrato = db.TipoContrato.Find(id);
                db.TipoContrato.Remove(tipocontrato);
                db.SaveChanges();
            }

        }
    }
}
