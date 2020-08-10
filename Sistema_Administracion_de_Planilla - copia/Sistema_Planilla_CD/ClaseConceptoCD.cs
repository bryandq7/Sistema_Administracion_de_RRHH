using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class ClaseConceptoCD
    {
        public List<ClaseConcepto> ListarClaseConceptos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.ClaseConcepto.ToList();
            }
        }

        public List<ClaseConcepto> ObtenerClaseConceptosPatrono()
        {
            string sql = @"select cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto from ClaseConcepto cc
                            where cc.Id_ClaseConcepto = 2";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ClaseConcepto>(sql).ToList();
            }
        }

        public List<ClaseConcepto> ObtenerClaseConceptosTrabajador()
        {


            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.ClaseConcepto.ToList();
            }
        }



    }





}
