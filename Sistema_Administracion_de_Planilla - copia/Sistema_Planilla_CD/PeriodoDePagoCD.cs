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

        public PeriodoDePagoCE ObtenerPeriododePagoObj()
        {
            string sql = @"select top 1 pp.Id_PeriodoDePago, pp.Periodo_PeriododDePago from PeriodoDePago pp
                         where Periodo_PeriododDePago<=DATEADD(day, 17, GetDate()) and Periodo_PeriododDePago>GetDate()";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PeriodoDePagoCE>(sql).FirstOrDefault();
            }
        }


        public bool ObtenerPeriodoActivoYNOProcesado(int periodoID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var activo = db.PeriodoDePago
                    .Any(p => p.Id_PeriodoDePago == periodoID && p.ActivoPeriodo_PeriododDePago == true && p.Procesado_PeriododDePago == false);
                return activo;
            }
        }


        public bool AbiertoPeriodoNomina(int periodoID)
        {
            var periodo = new PeriodoDePago();
            bool bandera = false;

            using (var db = new RecursosHumanosDBContext())
            {
                periodo = db.PeriodoDePago
               .Where(p => p.Id_PeriodoDePago == periodoID).FirstOrDefault();
            }

            DateTime date1 = periodo.Periodo_PeriododDePago;
            DateTime date2 = DateTime.Today;
            int daysDiff = ((TimeSpan)(date1 - date2)).Days;

            if (daysDiff <= 3 && daysDiff>=0)
                bandera = true;

            return bandera;
        }




        public PeriodoDePagoCE ObtenerPeriodoPosterior()
        {
            string sql = @"select top 1 pp.Id_PeriodoDePago, pp.Periodo_PeriododDePago from PeriodoDePago pp
                         where Periodo_PeriododDePago<=DATEADD(day, 17, GetDate()) and Periodo_PeriododDePago>GetDate()";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PeriodoDePagoCE>(sql).FirstOrDefault();
            }
        }

        public PeriodoDePagoCE ObtenerPeriodoAnterior()
        {
            string sql = @"select top 1 pp.Id_PeriodoDePago, pp.Periodo_PeriododDePago from PeriodoDePago pp
                         where Periodo_PeriododDePago<=DATEADD(day, 17, GetDate()) and Periodo_PeriododDePago>DATEADD(day, -17, GetDate())";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PeriodoDePagoCE>(sql).FirstOrDefault();
            }
        }

    }
}
