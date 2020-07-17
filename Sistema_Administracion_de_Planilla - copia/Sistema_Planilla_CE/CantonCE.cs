using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class CantonCE
    {
        public int Id_Canton { get; set; }
        public string Nombre_Canton { get; set; }
        public int FKIdProvincia_Canton { get; set; }
        public int Id_Provincia { get; set; }
    }
}
