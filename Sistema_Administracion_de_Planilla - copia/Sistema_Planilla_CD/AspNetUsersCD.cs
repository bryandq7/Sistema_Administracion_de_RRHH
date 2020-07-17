using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class AspNetUsersCD
    {
        public List<AspNetUsers> ListarAspNetUsers()
        {
            using (var db = new RecursosHumanosDBContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.AspNetUsers.ToList();
            }
        }

        public bool ExisteUsuarioEnEmpleado(string usuarioId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteUsuarioEnEmpleado = db.Empleado
                    .Any(p => p.FKId_Usuario_Empleado == usuarioId);
                return ExisteUsuarioEnEmpleado;
            }
        }


        public bool ExisteAsignacionrolusuario(string usuarioId, string rolId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteAsignacionrolusuario = db.AspNetUserRoles
                    .Any(p => p.UserId == usuarioId && p.RoleId == rolId);
                return ExisteAsignacionrolusuario;
            }
        }
        public void AsignarRolUsuario(string usuarioId, string rolId)
        {
            var rolusuario = new AspNetUserRoles
            {
                UserId = usuarioId,
                RoleId = rolId
            };
            using (var db = new RecursosHumanosDBContext())
            {
                db.AspNetUserRoles.Add(rolusuario);
                db.SaveChanges();


            }
        }

        public List<AspNetUserRolesCE> ListarAsignacionesrolusuario()
        {
            string sql = @"select ur.RoleId, r.Name,ur.UserId,u.UserName,p.Id_Persona,p.Nombre_Persona+' '+p.Apellido1_Persona+' '+p.Apellido2_Persona as NombreCompletoPersona
                from AspNetUserRoles ur 
                inner join AspNetRoles r on ur.RoleId = r.Id
                inner join AspNetUsers u on ur.UserId = u.Id
                inner join Empleado e  on u.Id = e.FKId_Usuario_Empleado
                inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona";
            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<AspNetUserRolesCE>(sql).ToList();
            }
        }

        public void EliminarAsignacionRolUsuario(string usuarioId, string rolId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var rolUsuario = db.AspNetUserRoles
                    .Where(e => e.UserId == usuarioId && e.RoleId == rolId)
                    .FirstOrDefault();
                db.AspNetUserRoles.Remove(rolUsuario);
                db.SaveChanges();
            }
        }



    }
}
