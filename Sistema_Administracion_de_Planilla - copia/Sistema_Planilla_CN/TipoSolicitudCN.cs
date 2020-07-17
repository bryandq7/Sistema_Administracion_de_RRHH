using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class TipoSolicitudCN
    {
        private static TipoSolicitudCD obj = new TipoSolicitudCD();
        public static List<TipoSolicitud> ListarTipoSolicitudes()
        {
            return obj.ListarTipoSolicitudes();
        }

        public static void Crear(TipoSolicitud tiposolicitud)
        {
            obj.Crear(tiposolicitud);
        }

        public static TipoSolicitud ObtenerTipoSolicitud(int id)
        {
            return obj.ObtenerTipoSolicitud(id);
        }

        public static void Editar(TipoSolicitud tiposolicitud)
        {
            obj.Editar(tiposolicitud);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
