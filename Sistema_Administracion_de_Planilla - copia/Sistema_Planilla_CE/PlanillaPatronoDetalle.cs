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
    
    public partial class PlanillaPatronoDetalle
    {
        public int Id_PlanillaPatronoDetalle { get; set; }
        public int FKId_Planilla_PlanillaPatronoDetalle { get; set; }
        public decimal Cantidad_PlanillaPatronoDetalle { get; set; }
        public decimal Monto_PlanillaPatronoDetalle { get; set; }
        public int FKId_Concepto_PlanillaPatronoDetalle { get; set; }
    
        public virtual Concepto Concepto { get; set; }
        public virtual PlanillaPatrono PlanillaPatrono { get; set; }
    }
}
