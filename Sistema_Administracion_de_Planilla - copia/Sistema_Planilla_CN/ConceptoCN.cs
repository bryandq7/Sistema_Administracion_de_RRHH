using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class ConceptoCN
    {
        private static ConceptoCD obj = new ConceptoCD();
        public static List<ConceptoCE> ObtenerConceptos(int Id_ClaseConcepto, int Id_TipoConcepto)
        {
            return obj.ObtenerConceptos(Id_ClaseConcepto, Id_TipoConcepto);
        }

        public static List<ConceptoCE> ListarConceptos()
        {
            return obj.ListarConceptos();
        }


    }
}
