using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class PersonaCD
    {
        //public List<PersonaCE> ListarPersonas()
        //{
        //    using (var db = new RecursosHumanosDBContext())
        //    {
        //        return db.Persona.ToList();
        //    }
        //}


        public List<PersonaCE> ListarPersonas()
        {
            string sql = @"select p.NumeroIdentidad_Persona, u.Id as Id_Usuario, u.UserName,p.Id_Persona,p.FKId_Usuario_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona,
                        p.FechaNacimiento_Persona,p.FKId_Email_Persona,e.Id_Email,e.Correo_Email, p.FKId_Email_Persona, d.Id_Direccion, 
                        d.Detalle_Direccion,pr.Id_Provincia,pr.Nombre_Provincia,c.Id_Canton,c.Nombre_Canton,di.Id_Distrito,di.Nombre_Distrito
                        from Persona p 
				        inner join Direccion d on p.FKId_Direccion_Persona=d.Id_Direccion
				        inner join Distrito di on d.FKIdDistrito_Direccion = di.Id_Distrito
                        inner join Canton c on di.FKIdCanton_Distrito = c.Id_Canton
                        inner join Provincia pr  on c.FKIdProvincia_Canton = pr.Id_Provincia
				        inner join Email e on p.FKId_Email_Persona = e.Id_Email
						inner join AspNetUsers u on p.FKId_Usuario_Persona = u.Id
                        where p.Activo_Persona = 1";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PersonaCE>(sql).ToList();
            }
        }

        public List<PersonaCE> ListarPersonasNOEmpleados()
        {
            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona,
                        e.Id_Empleado, p.FKId_Usuario_Persona
                        from Persona p 
				        left  join Empleado e on p.Id_Persona=e.FKId_Persona_Empleado
                        where p.Activo_Persona = 1 and p.FKId_Usuario_Persona is not NULL and e.Id_Empleado is NULL";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PersonaCE>(sql).ToList();
            }
        }

        public void Crear(PersonaCE persona)
        {
            var direccion = new Direccion
            {
                Detalle_Direccion = persona.Detalle_Direccion,
                FKIdDistrito_Direccion = persona.Id_Distrito

            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
            }

            var idultimoregistrodireccion = ObtenerIdDireccion();

            var correo = new Email
            {
                Correo_Email = persona.Correo_Email
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Email.Add(correo);
                db.SaveChanges();
            }

            var idultimoregistrocorreo = ObtenerIdEmail();

            var persona1 = new Persona
            {
                Nombre_Persona = persona.Nombre_Persona,
                Apellido1_Persona = persona.Apellido1_Persona,
                Apellido2_Persona = persona.Apellido2_Persona,
                FechaNacimiento_Persona = persona.FechaNacimiento_Persona,
                FKId_Direccion_Persona = idultimoregistrodireccion,
                FKId_Email_Persona = idultimoregistrocorreo,
                NumeroIdentidad_Persona = persona.NumeroIdentidad_Persona,
                FKId_Usuario_Persona = persona.Id_Usuario,
                Activo_Persona = true
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Persona.Add(persona1);
                db.SaveChanges();
            }

        }

        public int ObtenerIdDireccion()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Direccion.Max(p => p.Id_Direccion);
            }
        }

        public int ObtenerIdEmail()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Email.Max(p => p.Id_Email);
            }
        }

        public PersonaCE ObtenerDetallePersona(int idPersona)
        {

            string sql = @"select p.NumeroIdentidad_Persona,u.Id as Id_Usuario, u.UserName,p.FKId_Usuario_Persona,p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona,
                        p.FechaNacimiento_Persona,p.FKId_Email_Persona,e.Id_Email,e.Correo_Email, p.FKId_Email_Persona, d.Id_Direccion, 
                        d.Detalle_Direccion,pr.Id_Provincia,pr.Nombre_Provincia,c.Id_Canton,c.Nombre_Canton,di.Id_Distrito,di.Nombre_Distrito
                        from Persona p 
                        inner join Direccion d on p.FKId_Direccion_Persona=d.Id_Direccion
                        inner join Distrito di on d.FKIdDistrito_Direccion = di.Id_Distrito
                        inner join Canton c on di.FKIdCanton_Distrito = c.Id_Canton
                        inner join Provincia pr  on c.FKIdProvincia_Canton = pr.Id_Provincia
                        inner join Email e on p.FKId_Email_Persona = e.Id_Email
                        inner join AspNetUsers u on p.FKId_Usuario_Persona = u.Id
                        where p.Id_Persona = @Cod_Persona";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PersonaCE>(sql, new SqlParameter("@Cod_Persona", idPersona)).FirstOrDefault();
            }

        }

        public void Editar(PersonaCE persona)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var origen = db.Persona.Find(persona.Id_Persona);
                origen.Nombre_Persona = persona.Nombre_Persona;
                origen.Apellido1_Persona = persona.Apellido1_Persona;
                origen.Apellido2_Persona = persona.Apellido2_Persona;
                origen.FechaNacimiento_Persona = persona.FechaNacimiento_Persona;
                origen.NumeroIdentidad_Persona = persona.NumeroIdentidad_Persona;

                var origendireccion = db.Direccion.Find(persona.Id_Direccion);
                origendireccion.Detalle_Direccion = persona.Detalle_Direccion;
                origendireccion.FKIdDistrito_Direccion = persona.Id_Distrito;

                var origenemail = db.Email.Find(persona.Id_Email);
                origenemail.Correo_Email = persona.Correo_Email;
                db.SaveChanges();
            }
        }


        public void EliminarPersona(int id_persona, string id_usuario)
        {



            //using (var db = new RecursosHumanosDBContext())
            //{
            //    var telefono = db.Telefono
            //        .Where(e => e.FKId_Persona_Telefono == id_persona)
            //        .ToList();
            //    db.Telefono.RemoveRange(telefono);
            //    db.SaveChanges();
            //}


            using (var db = new RecursosHumanosDBContext())
            {
                var persona = db.Persona
                    .Where(e => e.Id_Persona == id_persona)
                    .FirstOrDefault();
                persona.FKId_Usuario_Persona = null;
                persona.Activo_Persona = false;
                //db.Persona.Remove(persona);
                db.SaveChanges();
            }

            using (var db = new RecursosHumanosDBContext())
            {
                var rolusuario = db.AspNetUserRoles
                    .Where(e => e.UserId == id_usuario)
                    .ToList();
                db.AspNetUserRoles.RemoveRange(rolusuario);
                db.SaveChanges();
            }

            using (var db = new RecursosHumanosDBContext())
            {
                var usuario = db.AspNetUsers
                    .Where(e => e.Id == id_usuario)
                    .FirstOrDefault();
                db.AspNetUsers.Remove(usuario);
                db.SaveChanges();
            }




 

            //using (var db = new RecursosHumanosDBContext())
            //{
            //    var direccion = db.Direccion
            //        .Where(e => e.Id_Direccion == id_direccion)
            //        .FirstOrDefault();
            //    db.Direccion.Remove(direccion);
            //    db.SaveChanges();
            //}

            //using (var db = new RecursosHumanosDBContext())
            //{
            //    var correo = db.Email
            //        .Where(e => e.Id_Email == id_email)
            //        .FirstOrDefault();
            //    db.Email.Remove(correo);
            //    db.SaveChanges();
            //}
        }


    }
}
