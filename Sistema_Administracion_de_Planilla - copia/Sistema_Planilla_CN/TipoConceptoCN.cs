using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class TipoConceptoCN
    {
        private static TipoConceptoCD obj = new TipoConceptoCD();
        public static List<TipoConcepto> ListarTipoConceptos()
        {
            return obj.ListarTipoConceptos();
        }
    }
}
