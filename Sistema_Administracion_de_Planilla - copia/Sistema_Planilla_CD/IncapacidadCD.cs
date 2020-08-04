using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class IncapacidadCD
    {
        public List<IncapacidadCE> ListarIncapacidades()
        {
            string sql = @"select i.Id_Incapacidad,i.Dias_Incapacidad,i.Procesado_Incapacidad, i.FKId_PeriodoDePago_Incapacidad,
                        i.FKId_TipoIncapacidad_Incapacidad,i.FKId_Empleado_Incapacidad,i.FechaActualizacion_Incapacidad,
                        ti.Id_TipoIncapacidad,ti.Nombre_TipoIncapacidad,pp.Id_PeriodoDePago,pp.Periodo_PeriododDePago,e.Id_Empleado,
                        e.FKId_Persona_Empleado,e.Activo_Empleado,p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona
                        from Incapacidad i
                        inner join TipoIncapacidad ti on i.FKId_TipoIncapacidad_Incapacidad = ti.Id_TipoIncapacidad
                        inner join Empleado e on i.FKId_Empleado_Incapacidad = e.Id_Empleado
                        inner join PeriodoDePago pp on i.FKId_PeriodoDePago_Incapacidad = pp.Id_PeriodoDePago
                        inner join Persona p on e.FKId_Persona_Empleado= p.Id_Persona
                        where i.Procesado_Incapacidad = 0";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<IncapacidadCE>(sql).ToList();
            }
        }

        public void Crear(IncapacidadCE incapacidad1)
        {

            var incapacidad2 = new Incapacidad
            {
                Dias_Incapacidad = incapacidad1.Dias_Incapacidad,
                Procesado_Incapacidad = false,
                FKId_PeriodoDePago_Incapacidad = incapacidad1.Id_PeriodoDePago,
                FKId_TipoIncapacidad_Incapacidad = incapacidad1.Id_TipoIncapacidad,
                FKId_Empleado_Incapacidad = incapacidad1.Id_Empleado,
                FechaActualizacion_Incapacidad = incapacidad1.FechaActualizacion_Incapacidad
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Incapacidad.Add(incapacidad2);
                db.SaveChanges();
            }
        }
    }
}
