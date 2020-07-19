using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class EmpleadoCN
    {
        private static EmpleadoCD obj = new EmpleadoCD();

        public static List<EmpleadoCE> ListarEmpleados()
        {
            return obj.ListarEmpleados();
        }

        public static bool ExisteEmpleado(int personaID)
        {
            return obj.ExisteEmpleado(personaID);
        }

    }
}
