using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class BancoCN
    {
        private static BancoCD obj = new BancoCD();
        public static List<Banco> ListarBancos()
        {
            return obj.ListarBancos();
        }

        public static void Crear(Banco banco)
        {
            obj.Crear(banco);
        }

        public static Banco ObtenerBanco(int id)
        {
            return obj.ObtenerBanco(id);
        }

        public static void Editar(Banco banco)
        {
            obj.Editar(banco);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
