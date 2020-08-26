using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class DeduccionCE
    {
        public int Id_Deduccion { get; set; }
        public string Nombre_Deduccion { get; set; }
        public decimal Porcentaje_Deduccion { get; set; }
        public int FKId_TipoDeduccion_Deduccion { get; set; }
        public System.DateTime FechaActualizacion_Deducion { get; set; }
        public int Id_TipoDeduccion { get; set; }
        public string Detalle_TipoDeduccion { get; set; }
        public int FKId_DestinatarioDeduccion_Deduccion { get; set; }
        public int Id_DestinatarioDeduccion { get; set; }
        public string Nombre_DestinatarioDeduccion { get; set; }
        public bool DeduccionEditable_Deduccion { get; set; }

        public decimal Monto_Deduccion { get; set; }
        public decimal Dias_Deduccion { get; set; }
        public decimal Horas_Deduccion { get; set; }
        public int FKId_AportadorDeduccion_Deduccion { get; set; }
        public int Id_AportadorDeduccion { get; set; }
        public string Detalle_AportadorDeduccion { get; set; }

    }
}
