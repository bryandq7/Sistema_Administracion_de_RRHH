using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class FotoPersonaCN
    {

        private static FotoPersonaCD obj = new FotoPersonaCD();

        public static void Crear(FotoPersonaCE foto)
        {
            obj.Crear(foto);
        }


        public static FotoPersonaCE ObtenerDetalles(int idpersona)
        {
            return obj.ObtenerFoto(idpersona);
        }

        public static void Editar(FotoPersonaCE foto)
        {
            obj.Editar(foto);
        }

    }
}
