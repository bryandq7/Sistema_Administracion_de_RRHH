using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class ContratoCN
    {
        private static ContratoCD obj = new ContratoCD();

        public static List<ContratoCE> ListarContratos()
        {
            return obj.ListarContratos();
        }

        public static void Crear(ContratoCE contrato1)
        {
            obj.Crear(contrato1);
        }

        //public static void EditarActivo(ContratoCE contrato)
        //{
        //    obj.EditarActivo(contrato);
        //}


    }
}
