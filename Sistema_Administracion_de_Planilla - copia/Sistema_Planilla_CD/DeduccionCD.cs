using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class DeduccionCD
    {
        public List<DeduccionCE> ListarDeducciones()
        {
            string sql = @"select d.Id_Deduccion,d.Nombre_Deduccion,d.Porcentaje_Deduccion,d.FechaActualizacion_Deducion,d.FKId_TipoDeduccion_Deduccion,
                td.Id_TipoDeduccion,td.Detalle_TipoDeduccion, dd.Id_DestinatarioDeduccion, dd.Nombre_DestinatarioDeduccion
                from Deduccion d 
                inner join TipoDeduccion td on td.Id_TipoDeduccion = d.FKId_TipoDeduccion_Deduccion
				inner join Destinatariodeduccion dd on dd.Id_DestinatarioDeduccion = d.FKId_DestinatarioDeduccion_Deduccion";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<DeduccionCE>(sql).ToList();
            }
        }

        public DeduccionCE ObtenerDetalleDeduccion(int idDeduccion)
        {

            string sql = @"select d.Id_Deduccion,d.Nombre_Deduccion,d.Porcentaje_Deduccion,d.FechaActualizacion_Deducion,d.FKId_TipoDeduccion_Deduccion,
                td.Id_TipoDeduccion,td.Detalle_TipoDeduccion, dd.Id_DestinatarioDeduccion, dd.Nombre_DestinatarioDeduccion
                from Deduccion d 
                inner join TipoDeduccion td on td.Id_TipoDeduccion = d.FKId_TipoDeduccion_Deduccion
				inner join Destinatariodeduccion dd on dd.Id_DestinatarioDeduccion = d.FKId_DestinatarioDeduccion_Deduccion
				where d.Id_Deduccion = @Cod_Deduccion";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<DeduccionCE>(sql, new SqlParameter("@Cod_Deduccion", idDeduccion)).FirstOrDefault();
            }

        }

        public void Editar(DeduccionCE deduccion)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Deduccion.Find(deduccion.Id_Deduccion);
                origen.Porcentaje_Deduccion = deduccion.Porcentaje_Deduccion;
                origen.FechaActualizacion_Deducion = deduccion.FechaActualizacion_Deducion;
                db.SaveChanges();
            }
        }
    }
}
