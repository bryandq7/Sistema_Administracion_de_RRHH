using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class TipoSolicitudCD
    {

        public List<TipoSolicitud> ListarTipoSolicitudes()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.TipoSolicitud.ToList();
            }
        }

        public void Crear(TipoSolicitud tiposolicitud)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.TipoSolicitud.Add(tiposolicitud);
                db.SaveChanges();
            }
        }

        public TipoSolicitud ObtenerTipoSolicitud(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                //return db.Cargo.Where(p => p.Id_Cargo == id).FirstOrDefault();
                return db.TipoSolicitud.Find(id);
            }
        }

        public void Editar(TipoSolicitud tiposolicitud)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.TipoSolicitud.Find(tiposolicitud.Id_TipoSolicitud);
                origen.Detalle_TipoSolicitud = tiposolicitud.Detalle_TipoSolicitud;
                origen.FechaActualizacion_TipoSolicitud = tiposolicitud.FechaActualizacion_TipoSolicitud;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var tiposolicitud = db.TipoSolicitud.Find(id);
                db.TipoSolicitud.Remove(tiposolicitud);
                db.SaveChanges();
            }

        }
    }
}
