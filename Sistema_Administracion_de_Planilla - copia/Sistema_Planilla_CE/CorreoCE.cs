using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class CorreoCE
    {
        public int Id_Persona { get; set; }
        public string Nombre_Persona { get; set; }
        public string Apellido1_Persona { get; set; }
        public string Apellido2_Persona { get; set; }
        public string NombreCompleto_Persona { get { return $"{Apellido1_Persona}{" "}{Apellido2_Persona}{", "}{Nombre_Persona}"; } }
        public int Id_Email { get; set; }
        public string Correo_Email { get; set; }
        public int FKId_Persona_Email { get; set; }
        public bool Primario_Email { get; set; }
    }
}
