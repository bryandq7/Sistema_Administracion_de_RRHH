using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class IncapacidadCE
    {
        public int Id_Incapacidad { get; set; }
        public decimal Dias_Incapacidad { get; set; }
        public bool Procesado_Incapacidad { get; set; }
        public int FKId_PeriodoDePago_Incapacidad { get; set; }
        public int FKId_TipoIncapacidad_Incapacidad { get; set; }
        public int FKId_Empleado_Incapacidad { get; set; }
        public System.DateTime FechaActualizacion_Incapacidad { get; set; }

        public int Id_TipoIncapacidad { get; set; }
        public string Nombre_TipoIncapacidad { get; set; }

        public int Id_Empleado { get; set; }
        public int FKId_Persona_Empleado { get; set; }
        public bool Activo_Empleado { get; set; }

        public int Id_PeriodoDePago { get; set; }
        public System.DateTime Periodo_PeriododDePago { get; set; }

        public int Id_Persona { get; set; }
        public string Nombre_Persona { get; set; }
        public string Apellido1_Persona { get; set; }
        public string Apellido2_Persona { get; set; }
        public string NombreCompletoPersona { get { return $"{Apellido1_Persona}{" "}{Apellido2_Persona}{", "}{Nombre_Persona}"; } }

    }
}
