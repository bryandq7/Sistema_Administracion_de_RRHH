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
        public int Id_Contrato { get; set; }
        public decimal SalarioBruto_Contrato { get; set; }
        public System.DateTime FechaInicio_Contrato { get; set; }
        public Nullable<System.DateTime> FechaFin_Contrato { get; set; }
        public int FKId_TipoContrato_Contrato { get; set; }
        public string Nombre_Contrato { get; set; }
        public int FKId_Empleado_Contrato { get; set; }
        public int FKId_Cargo_Contrato { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual TipoContrato TipoContrato { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
