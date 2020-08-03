using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class TurnosCN
    {
        private static TurnosCD obj = new TurnosCD();
        public static List<Turnos> ListarTurnos()
        {
            return obj.ListarTurnos();
        }
    }
}
