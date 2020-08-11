using Sistema_Planilla_CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planilla_CD
{
    public class ConceptoAplicadoCD
    {

        public List<ConceptoAplicadoCE> ListarConceptosAplicados()
        {
            string sql = @"select ca.Id_ConceptoAplicado,ca.Cantidad_ConceptoAplicado,ca.Monto_ConceptoAplicado,FKId_Empleado_ConceptoAplicado,
                            ca.FKId_Concepto_ConceptoAplicado,ca.FKId_PeriodoDePago_ConceptoAplicado,e.Id_Empleado,e.FKId_Persona_Empleado,p.Id_Persona,
                             p.Apellido1_Persona+' '+p.Apellido2_Persona+' ,'+ p.Nombre_Persona As NombreCompleto_Persona,c.Id_Concepto,c.Nombre_Concepto,
                             c.Editable_Concepto,c.FKId_TipoConcepto_Concepto,c.FKId_DestinatarioConcepto_Concepto,c.FKId_ImpactaPlanilla_Concepto,
                             c.FKId_ClaseConcepto_Concepto,pp.Id_PeriodoDePago,pp.Periodo_PeriododDePago,ct.Id_Contrato,ct.SalarioBruto_Contrato,
                             ct.FechaInicio_Contrato,ct.FechaFin_Contrato,ct.FKId_TipoContrato_Contrato,ct.FKId_Empleado_Contrato,ct.Activo_Contrato,
                             ct.SalarioBrutoPorDia_Contrato,ct.SalarioBrutoPorHora_Contrato,ct.SalarioBrutoQuincenal_Contrato,cc.Id_ClaseConcepto,cc.Detalle_ClaseConcepto,
                             tc.Id_TipoConcepto,tc.Detalle_TipoConcepto,ca.Fecha_ConceptoAplicado
                            from ConceptoAplicado ca 
                            inner join Empleado e on ca.FKId_Empleado_ConceptoAplicado = e.Id_Empleado
                            inner join Persona p on e.FKId_Persona_Empleado = p.Id_Persona
                            inner join Concepto c on ca.FKId_Concepto_ConceptoAplicado = c.Id_Concepto
                            inner join PeriodoDePago pp on ca.FKId_PeriodoDePago_ConceptoAplicado = pp.Id_PeriodoDePago
                            inner join Contrato ct on e.Id_Empleado = ct.FKId_Empleado_Contrato
                            inner join ClaseConcepto cc on c.FKId_ClaseConcepto_Concepto = cc.Id_ClaseConcepto
                            inner join TipoConcepto tc on c.FKId_TipoConcepto_Concepto = tc.Id_TipoConcepto
                            where pp.Periodo_PeriododDePago <=DATEADD(day, 17, GetDate()) and pp.Periodo_PeriododDePago>GetDate() and ca.Procesado_ConceptoAplicado=0 and ct.Activo_Contrato=1";

            using (var db = new RecursosHumanosDBContext())
            {
                return db.Database.SqlQuery<ConceptoAplicadoCE>(sql).ToList();
            }
        }


        public int ObtenerIdEmpleado(int personaID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var ExisteEmpleado = db.Empleado
                    .Where(p => p.FKId_Persona_Empleado == personaID).FirstOrDefault();

                return ExisteEmpleado.Id_Empleado;
            }
        }


        public int ObtenerTipoConcepto(int conceptoID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var tipoConceptoId = db.Concepto
                    .Where(p => p.Id_Concepto == conceptoID).FirstOrDefault();

                return tipoConceptoId.FKId_TipoConcepto_Concepto;
            }
        }


        public bool ConceptoTiempoExiste(int empleadoID,int conceptoID, DateTime? fecha)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var existeconcepto = db.ConceptoAplicado
                    .Any(p => p.FKId_Concepto_ConceptoAplicado == conceptoID && p.FKId_Empleado_ConceptoAplicado == empleadoID && p.Fecha_ConceptoAplicado == fecha);

                return existeconcepto;
            }
        }

        public bool ConceptoExiste(int conceptoID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var existeconcepto = db.ConceptoAplicado
                    .Any(p => p.FKId_Concepto_ConceptoAplicado == conceptoID && p.Procesado_ConceptoAplicado == false);

                return existeconcepto;
            }
        }


        public Contrato ObtenerContrato(int EmpleadoId)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var contrato = db.Contrato
                    .Where(p => p.FKId_Empleado_Contrato == EmpleadoId && p.Activo_Contrato==true).FirstOrDefault();

                return contrato;
            }
        }

        public decimal? ObtenerFactorConcepto(int conceptoID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var factorConceptoId = db.Concepto
                    .Where(p => p.Id_Concepto == conceptoID).FirstOrDefault();

                return factorConceptoId.FactorTiempo_Concepto;
            }
        }

        public decimal? ObtenerPorcentajeConcepto(int conceptoID)
        {
            using (var db = new RecursosHumanosDBContext())
            {
                var factorConceptoId = db.Concepto
                    .Where(p => p.Id_Concepto == conceptoID).FirstOrDefault();

                return factorConceptoId.Porcentaje_Concepto;
            }
        }

        public void Crear(ConceptoAplicadoCE concepto)
        {

            var idempleado = ObtenerIdEmpleado(concepto.Id_Persona);

            var tipoConceptoId = ObtenerTipoConcepto(concepto.Id_Concepto);

            var contrato = ObtenerContrato(idempleado);


            decimal factor = ObtenerFactorConcepto(concepto.Id_Concepto)??0;
            decimal porcentaje = ObtenerPorcentajeConcepto(concepto.Id_Concepto) ?? 0;

            decimal cantidadconceptoAplicado = 0;
            decimal montoconceptoAplicado = 0;

            if (tipoConceptoId == 1)
            {
                cantidadconceptoAplicado = porcentaje;
                montoconceptoAplicado = (cantidadconceptoAplicado / 100) * contrato.SalarioBrutoQuincenal_Contrato;
            }


            if (tipoConceptoId == 2)
            {
                cantidadconceptoAplicado = 1;
                montoconceptoAplicado = concepto.Monto_ConceptoAplicado;
            }


            if (tipoConceptoId == 3 )
            {
                cantidadconceptoAplicado = concepto.Cantidad_ConceptoAplicado;
                montoconceptoAplicado = (cantidadconceptoAplicado * factor) *contrato.SalarioBrutoPorHora_Contrato;
            }


            if (tipoConceptoId == 4 )
            {
                cantidadconceptoAplicado = 1;
                montoconceptoAplicado = (cantidadconceptoAplicado * factor) * contrato.SalarioBrutoPorDia_Contrato;
            }

            var concepto1 = new ConceptoAplicado
            {
                Cantidad_ConceptoAplicado = cantidadconceptoAplicado,
                Monto_ConceptoAplicado = montoconceptoAplicado,
                FKId_Empleado_ConceptoAplicado = idempleado,
                FKId_Concepto_ConceptoAplicado = concepto.Id_Concepto,
                FKId_PeriodoDePago_ConceptoAplicado = concepto.FKId_PeriodoDePago_ConceptoAplicado,
                Procesado_ConceptoAplicado = concepto.Procesado_ConceptoAplicado,
                Fecha_ConceptoAplicado = concepto.Fecha_ConceptoAplicado
            };

            using (var db = new RecursosHumanosDBContext())
            {
                db.ConceptoAplicado.Add(concepto1);
                db.SaveChanges();
            }

        }


        public void Eliminar(int id)
        {
            using (var db = new RecursosHumanosDBContext())
            {

                var concepto = db.ConceptoAplicado.Find(id);
                db.ConceptoAplicado.Remove(concepto);
                db.SaveChanges();
            }

        }


    }
}
