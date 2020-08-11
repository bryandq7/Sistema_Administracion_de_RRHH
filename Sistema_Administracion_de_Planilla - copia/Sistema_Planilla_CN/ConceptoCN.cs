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

        public static List<ConceptoCE> ListarConceptos(Nullable<int> impacta)
        {
            return obj.ListarConceptos(impacta);
        }


        public static void Crear(ConceptoCE concepto)
        {
            obj.Crear(concepto);

        }

        public static ConceptoCE ObtenerDetalleConcepto(int idconcepto)
        {
            return obj.ObtenerDetalleConcepto(idconcepto);
        }

        public static void Editar(ConceptoCE concepto)
        {
            if (concepto.Id_TipoConcepto == 1)
            {
                obj.EditarPorcentaje(concepto);
            }

            if (concepto.Id_TipoConcepto == 2)
            {
                obj.Editar(concepto);
            }

            if (concepto.Id_TipoConcepto == 3)
            {
                obj.EditarTiempo(concepto);
            }

            if (concepto.Id_TipoConcepto == 4)
            {
                obj.EditarDia(concepto);
            }
        }


        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }



    }
}
