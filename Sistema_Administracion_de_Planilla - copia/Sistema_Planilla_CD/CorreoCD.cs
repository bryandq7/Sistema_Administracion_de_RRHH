using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class CorreoCD
    {
        public List<CorreoCE> ObtenerListaCorreosPersona(int FKId_Persona_Email)
        {
            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, e.Id_Email,e.Correo_Email,e.FKId_Persona_Email, e.Primario_Email 
                        from Email e
                        inner join Persona p on e.FKId_Persona_Email = p.Id_Persona
                        where e.FKId_Persona_Email= @Cod_Correo";

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Database.SqlQuery<CorreoCE>(sql, new SqlParameter("@Cod_Correo", FKId_Persona_Email)).ToList();
            }
        }

        public CorreoCE Crear(int idPersona)
        {

            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, e.Id_Email,e.Correo_Email,e.FKId_Persona_Email,e.Primario_Email 
                        from Email e 
                        inner join Persona p on e.FKId_Persona_Email = p.Id_Persona
                        where e.FKId_Persona_Email= @Cod_Persona";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<CorreoCE>(sql, new SqlParameter("@Cod_Persona", idPersona)).FirstOrDefault();
            }

        }

        public int ExisteCorreo(int personaID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteUnCorreo = db.Email
                    .Count(p => p.FKId_Persona_Email == personaID);

                return ExisteUnCorreo;
            }
        }

        //public void Crear(CorreoCE correo)
        //{
        //    var correoOrigen = new Email
        //    {
        //        Correo_Email = correo.Correo_Email,
        //        FKId_Persona_Email= correo.Id_Persona,
        //        Primario_Email = correo.Primario_Email

        //    };

        //    using (var db = new RecursosHumanosDBContext())
        //    {
        //        db.Email.Add(correoOrigen);
        //        db.SaveChanges();
        //    }
        //}

        public void CrearOtro(CorreoCE correo)
        {
            var correoOrigen = new Email
            {
                Correo_Email = correo.Correo_Email,
                FKId_Persona_Email = correo.Id_Persona,
                Primario_Email = false

            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Email.Add(correoOrigen);
                db.SaveChanges();
            }
        }


        public CorreoCE Editar(int idCorreo)
        {

            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, e.Id_Email,e.Correo_Email,e.FKId_Persona_Email, e.Primario_Email 
                        from Email e 
                        inner join Persona p on e.FKId_Persona_Email = p.Id_Persona
                        where e.Id_Email = @Cod_Correo";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<CorreoCE>(sql, new SqlParameter("@Cod_Correo", idCorreo)).FirstOrDefault();
            }

        }


        public void Editar(CorreoCE correo)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Email.Find(correo.Id_Email);
                origen.Correo_Email = correo.Correo_Email;
                origen.Primario_Email = correo.Primario_Email;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id_email)
        {

            using (var db = new RecursosHumanosDBContext())
            {
                var correo = db.Email
                    .Where(e => e.Id_Email == id_email).FirstOrDefault();
                db.Email.Remove(correo);
                db.SaveChanges();
            }
        }
    }
}
