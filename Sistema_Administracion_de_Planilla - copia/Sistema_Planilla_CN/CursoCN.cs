using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class CursoCN
    {
        private static CursoCD obj = new CursoCD();
        public static List<Curso> ListarCursos()
        {
            return obj.ListarCursos();
        }

        public static void Crear(Curso curso)
        {
            obj.Crear(curso);
        }

        public static Curso ObtenerCurso(int id)
        {
            return obj.ObtenerCurso(id);
        }

        public static void Editar(Curso curso)
        {
            obj.Editar(curso);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
