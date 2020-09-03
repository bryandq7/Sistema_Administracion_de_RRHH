using Sistema_Planilla_CD;
using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CN
{
    public class PlanillaCN
    {
        private static PlanillaCD obj = new PlanillaCD();
        public static void CrearPlanillaEmpleado(Planilla planilla)
        {
            obj.CrearPlanillaEmpleado(planilla);
        }
    }
}
