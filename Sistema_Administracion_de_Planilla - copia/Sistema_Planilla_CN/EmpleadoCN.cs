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

        public static List<EmpleadoCE> ListarEmpleadosContratoVigente()
        {
            return obj.ListarEmpleadosContratoVigente();
        }

        public static void Crear(EmpleadoCE empleado)
        {
            obj.Crear(empleado);

        }

        public static EmpleadoCE ObtenerDetalleEmpleado(int idEmpleado)
        {
            return obj.ObtenerDetalleEmpleado(idEmpleado);
        }


        public static EmpleadoCE ObtenerIdEmpleado(int idPersona)
        {
            return obj.ObtenerIdEmpleado(idPersona);
        }

        public static void Editar(EmpleadoCE empleado)
        {
            obj.Editar(empleado);
        }


        public static bool ExisteEmpleado(int personaID)
        {
            return obj.ExisteEmpleado(personaID);
        }

        public static void Eliminar(int id_empleado)
        {
            obj.Eliminar(id_empleado);
        }

    }
}
