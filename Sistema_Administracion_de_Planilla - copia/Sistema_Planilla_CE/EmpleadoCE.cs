using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class EmpleadoCE
    {
        public int Id_Empleado { get; set; }
        public string FKId_Usuario_Empleado { get; set; }
        public int FKId_Persona_Empleado { get; set; }
        public int FKId_Departamento_Empleado { get; set; }
        public string Id_Usuario { get; set; }
        public string UserName { get; set; }
        public int Id_Departamento { get; set; }
        public string Nombre_Departamento { get; set; }
        public int Id_Persona { get; set; }
        public string NombreCompletoPersona { get; set; }



    }
}
