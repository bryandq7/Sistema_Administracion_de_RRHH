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

        public List<AspNetUsersCE> ListarAspNetUsers2()
        {
            string sql = @"select u.Id as UserId, u.UserName
                from  AspNetUsers u 
	            left JOIN Persona p on u.Id= p.FKId_Usuario_Persona	
				where p.FKId_Usuario_Persona is NULL";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<AspNetUsersCE>(sql).ToList();
            }
        }

        public bool ExisteUsuarioEnEmpleado(string usuarioId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteUsuarioEnEmpleado = db.Persona
                    .Any(p => p.FKId_Usuario_Persona == usuarioId);
                return ExisteUsuarioEnEmpleado;
            }
        }

        public int ExisteUnRolParaUsuario(string usuarioId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteUnUsuario = db.AspNetUserRoles
                    .Count(p => p.UserId == usuarioId);
                return ExisteUnUsuario;
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
                inner join Persona p on u.Id = p.FKId_Usuario_Persona";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<AspNetUserRolesCE>(sql).ToList();
            }
        }

        public List<AspNetUserRolesCE> ListarAsignacionesrolusuarionuevos()
        {
            string sql = @"select r.Id as RoleId, r.Name,u.Id as UserId,u.UserName
                from AspNetUserRoles ur 
                left join AspNetRoles r on ur.RoleId = r.Id
                left join AspNetUsers u on ur.UserId = u.Id
                left join Persona p on u.Id = p.FKId_Usuario_Persona
				where p.FKId_Usuario_Persona is NULL";

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

        public void EliminarUsuario(string usuarioId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var rolUsuario = db.AspNetUsers
                    .Where(e => e.Id == usuarioId )
                    .FirstOrDefault();
                db.AspNetUsers.Remove(rolUsuario);
                db.SaveChanges();
            }
        }



    }
}
