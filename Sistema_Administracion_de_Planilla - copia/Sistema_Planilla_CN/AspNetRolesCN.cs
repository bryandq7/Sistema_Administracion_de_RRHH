using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class AspNetRolesCN
    {
        private static AspNetRolesCD obj = new AspNetRolesCD();
        public static List<AspNetRoles> ListarAspNetRoles()
        {
            return obj.ListarAspNetRoles();
        }
    }
}
