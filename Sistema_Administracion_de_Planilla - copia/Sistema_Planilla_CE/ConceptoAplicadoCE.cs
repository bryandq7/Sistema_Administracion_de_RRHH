using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CE
{
    public class ConceptoAplicadoCE
    {
        public int Id_ConceptoAplicado { get; set; }
        public decimal Cantidad_ConceptoAplicado { get; set; }
        public decimal Monto_ConceptoAplicado { get; set; }
        public int FKId_Empleado_ConceptoAplicado { get; set; }
        public int FKId_Concepto_ConceptoAplicado { get; set; }
        public int FKId_PeriodoDePago_ConceptoAplicado { get; set; }
        public bool Procesado_ConceptoAplicado { get; set; }

        public int Id_Empleado { get; set; }
        public int FKId_Persona_Empleado { get; set; }

        public int Id_Persona { get; set; }
        //public string Nombre_Persona { get; set; }
        //public string Apellido1_Persona { get; set; }
        //public string Apellido2_Persona { get; set; }
        public string NombreCompleto_Persona { get; set; }
        public int Id_Concepto { get; set; }
        public string Nombre_Concepto { get; set; }
        public bool Editable_Concepto { get; set; }
        public int FKId_TipoConcepto_Concepto { get; set; }
        public int FKId_DestinatarioConcepto_Concepto { get; set; }
        public int FKId_ImpactaPlanilla_Concepto { get; set; }
        public int FKId_ClaseConcepto_Concepto { get; set; }

        public int Id_PeriodoDePago { get; set; }
        public System.DateTime Periodo_PeriododDePago { get; set; }


        public int Id_Contrato { get; set; }
        public decimal SalarioBruto_Contrato { get; set; }
        public System.DateTime FechaInicio_Contrato { get; set; }
        public Nullable<System.DateTime> FechaFin_Contrato { get; set; }
        public int FKId_TipoContrato_Contrato { get; set; }
        public int FKId_Empleado_Contrato { get; set; }
        public bool Activo_Contrato { get; set; }
        public decimal SalarioBrutoPorDia_Contrato { get; set; }
        public decimal SalarioBrutoPorHora_Contrato { get; set; }
        public decimal SalarioBrutoQuincenal_Contrato { get; set; }

        public int Id_ClaseConcepto { get; set; }
        public string Detalle_ClaseConcepto { get; set; }

        public int Id_TipoConcepto { get; set; }
        public string Detalle_TipoConcepto { get; set; }

        public Nullable<System.DateTime> Fecha_ConceptoAplicado { get; set; }


    }
}
