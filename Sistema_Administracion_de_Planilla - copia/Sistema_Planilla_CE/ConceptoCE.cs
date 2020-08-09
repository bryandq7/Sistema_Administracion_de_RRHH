using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class ConceptoCE
    {
        public int Id_Concepto { get; set; }
        public string Nombre_Concepto { get; set; }
        public bool Editable_Concepto { get; set; }
        public int FKId_TipoConcepto_Concepto { get; set; }
        public int FKId_DestinatarioConcepto_Concepto { get; set; }
        public int FKId_ImpactaPlanilla_Concepto { get; set; }
        public int FKId_ClaseConcepto_Concepto { get; set; }
        public Nullable<decimal> Porcentaje_Concepto { get; set; }
        public Nullable<decimal> MontoFijo_Concepto { get; set; }
        public bool DirectoPlanilla_Concepto { get; set; }

        public int Id_TipoConcepto { get; set; }
        public string Detalle_TipoConcepto { get; set; }

        public int Id_DestinatarioConcepto { get; set; }
        public string Nombre_DestinatarioConcepto { get; set; }

        public int Id_ImpactaPlanilla { get; set; }
        public string Detalle_ImpactaPlanilla { get; set; }

        public int Id_ClaseConcepto { get; set; }
        public string Detalle_ClaseConcepto { get; set; }

    }
}
