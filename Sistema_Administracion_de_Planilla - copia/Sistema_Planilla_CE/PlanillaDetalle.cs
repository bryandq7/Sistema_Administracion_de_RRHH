//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Planilla_CE
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanillaDetalle
    {
        public int Id_PlanillaDetalle { get; set; }
        public int FKId_Planilla_PlanillaDetalle { get; set; }
        public decimal Cantidad_PlanillaDetalle { get; set; }
        public decimal Monto_PlanillaDetalle { get; set; }
        public int FKId_Concepto_PlanillaDetalle { get; set; }
        public bool PagoProcesado_PlanillaDetalle { get; set; }
    
        public virtual Concepto Concepto { get; set; }
        public virtual Planilla Planilla { get; set; }
    }
}
