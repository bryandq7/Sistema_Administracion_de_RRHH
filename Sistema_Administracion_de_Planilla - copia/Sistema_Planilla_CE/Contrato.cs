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
    
    public partial class Contrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato()
        {
            this.Empleado = new HashSet<Empleado>();
        }
    
        public int Id_Contrato { get; set; }
        public decimal SalarioBruto_Contrato { get; set; }
        public System.DateTime FechaInicio_Contrato { get; set; }
        public Nullable<System.DateTime> FechaFin_Contrato { get; set; }
        public int FKId_TipoContrato_Contrato { get; set; }
        public string Nombre_Contrato { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual TipoContrato TipoContrato { get; set; }
    }
}
