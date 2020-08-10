using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ConceptoAplicadoController : Controller
    {
        // GET: ConceptoAplicado
        public ActionResult Index()
        {
            var conceptos = ConceptoAplicadoCN.ListarConceptosAplicados();
            return View(conceptos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult CrearTiempo()
        {
            return View();
        }


        public ActionResult CrearDia()
        {
            return View();
        }

        public ActionResult CrearPorcentaje()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ConceptoAplicadoCE concepto)
        {
            try
            {


                if ((concepto.Cantidad_ConceptoAplicado > 4 || concepto.Cantidad_ConceptoAplicado < 1) && concepto.Id_Concepto == 23)
                    return Json(new { ok = false, msg = "El mínimo de horas extra es de 1 y el máximo es de 4 diario" }, JsonRequestBehavior.AllowGet);

                if ((concepto.Cantidad_ConceptoAplicado > 8 || concepto.Cantidad_ConceptoAplicado < 1) && concepto.Id_Concepto == 20)
                    return Json(new { ok = false, msg = "El mínimo de horas de ausencia es de 1 y el máximo es de 8 diario" }, JsonRequestBehavior.AllowGet);

                var empleadoID = ConceptoAplicadoCN.ObtenerIdEmpleado(concepto.Id_Persona);

                DateTime? fecha = concepto.Fecha_ConceptoAplicado;

                if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID,concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 18)
                    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 20)
                    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 23)
                    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);


                if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 26)
                    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 27)
                    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                var periodoanterior = PeriodoDePagoCN.ObtenerPeriodoAnterior();

                var fechaperiodoanterior = periodoanterior.Periodo_PeriododDePago;

                var periodoposterior = PeriodoDePagoCN.ObtenerPeriodoPosterior();

                var fechaperiodoposterior = periodoposterior.Periodo_PeriododDePago;

                if (concepto.Fecha_ConceptoAplicado<fechaperiodoanterior || concepto.Fecha_ConceptoAplicado > fechaperiodoposterior)
                    return Json(new { ok = false, msg = "La fecha elegida está fuera del periodo de pago actual" }, JsonRequestBehavior.AllowGet);


                //System.Threading.Thread.Sleep(5000);
                concepto.Procesado_ConceptoAplicado = false;

                var periodopago = PeriodoDePagoCN.ObtenerPeriododePago().FirstOrDefault();
                var idperiodopago = periodopago.Id_PeriodoDePago;
                concepto.FKId_PeriodoDePago_ConceptoAplicado = idperiodopago;

                //var empleado = EmpleadoCN.ObtenerIdEmpleado();
                //var idempleado = empleado.Id_Empleado;

                ConceptoAplicadoCN.Crear(concepto);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Departamento - " + ex.Message);
                //return View();
            }

        }









        [HttpPost]
        public ActionResult Eliminar(int identificador)
        {
            try
            {
                ConceptoAplicadoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}