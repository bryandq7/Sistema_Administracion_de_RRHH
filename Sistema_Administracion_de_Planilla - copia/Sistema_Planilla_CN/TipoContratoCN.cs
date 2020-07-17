using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class TipoContratoCN
    {
        private static TipoContratoCD obj = new TipoContratoCD();
        public static List<TipoContrato> ListarTipoContratos()
        {
            return obj.ListarTipoContratos();
        }

        public static void Crear(TipoContrato tipocontrato)
        {
            obj.Crear(tipocontrato);
        }

        public static TipoContrato ObtenerTipoContrato(int id)
        {
            return obj.ObtenerTipoContrato(id);
        }

        public static void Editar(TipoContrato tipocontrato)
        {
            obj.Editar(tipocontrato);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
