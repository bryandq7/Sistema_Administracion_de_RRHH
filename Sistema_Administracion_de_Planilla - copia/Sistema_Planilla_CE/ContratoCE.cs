using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class ContratoCE
    {
        public int Id_Empleado { get; set; }
        public int FKId_Persona_Empleado { get; set; }
        public int FKId_Departamento_Empleado { get; set; }
        public int Id_Persona { get; set; }
        public string NombreCompletoPersona { get; set; }


        public int Id_Contrato { get; set; }
        public decimal SalarioBruto_Contrato { get; set; }
        public int FKId_TipoContrato_Contrato { get; set; }
        public int FKId_Empleado_Contrato { get; set; }
        public int FKId_Cargo_Contrato { get; set; }
        public System.DateTime FechaInicio_Contrato { get; set; }
        public Nullable<System.DateTime> FechaFin_Contrato { get; set; }
        public bool Activo_Contrato { get; set; }
        public int Id_TipoContrato { get; set; }
        public string Detalle_TipoContrato { get; set; }
        public int Id_Cargo { get; set; }
        public string Nombre_Cargo { get; set; }

        public int Id_Turno { get; set; }
        public string Nombre_Turno { get; set; }
        public int FKId_Turno_Contrato { get; set; }

    }
}
