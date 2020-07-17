using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class DistritoCD
    {

        public List<Distrito> ListarDistritos()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Distrito.ToList();
            }
        }

        public List<DistritoCE> ObtenerDistritos(int Id_Canton)
        {

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
               
                var thelist = db.Distrito.Where(d => d.FKIdCanton_Distrito == Id_Canton).Select(d => new DistritoCE
                {
                    Id_Distrito = d.Id_Distrito,
                    Nombre_Distrito = d.Nombre_Distrito,
                    FKIdCanton_Distrito = d.FKIdCanton_Distrito,
                    Id_Canton = Id_Canton
                }).AsNoTracking().ToList();

                return thelist;
            }
        }


    }
}
