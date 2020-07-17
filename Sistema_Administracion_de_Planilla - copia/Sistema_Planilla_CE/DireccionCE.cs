using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class DireccionCE
    {
        public int Id_Direccion { get; set; }
        public string Detalle_Direccion { get; set; }
        public int Id_Provincia { get; set; }
        public string Nombre_Provincia { get; set; }
        public int Id_Canton { get; set; }
        public string Nombre_Canton { get; set; }
        public int Id_Distrito { get; set; }
        public string Nombre_Distrito { get; set; }
        public string DetalleDireccionCompleto_Direccion { get { return $"{Detalle_Direccion}{Nombre_Provincia}{Nombre_Canton}{Nombre_Distrito}"; } }

    }
}
