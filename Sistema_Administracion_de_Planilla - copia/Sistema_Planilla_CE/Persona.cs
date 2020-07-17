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
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.BoletaCurso = new HashSet<BoletaCurso>();
            this.Telefono = new HashSet<Telefono>();
            this.Empleado = new HashSet<Empleado>();
        }
    
        public int Id_Persona { get; set; }
        public string Nombre_Persona { get; set; }
        public string Apellido1_Persona { get; set; }
        public string Apellido2_Persona { get; set; }
        public System.DateTime FechaNacimiento_Persona { get; set; }
        public int FKId_Direccion_Persona { get; set; }
        public int FKId_Email_Persona { get; set; }
        public string NumeroIdentidad_Persona { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoletaCurso> BoletaCurso { get; set; }
        public virtual Direccion Direccion { get; set; }
        public virtual Email Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefono> Telefono { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
