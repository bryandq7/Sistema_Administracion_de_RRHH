using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class StatusEmpleadoCN
    {
        private static StatusEmpleadoCD obj = new StatusEmpleadoCD();
        public static List<StatusEmpleado> ListarStatusEmpleados()
        {
            return obj.ListarStatusEmpleados();
        }
    }
}
