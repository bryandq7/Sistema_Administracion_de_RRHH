using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class TelefonoCN
    {
        private static TelefonoCD obj = new TelefonoCD();
        public static List<TelefonoCE> ObtenerListaTelefonosPersona(int FKId_Persona_Telefono)
        {
            return obj.ObtenerListaTelefonosPersona(FKId_Persona_Telefono);
        }
    }
}
