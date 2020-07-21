using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class CargoCN
    {
        private static CargoCD obj = new CargoCD();
        public static List<Cargo> ListarCargos()
        {
            return obj.ListarCargos();
        }

        public static List<EmpleadoCE> ListarCargos2()
        {
            return obj.ListarCargos2();
        }

            public static void Crear(Cargo cargo)
        {
            obj.Crear(cargo);
        }

        public static Cargo ObtenerCargo(int id)
        {
            return obj.ObtenerCargo(id);
        }

        public static void Editar(Cargo cargo)
        {
            obj.Editar(cargo);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
