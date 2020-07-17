using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class DistritoCE
    {
        public int Id_Distrito { get; set; }
        public string Nombre_Distrito { get; set; }
        public int FKIdCanton_Distrito { get; set; }
        public int Id_Canton { get; set; }
    }
}
