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
    public class CantonCD
    {
        public List<CantonCE> ObtenerCantones(int Id_Provincia)
        {
            
            //string sql = @"select Canton.Id_Canton, Canton.Nombre_Canton,Canton.FKIdProvincia_Canton from Canton
            //            where Canton.FKIdProvincia_Canton = @Cod_Provincia";

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                //return db.Database.SqlQuery<Canton>(sql, new SqlParameter("@Cod_Provincia", FKIdProvincia_Canton)).ToList();
                //return db.Canton.Where((d => d.FKIdProvincia_Canton == FKIdProvincia_Canton)).Include(d => d.FKIdProvincia_Canton).ToList();


                var thelist = db.Canton.Where(d => d.FKIdProvincia_Canton == Id_Provincia).Select(d => new CantonCE
                {
                    Id_Canton = d.Id_Canton,
                    Nombre_Canton = d.Nombre_Canton,
                    FKIdProvincia_Canton = d.FKIdProvincia_Canton,
                    Id_Provincia = Id_Provincia
                }).AsNoTracking().ToList();

                return thelist;
            }
        }

    }
}
