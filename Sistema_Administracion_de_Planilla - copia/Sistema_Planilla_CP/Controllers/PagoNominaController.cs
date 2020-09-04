using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class PagoNominaController : Controller
    {
        // GET: PagoNomina
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editar()
        {
            var periodo = PeriodoDePagoCN.ObtenerPeriododePagoObj();
            return View(periodo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalcularNomina( PeriodoDePago periodo)
        {

            int Id_PeriodoDePago = periodo.Id_PeriodoDePago;
            try
            {
                if (PeriodoDePagoCN.ObtenerPeriodoActivoYNOProcesado(Id_PeriodoDePago) == false)
                    return Json(new { ok = false, msg = "Este periodo no se encuentra activo o bien ya fue calculado" });
                if (PeriodoDePagoCN.AbiertoPeriodoNomina(Id_PeriodoDePago) == false)
                    return Json(new { ok = false, msg = "El periodo de cálculo de nómina aún no se encuentra abierto o ya se realizó para este periodo" });

                List<EmpleadoCE> listaempleadosplanilla = EmpleadoCN.ListarEmpleadosContratoVigentePlanilla();

                PeriodoDePagoCE periodopago = PeriodoDePagoCN.ObtenerPeriododePagoObj();

                if (!listaempleadosplanilla.Any())
                    return Json(new { ok = false, msg = "No existen empleados activos para procesar planilla" });

                if (listaempleadosplanilla.Any())
                {

                    List<ConceptoCE> listaconceptosautomaticosplanillatrabajador = ConceptoCN.ListarConceptosPlanilla(2);
                    List<ConceptoCE> listaconceptosautomaticosplanillapatrono = ConceptoCN.ListarConceptosPlanilla(1);



                    foreach (var empleado in listaempleadosplanilla)
                    {
                        Planilla planillaempleado = new Planilla();

                        planillaempleado.FechaActualizacion_Planilla = DateTime.Now;
                        planillaempleado.FKId_Empleado_Planilla = empleado.Id_Empleado;
                        planillaempleado.FKId_PeriodoDePago_Planilla = periodopago.Id_PeriodoDePago;
                        planillaempleado.TotalDeducciones_Planilla = 0;
                        planillaempleado.TotalAsignaciones_Planilla = 0;
                        planillaempleado.TotalMontoaPagar_Planilla = 0;
                        planillaempleado.PagoProcesado_Planilla = false;

                        PlanillaCN.CrearPlanillaEmpleado(planillaempleado);

                        bool ExistenConceptosAplicadosEmpleado = ConceptoAplicadoCN.ConceptoAplicadoExisteEmpleado(empleado.Id_Empleado, periodopago.Id_PeriodoDePago);
                        if (ExistenConceptosAplicadosEmpleado == true)
                        {
                            List<ConceptoAplicadoCE> listaconceptosaplicadostrabajador = ConceptoAplicadoCN.ListarConceptosAplicadosPlanilla(empleado.Id_Empleado);
                        }

                        foreach (var conceptoautomaticotrabajador in listaconceptosautomaticosplanillatrabajador)
                        {

                        }



                    }

                }











                return Json(new { ok = true, toRedirect = Url.Action("AsignarRolUsuario") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }




    }
}