using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class EmpleadoCD
    {
        public List<EmpleadoCE> ListarEmpleados()
        {
            string sql = @"select u.Id as Id_Usuario, u.UserName,d.Id_Departamento,d.Nombre_Departamento,p.Id_Persona,p.Nombre_Persona+' '+p.Apellido1_Persona+' '+p.Apellido2_Persona as NombreCompletoPersona
                from Empleado e  
	            inner join AspNetUsers u  on u.Id = e.FKId_Usuario_Empleado
                inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona
				inner join Departamento d on e.FKId_Departamento_Empleado = d.Id_Departamento
                where e.Activo_Empleado = 1";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<EmpleadoCE>(sql).ToList();
            }
        }

        public bool ExisteEmpleado(int personaID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteEmpleado = db.Empleado
                    .Any(p => p.FKId_Persona_Empleado == personaID);

                return ExisteEmpleado;
            }
        }

        public void Eliminar(int id_persona, int id_empleado, string id_usuario)
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
                var userRole = db.AspNetUserRoles
                    .Where(e => e.UserId == id_usuario)
                    .ToList();
                db.AspNetUserRoles.RemoveRange(userRole);
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

            using (var db = new RecursosHumanosDBContext())
            {
                var empleado = db.Empleado
                    .Where(e => e.Id_Empleado == id_empleado)
                    .FirstOrDefault();
                empleado.Activo_Empleado = false;
                //db.Persona.Remove(persona);
                db.SaveChanges();
            }


            using (var db = new RecursosHumanosDBContext())
            {
                var persona = db.Persona
                    .Where(e => e.Id_Persona == id_persona)
                    .FirstOrDefault();
                persona.Activo_Persona = false;
                //db.Persona.Remove(persona);
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
