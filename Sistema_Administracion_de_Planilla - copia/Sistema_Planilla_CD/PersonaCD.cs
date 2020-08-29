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
                        p.FechaNacimiento_Persona, d.Id_Direccion, 
                        d.Detalle_Direccion,pr.Id_Provincia,pr.Nombre_Provincia,c.Id_Canton,c.Nombre_Canton,di.Id_Distrito,di.Nombre_Distrito,
						g.Id_Genero,g.Nombre_Genero, cta.Id_Cuenta, cta.Numero_Cuenta, cta.FKIdBanco_Cuenta ,bco.Id_Banco,bco.Nombre_Banco
                        from Persona p 
				        inner join Direccion d on p.Id_Persona=d.FKId_Persona_Direccion
				        inner join Distrito di on d.FKIdDistrito_Direccion = di.Id_Distrito
                        inner join Canton c on di.FKIdCanton_Distrito = c.Id_Canton
                        inner join Provincia pr  on c.FKIdProvincia_Canton = pr.Id_Provincia
						inner join AspNetUsers u on p.FKId_Usuario_Persona = u.Id
						inner join Genero g on p.FKId_Genero_Persona = g.Id_Genero
						inner join Cuenta cta on p.FKId_Cuenta_Persona = cta.Id_Cuenta
						inner join Banco bco on cta.FKIdBanco_Cuenta = bco.Id_Banco
                        where p.Activo_Persona = 1";


            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<PersonaCE>(sql).ToList();
            }
        }

        public List<PersonaCE> ListarPersonasNOEmpleados()
        {
            string sql = @"select p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona, p.FKId_Usuario_Persona
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


            //var idultimoregistrodireccion = ObtenerIdDireccion();

            //var correo = new Email
            //{
            //    Correo_Email = persona.Correo_Email,
            //    FKId_Persona_Email = persona.Id_Persona
            //};

            //using (var db = new RecursosHumanosDBContext())
            //{
            //    db.Email.Add(correo);
            //    db.SaveChanges();
            //}


            //var idultimoregistrocorreo = ObtenerIdEmail();


            var cuenta = new Cuenta
            {
                Numero_Cuenta = persona.Numero_Cuenta,
                FKIdBanco_Cuenta = persona.Id_Banco,
                FKId_Moneda_Cuenta = persona.Id_Moneda
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Cuenta.Add(cuenta);
                db.SaveChanges();
            }

            var idultimoregistrocuenta = ObtenerIdCuenta();

            var persona1 = new Persona
            {
                Nombre_Persona = persona.Nombre_Persona,
                Apellido1_Persona = persona.Apellido1_Persona,
                Apellido2_Persona = persona.Apellido2_Persona,
                FechaNacimiento_Persona = persona.FechaNacimiento_Persona,
                //FKId_Direccion_Persona = idultimoregistrodireccion,
                //FKId_Email_Persona = idultimoregistrocorreo,
                NumeroIdentidad_Persona = persona.NumeroIdentidad_Persona,
                FKId_Usuario_Persona = persona.Id_Usuario,
                FKId_Cuenta_Persona = idultimoregistrocuenta,
                FKId_Genero_Persona = persona.Id_Genero,
                Activo_Persona = true
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Persona.Add(persona1);
                db.SaveChanges();
            }

            var idultimoregistropersona = ObtenerIdMaxPersona();

            var direccion = new Direccion
            {
                Detalle_Direccion = persona.Detalle_Direccion,
                FKIdDistrito_Direccion = persona.Id_Distrito,
                FKIdCanton_Direccion = persona.Id_Canton,
                FKIdProvincia_Direccion = persona.Id_Provincia,
                FKId_Persona_Direccion = idultimoregistropersona
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
            }

            var correo = new Email
            {
                Correo_Email = persona.Correo_Email,
                FKId_Persona_Email = idultimoregistropersona,
                Primario_Email = true
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Email.Add(correo);
                db.SaveChanges();
            }

            var telefono = new Telefono
            {
                Numero_Telefono = persona.Numero_Telefono,
                FKId_Persona_Telefono= idultimoregistropersona,
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.Telefono.Add(telefono);
                db.SaveChanges();
            }

        }

        public int ObtenerMaxIdDireccion()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Direccion.Max(p => p.Id_Direccion);
            }
        }

        public int ObtenerIdMaxPersona()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Persona.Max(p => p.Id_Persona);
            }
        }

        public int ObtenerIdEmail()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Email.Max(p => p.Id_Email);
            }
        }

        public int ObtenerIdCuenta()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Cuenta.Max(p => p.Id_Cuenta);
            }
        }

        public PersonaCE ObtenerDetallePersona(int idPersona)
        {

            string sql = @"select p.NumeroIdentidad_Persona,u.Id as Id_Usuario, u.UserName,p.FKId_Usuario_Persona,p.Id_Persona,p.Nombre_Persona,p.Apellido1_Persona,p.Apellido2_Persona,
                        p.FechaNacimiento_Persona, d.Id_Direccion, 
                        d.Detalle_Direccion,pr.Id_Provincia,pr.Nombre_Provincia,c.Id_Canton,c.Nombre_Canton,di.Id_Distrito,di.Nombre_Distrito,
                        g.Id_Genero,g.Nombre_Genero, cta.Id_Cuenta, cta.Numero_Cuenta, cta.FKIdBanco_Cuenta, bco.Id_Banco,bco.Nombre_Banco,
						mo.Id_Moneda, mo.Nombre_Moneda
						from Persona p 
                        inner join Direccion d on p.Id_Persona=d.FKId_Persona_Direccion
                        inner join Distrito di on d.FKIdDistrito_Direccion = di.Id_Distrito
                        inner join Canton c on di.FKIdCanton_Distrito = c.Id_Canton
                        inner join Provincia pr  on c.FKIdProvincia_Canton = pr.Id_Provincia
                        inner join AspNetUsers u on p.FKId_Usuario_Persona = u.Id
						inner join Genero g on p.FKId_Genero_Persona = g.Id_Genero
						inner join Cuenta cta on p.FKId_Cuenta_Persona = cta.Id_Cuenta
						inner join Banco bco on cta.FKIdBanco_Cuenta = bco.Id_Banco
						inner join Moneda mo on cta.FKId_Moneda_Cuenta = mo.Id_Moneda
                        where p.Id_Persona =  @Cod_Persona";

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
                origen.FKId_Genero_Persona = persona.Id_Genero;

                var origencuenta = db.Cuenta.Find(persona.Id_Cuenta);
                origencuenta.Numero_Cuenta = persona.Numero_Cuenta;
                origencuenta.FKIdBanco_Cuenta = persona.Id_Banco;
                origencuenta.FKId_Moneda_Cuenta = persona.Id_Moneda;

                var origendireccion = db.Direccion.Find(ObtenerIdDirecc(persona.Id_Persona));
                origendireccion.Detalle_Direccion = persona.Detalle_Direccion;
                origendireccion.FKIdDistrito_Direccion = persona.Id_Distrito;
                origendireccion.FKIdCanton_Direccion = persona.Id_Canton;
                origendireccion.FKIdProvincia_Direccion = persona.Id_Provincia;
                //var origenemail = db.Email.Find(persona.Id_Email);
                //origenemail.Correo_Email = persona.Correo_Email;
                db.SaveChanges();
            }
        }

        public int ObtenerIdDirecc(int idpersona)
        {
            var direccion = new Direccion();

            using (var db = new RecursosHumanosDBContext())
            {
                direccion = db.Direccion.Where(p => p.FKId_Persona_Direccion == idpersona).FirstOrDefault();
            }
            return direccion.Id_Direccion;
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
                //persona.FKId_Usuario_Persona = "inactivo";
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

                var origenuser = db.AspNetUsers.Find(id_usuario);
                origenuser.PasswordHash= "AF1yDASQS5CFXsuQCSI0qbBlxD3uoKHAMnK/SVpCpCXpohO25uZwPxlHKpFlasuxwA==";
                //var usuario = db.AspNetUsers
                //    .Where(e => e.Id == id_usuario)
                //    .FirstOrDefault();
                //db.AspNetUsers.Remove(usuario);
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
