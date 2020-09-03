using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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


        public List<ConceptoCE> ListarConceptos(Nullable<int> impacta)
        {
            string sql = "";
            if (impacta is null)
            {
                sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,c.FactorTiempo_Concepto             
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla";

            }

            if (impacta == 1)
            {
                sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,c.FactorTiempo_Concepto            
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla
				where imp.Id_ImpactaPlanilla = 1";
            }

            if (impacta == 2)
            {
                sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,c.FactorTiempo_Concepto             
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla
				where imp.Id_ImpactaPlanilla = 2";
            }


            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ConceptoCE>(sql).ToList();
            }
        }


        public List<ConceptoCE> ListarConceptosPlanilla(Nullable<int> impacta)
        {
            string sql = "";

            if (impacta == 1)
            {
                sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,c.FactorTiempo_Concepto            
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla
				where imp.Id_ImpactaPlanilla = 1 and c.DirectoPlanilla_Concepto = 1";
            }

            if (impacta == 2)
            {
                sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,c.FactorTiempo_Concepto             
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla
				where imp.Id_ImpactaPlanilla = 2 and c.DirectoPlanilla_Concepto = 1";
            }


            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ConceptoCE>(sql).ToList();
            }
        }

        public void Crear(ConceptoCE concepto)
        {

            var destinatario = 0;

            if (concepto.Id_ClaseConcepto == 1 && concepto.Id_TipoConcepto == 1)
            {
                destinatario = 7;
            }

            if (concepto.Id_ClaseConcepto == 2 && concepto.Id_TipoConcepto == 1)
            {
                destinatario = 5;
            }

            if (concepto.Id_ClaseConcepto == 1 && concepto.Id_TipoConcepto ==2)
            {
                destinatario = 7;
            }

            if (concepto.Id_ClaseConcepto == 2 && concepto.Id_TipoConcepto == 2)
            {
                destinatario = 5;
            }

            if (concepto.Id_ClaseConcepto == 2 && concepto.Id_TipoConcepto == 3)
            {
                destinatario = 6;
            }

            if (concepto.Id_ClaseConcepto == 1 && concepto.Id_TipoConcepto == 3)
            {
                destinatario = 7;
            }

            if (concepto.Id_ClaseConcepto == 2 && concepto.Id_TipoConcepto == 4)
            {
                destinatario = 6;
            }

            if (concepto.Id_ClaseConcepto == 1 && concepto.Id_TipoConcepto == 4)
            {
                destinatario = 7;
            }

            var concepto1 = new Concepto
            {
                Nombre_Concepto = concepto.Nombre_Concepto,
                Editable_Concepto = true,
                FKId_TipoConcepto_Concepto = concepto.Id_TipoConcepto,
                FKId_DestinatarioConcepto_Concepto = destinatario,
                FKId_ImpactaPlanilla_Concepto = concepto.Id_ImpactaPlanilla,
                FKId_ClaseConcepto_Concepto = concepto.Id_ClaseConcepto,
                MontoFijo_Concepto = concepto.MontoFijo_Concepto,
                DirectoPlanilla_Concepto = concepto.DirectoPlanilla_Concepto,
                FactorTiempo_Concepto = concepto.FactorTiempo_Concepto,
                Porcentaje_Concepto = concepto.Porcentaje_Concepto
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Concepto.Add(concepto1);
                db.SaveChanges();
            }

        }

        public ConceptoCE ObtenerDetalleConcepto(int idconcepto)
        {

            string sql = @"select c.Id_Concepto,c.Nombre_Concepto,c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,
				c.FKId_ImpactaPlanilla_Concepto,c.FKId_ClaseConcepto_Concepto,c.Porcentaje_Concepto,c.MontoFijo_Concepto,
				c.DirectoPlanilla_Concepto,tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,dc.Id_DestinatarioConcepto,
				dc.Nombre_DestinatarioConcepto,imp.Id_ImpactaPlanilla,imp.Detalle_ImpactaPlanilla,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,c.FactorTiempo_Concepto             
                from Concepto c 
                inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
				inner join DestinatarioConcepto dc on c.FKId_DestinatarioConcepto_Concepto = dc.Id_DestinatarioConcepto
				inner join ImpactaPlanilla imp on c.FKId_ImpactaPlanilla_Concepto = imp.Id_ImpactaPlanilla
				where c.Id_Concepto = @Cod_Concepto";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ConceptoCE>(sql, new SqlParameter("@Cod_Concepto", idconcepto)).FirstOrDefault();
            }

        }


        public void Editar(ConceptoCE concepto)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Concepto.Find(concepto.Id_Concepto);
                origen.MontoFijo_Concepto = concepto.MontoFijo_Concepto;

                db.SaveChanges();
            }
        }

        public void EditarPorcentaje(ConceptoCE concepto)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Concepto.Find(concepto.Id_Concepto);
                origen.Porcentaje_Concepto = concepto.Porcentaje_Concepto;
                db.SaveChanges();
            }
        }

        public void EditarTiempo(ConceptoCE concepto)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Concepto.Find(concepto.Id_Concepto);
                origen.FactorTiempo_Concepto = concepto.FactorTiempo_Concepto;

                db.SaveChanges();
            }
        }

        public void EditarDia(ConceptoCE concepto)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Concepto.Find(concepto.Id_Concepto);
                origen.FactorTiempo_Concepto = concepto.FactorTiempo_Concepto;

                db.SaveChanges();
            }
        }



        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var concepto = db.Concepto.Find(id);
                db.Concepto.Remove(concepto);
                db.SaveChanges();
            }

        }
    }
}
