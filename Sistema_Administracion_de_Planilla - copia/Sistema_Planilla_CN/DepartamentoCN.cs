using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class DepartamentoCN
    {
        private static DepartamentoCD obj = new DepartamentoCD();
        public static List<Departamento> ListarDepartamentos()
        {
            return obj.ListarDepartamentos();
        }

        public static List<DepartamentoCE> ListarDepartamentos2()
        {
            return obj.ListarDepartamentos2();
        }

            public static void Crear(Departamento departamento)
        {
            obj.Crear(departamento);
        }

        public static Departamento ObtenerDepartamento(int id)
        {
            return obj.ObtenerDepartamento(id);
        }

        public static void Editar(Departamento departamento)
        {
            obj.Editar(departamento);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}