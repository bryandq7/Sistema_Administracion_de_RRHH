using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class ConceptoCD
    {
        public List<ConceptoCE> ObtenerConceptos(int Id_ClaseConcepto, int Id_TipoConcepto)
        {

            //string sql = @"select Canton.Id_Canton, Canton.Nombre_Canton,Canton.FKIdProvincia_Canton from Canton
            //            where Canton.FKIdProvincia_Canton = @Cod_Provincia";

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Database.SqlQuery<Canton>(sql, new SqlParameter("@Cod_Provincia", FKIdProvincia_Canton)).ToList();
                //return db.Canton.Where((d => d.FKIdProvincia_Canton == FKIdProvincia_Canton)).Include(d => d.FKIdProvincia_Canton).ToList();


                var thelist = db.Concepto.Where(d => d.FKId_ClaseConcepto_Concepto == Id_ClaseConcepto &&
                d.FKId_TipoConcepto_Concepto == Id_TipoConcepto && d.FKId_ImpactaPlanilla_Concepto == 2 && d.DirectoPlanilla_Concepto == false).Select(d => new ConceptoCE
                {
                    Id_Concepto = d.Id_Concepto,
                    Nombre_Concepto = d.Nombre_Concepto,

                }).AsNoTracking().ToList();

                return thelist;
            }
        }


        public List<ConceptoCE> ListarConceptos()
        {
            string sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto             
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ConceptoCE>(sql).ToList();
            }
        }

    }
}
