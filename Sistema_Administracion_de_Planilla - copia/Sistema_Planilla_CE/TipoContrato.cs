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
    
    public partial class TipoContrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoContrato()
        {
            this.Contrato = new HashSet<Contrato>();
        }
    
        public int Id_TipoContrato { get; set; }
        public string Detalle_TipoContrato { get; set; }
        public System.DateTime FechaActualizacion_TipoContrato { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
