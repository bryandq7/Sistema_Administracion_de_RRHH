using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class PeriodoDePagoCD
    {

        public List<PeriodoDePagoCE> ObtenerPeriododePago()
        {
            string sql = @"select top 1 pp.Id_PeriodoDePago, pp.Periodo_PeriododDePago from PeriodoDePago pp
                         where Periodo_PeriododDePago<=DATEADD(day, 17, GetDate()) and Periodo_PeriododDePago>GetDate()";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PeriodoDePagoCE>(sql).ToList();
            }
        }

    }
}
