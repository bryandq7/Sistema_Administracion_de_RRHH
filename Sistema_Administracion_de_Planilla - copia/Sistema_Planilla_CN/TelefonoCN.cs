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

        public static TelefonoCE Crear(int idPersona)
        {
            return obj.Crear(idPersona);
        }

        public static void Crear(TelefonoCE telefono)
        {
            obj.Crear(telefono);
        }

        public static TelefonoCE Editar(int idTelefono)
        {
            return obj.Editar(idTelefono);
        }

        public static void Editar(TelefonoCE telefono)
        {
            obj.Editar(telefono);
        }

        public static void Eliminar(int id_telefono)
        {
            obj.Eliminar(id_telefono);
        }

        public static int ExisteTelefono(int personaID)
        {
            return obj.ExisteTelefono(personaID);
        }
    }
}
