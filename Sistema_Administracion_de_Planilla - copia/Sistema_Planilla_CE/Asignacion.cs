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
    
    public partial class Asignacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asignacion()
        {
            this.PlanillaDeduccion = new HashSet<PlanillaDeduccion>();
        }
    
        public int Id_Asignacion { get; set; }
        public string Nombre_Asignacion { get; set; }
        public Nullable<decimal> Monto_Asignacion { get; set; }
        public Nullable<int> Dias_Asignacion { get; set; }
        public Nullable<decimal> Horas_Asignacion { get; set; }
        public bool AsignacionEditable_Asignacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanillaDeduccion> PlanillaDeduccion { get; set; }
    }
}