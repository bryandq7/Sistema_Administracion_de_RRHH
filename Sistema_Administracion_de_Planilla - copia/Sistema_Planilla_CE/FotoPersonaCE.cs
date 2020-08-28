using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sistema_Planilla_CE
{
    public class FotoPersonaCE
    {

        public int Id_Persona { get; set; }
        public string Nombre_Persona { get; set; }
        public string Apellido1_Persona { get; set; }
        public string Apellido2_Persona { get; set; }
        public string NombreCompleto_Persona { get { return $"{Apellido1_Persona}{" "}{Apellido2_Persona}{", "}{Nombre_Persona}"; } }

        public int Id_FotoPersona { get; set; }

        [DisplayName("Upload File")]
        public string Foto_FotoPersona { get; set; }
        public string Titulo_FotoPersona { get; set; }
        public int FKId_Persona_FotoPersona { get; set; }
        public bool Primario_FotoPersona { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}
