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
    
    public partial class TipoIncapacidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoIncapacidad()
        {
            this.Incapacidad = new HashSet<Incapacidad>();
        }
    
        public int Id_TipoIncapacidad { get; set; }
        public string Nombre_TipoIncapacidad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incapacidad> Incapacidad { get; set; }
    }
}
