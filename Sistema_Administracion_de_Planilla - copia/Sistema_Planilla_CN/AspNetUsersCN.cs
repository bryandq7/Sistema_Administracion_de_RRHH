using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class AspNetUsersCN
    {
        private static AspNetUsersCD obj = new AspNetUsersCD();
        public static List<AspNetUsers> ListarAspNetUsers()
        {
            return obj.ListarAspNetUsers();
        }

        public static List<AspNetUsersCE> ListarAspNetUsers2()
        {
            return obj.ListarAspNetUsers2();
        }

        public static void AsignarRolUsuario(string usuarioId, string rolId)
        {
            obj.AsignarRolUsuario(usuarioId, rolId);
        }

        public static bool ExisteAsignacionrolusuario(string usuarioId, string rolId)
        {
            return obj.ExisteAsignacionrolusuario(usuarioId, rolId);

        }

        public static List<AspNetUserRolesCE> ListarAsignacionesrolusuario()
        {
            return obj.ListarAsignacionesrolusuario();
        }

        public static List<AspNetUserRolesCE> ListarAsignacionesrolusuarionuevos()
        {
            return obj.ListarAsignacionesrolusuarionuevos();
        }

        public static bool ExisteUsuarioEnEmpleado(string usuarioId)
        {
            return obj.ExisteUsuarioEnEmpleado(usuarioId);
        }


        public static void EliminarAsignacionRolUsuario(string usuarioId, string rolId)
        {
            obj.EliminarAsignacionRolUsuario(usuarioId, rolId);
        }

        public static void EliminarUsuario(string usuarioId, string rolId)
        {
            obj.EliminarAsignacionRolUsuario(usuarioId, rolId);
            obj.EliminarUsuario(usuarioId);

        }

        public static int ExisteUnRolParaUsuario(string usuarioId)
        {

            return obj.ExisteUnRolParaUsuario(usuarioId);
        }
    }
}
