using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class PlanillaCD
    {

        public void CrearPlanillaEmpleado(Planilla planilla)
        {         
            using (var db = new RecursosHumanosDBContext())
            {
                db.Database.SqlQuery<Planilla>("spCrearPlanillaMaestro, @FechaActualizacion_Planilla, @FKId_Empleado_Planilla, @FKId_PeriodoDePago_Planilla , " +
                   "@TotalDeducciones_Planilla, @TotalAsignaciones_Planilla,@TotalMontoaPagar_Planilla , @PagoProcesado_Planilla",
                    new SqlParameter("@FechaActualizacion_Planilla", planilla.FechaActualizacion_Planilla),
                    new SqlParameter("@FKId_Empleado_Planilla", planilla.FKId_Empleado_Planilla),
                    new SqlParameter("@FKId_PeriodoDePago_Planilla", planilla.FKId_PeriodoDePago_Planilla),
                    new SqlParameter("@TotalDeducciones_Planilla", planilla.TotalDeducciones_Planilla),
                    new SqlParameter("@TotalAsignaciones_Planilla", planilla.TotalAsignaciones_Planilla),
                    new SqlParameter("@TotalMontoaPagar_Planilla", planilla.TotalMontoaPagar_Planilla),
                    new SqlParameter("@PagoProcesado_Planilla", planilla.PagoProcesado_Planilla));    
            }
        }

    }
}
