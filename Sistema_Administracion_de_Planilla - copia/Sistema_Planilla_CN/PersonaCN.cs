using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class PersonaCN
    {
        private static PersonaCD obj = new PersonaCD();
        public static List<PersonaCE> ListarPersonas()
        {
            return obj.ListarPersonas();
        }

        public static List<PersonaCE> ListarPersonasNOEmpleados()
        {
            return obj.ListarPersonasNOEmpleados();
        }

            public static void Crear(PersonaCE persona)
        {
            obj.Crear(persona);
        }

        public static PersonaCE ObtenerDetallePersona(int idPersona)
        {
            return obj.ObtenerDetallePersona(idPersona);
        }

        public static void Editar(PersonaCE persona)
        {
            obj.Editar(persona);
        }

            public static void EliminarPersona(int id_persona, string id_usuario)
        {
            obj.EliminarPersona(id_persona, id_usuario);
        }





    }


}
