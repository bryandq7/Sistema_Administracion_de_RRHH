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
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.PlanillaEmpleado = new HashSet<PlanillaEmpleado>();
            this.Solicitud = new HashSet<Solicitud>();
            this.Solicitud1 = new HashSet<Solicitud>();
        }
    
        public int Id_Empleado { get; set; }
        public int FKId_Persona_Empleado { get; set; }
        public int FKId_Departamento_Empleado { get; set; }
        public int FKId_Cargo_Empleado { get; set; }
        public int FKId_Contrato_Empleado { get; set; }
        public int FKId_Vacaciones_Empleado { get; set; }
        public string FKId_Usuario_Empleado { get; set; }
    
        public virtual Vacaciones Vacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanillaEmpleado> PlanillaEmpleado { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Contrato Contrato { get; set; }
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud1 { get; set; }
    }
}
