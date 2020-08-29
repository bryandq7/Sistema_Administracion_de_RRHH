using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class FotoPersonaCD
    {

        public void Crear(FotoPersonaCE foto)
        {
            var fotoOrigen = new FotoPersona
            {
                Foto_FotoPersona = foto.Foto_FotoPersona,
                Titulo_FotoPersona = foto.Titulo_FotoPersona,
                FKId_Persona_FotoPersona = foto.Id_Persona,
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.FotoPersona.Add(fotoOrigen);
                db.SaveChanges();
            }
        }

        public FotoPersonaCE ObtenerFoto(int idpersona)
        {

            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, fp.Id_FotoPersona, fp.Foto_FotoPersona, fp.Titulo_FotoPersona, fp.FKId_Persona_FotoPersona
                        from FotoPersona fp 
                        inner join Persona p on fp.FKId_Persona_FotoPersona = p.Id_Persona
                        where fp.FKId_Persona_FotoPersona = @Cod_persona";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<FotoPersonaCE>(sql, new SqlParameter("@Cod_persona", idpersona)).FirstOrDefault();
            }

        }


        public void Editar(FotoPersonaCE foto)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.FotoPersona.Find(foto.Id_FotoPersona);
                origen.Foto_FotoPersona = foto.Foto_FotoPersona;
                origen.Titulo_FotoPersona = foto.Titulo_FotoPersona;
                db.SaveChanges();
            }
        }

        public List<FotoPersonaCE> ObtenerListaFotosPersona(int Id_Persona)
        {
            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, fp.Id_FotoPersona, fp.Foto_FotoPersona, fp.Titulo_FotoPersona, fp.FKId_Persona_FotoPersona
                        from FotoPersona fp 
                        inner join Persona p on fp.FKId_Persona_FotoPersona = p.Id_Persona
                        where fp.FKId_Persona_FotoPersona = @Cod_persona";

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Database.SqlQuery<FotoPersonaCE>(sql, new SqlParameter("@Cod_persona", Id_Persona)).ToList();
            }
        }


    }
}
