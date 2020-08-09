using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class ConceptoAplicadoCN
    {
        private static ConceptoAplicadoCD obj = new ConceptoAplicadoCD();

        public static List<ConceptoAplicadoCE> ListarConceptosAplicados()
        {
            return obj.ListarConceptosAplicados();
        }

        public static void Crear(ConceptoAplicadoCE concepto)
        {
            obj.Crear(concepto);

        }


        public static bool ConceptoTiempoExiste(int empleadoID, int conceptoID, DateTime? fecha)
        {
            return obj.ConceptoTiempoExiste(empleadoID, conceptoID, fecha);
        }

        public static int ObtenerIdEmpleado(int personaID)
        {

            return obj.ObtenerIdEmpleado(personaID);
        }

            public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
