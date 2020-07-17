using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class TelefonoCD
    {
        public List<TelefonoCE> ObtenerListaTelefonosPersona(int FKId_Persona_Telefono)
        {
            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, t.Id_Telefono,t.Numero_Telefono,t.FKId_Persona_Telefono 
                        from Telefono t 
                        inner join Persona p on t.FKId_Persona_Telefono = p.Id_Persona
                        where t.FKId_Persona_Telefono= @Cod_telefono";

            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Database.SqlQuery<TelefonoCE>(sql, new SqlParameter("@Cod_telefono", FKId_Persona_Telefono)).ToList();
            }
        }

        public TelefonoCE Crear(int idPersona)
        {

            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, t.Id_Telefono,t.Numero_Telefono,t.FKId_Persona_Telefono 
                        from Telefono t 
                        inner join Persona p on t.FKId_Persona_Telefono = p.Id_Persona
                        where t.FKId_Persona_Telefono= @Cod_Persona";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<TelefonoCE>(sql, new SqlParameter("@Cod_Persona", idPersona)).FirstOrDefault();
            }

        }

        public void Crear(TelefonoCE telefono)
        {
            var telefonoOrigen = new Telefono
            {
                Numero_Telefono = telefono.Numero_Telefono,
                FKId_Persona_Telefono = telefono.FKId_Persona_Telefono

            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Telefono.Add(telefonoOrigen);
                db.SaveChanges();
            }
        }


        public TelefonoCE Editar(int idTelefono)
        {

            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, t.Id_Telefono,t.Numero_Telefono,t.FKId_Persona_Telefono 
                        from Telefono t 
                        inner join Persona p on t.FKId_Persona_Telefono = p.Id_Persona
                        where t.Id_Telefono= @Cod_Telefono";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<TelefonoCE>(sql, new SqlParameter("@Cod_Telefono", idTelefono)).FirstOrDefault();
            }

        }


        public void Editar(TelefonoCE telefono)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Telefono.Find(telefono.Id_Telefono);
                origen.Numero_Telefono = telefono.Numero_Telefono;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id_telefono)
        {

            using (var db = new RecursosHumanosDBContext())
            {
                var telefono = db.Telefono
                    .Where(e => e.Id_Telefono == id_telefono).FirstOrDefault();
                db.Telefono.Remove(telefono);
                db.SaveChanges();
            }
        }
    }
}
