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
    
    public partial class PlanillaPatrono
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanillaPatrono()
        {
            this.PlanillaPatronoDetalle = new HashSet<PlanillaPatronoDetalle>();
        }
    
        public int Id_PlanillaPatrono { get; set; }
        public System.DateTime FechaActualizacion_PlanillaPatrono { get; set; }
        public int FKId_Empleado_PlanillaPatrono { get; set; }
        public int FKId_PeriodoDePago_PlanillaPatrono { get; set; }
        public decimal TotalMontoaPagar_PlanillaPatrono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanillaPatronoDetalle> PlanillaPatronoDetalle { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual PeriodoDePago PeriodoDePago { get; set; }
    }
}
