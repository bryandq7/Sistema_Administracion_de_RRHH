using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class CorreoCN
    {
        private static CorreoCD obj = new CorreoCD();
        public static List<CorreoCE> ObtenerListaCorreosPersona(int FKId_Persona_Email)
        {
            return obj.ObtenerListaCorreosPersona(FKId_Persona_Email);
        }

        public static CorreoCE Crear(int idPersona)
        {
            return obj.Crear(idPersona);
        }

        public static void Crear(CorreoCE correo)
        {
            obj.Crear(correo);
        }

        public static CorreoCE Editar(int idCorreo)
        {
            return obj.Editar(idCorreo);
        }

        public static void Editar(CorreoCE correo)
        {
            obj.Editar(correo);
        }

        public static void Eliminar(int id_email)
        {
            obj.Eliminar(id_email);
        }

        public static int ExisteCorreo(int personaID)
        {
            return obj.ExisteCorreo(personaID);
        }

    }
}
