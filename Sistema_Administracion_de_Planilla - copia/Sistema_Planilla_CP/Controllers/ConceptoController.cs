using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ConceptoController : Controller
    {
        // GET: Concepto
        public ActionResult Index(Nullable<int> impacta)
        {
            var conceptos = ConceptoCN.ListarConceptos(impacta);
            return View(conceptos);
        }

        public JsonResult GetConceptos(int Id_ClaseConcepto, int Id_TipoConcepto)
        {
            var lista = ConceptoCN.ObtenerConceptos(Id_ClaseConcepto, Id_TipoConcepto);
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
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
        public ActionResult Crear(ConceptoCE concepto, int Id_TipoConcepto)
        {
            try
            {


                //if ((concepto.Cantidad_ConceptoAplicado > 4 || concepto.Cantidad_ConceptoAplicado < 1) && concepto.Id_Concepto == 23)
                //    return Json(new { ok = false, msg = "El mínimo de horas extra es de 1 y el máximo es de 4 diario" }, JsonRequestBehavior.AllowGet);

                //if ((concepto.Cantidad_ConceptoAplicado > 8 || concepto.Cantidad_ConceptoAplicado < 1) && concepto.Id_Concepto == 20)
                //    return Json(new { ok = false, msg = "El mínimo de horas de ausencia es de 1 y el máximo es de 8 diario" }, JsonRequestBehavior.AllowGet);

                //var empleadoID = ConceptoAplicadoCN.ObtenerIdEmpleado(concepto.Id_Persona);

                //DateTime? fecha = concepto.Fecha_ConceptoAplicado;

                //if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 18)
                //    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                //if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 20)
                //    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                //if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 23)
                //    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);


                //if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 26)
                //    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

                //if (ConceptoAplicadoCN.ConceptoTiempoExiste(empleadoID, concepto.Id_Concepto, fecha) == true && concepto.Id_Concepto == 27)
                //    return Json(new { ok = false, msg = "Este concepto ya existe para esta fecha y empleado" }, JsonRequestBehavior.AllowGet);

        

                ConceptoCN.Crear(concepto);
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

        public ActionResult Editar(int id)
        {
            var contrato = ConceptoCN.ObtenerDetalleConcepto(id);
            return View(contrato);
        }

        public ActionResult EditarPorcentaje(int id)
        {
            var contrato = ConceptoCN.ObtenerDetalleConcepto(id);
            return View(contrato);
        }

        public ActionResult EditarDia(int id)
        {
            var contrato = ConceptoCN.ObtenerDetalleConcepto(id);
            return View(contrato);
        }

        public ActionResult EditarTiempo(int id)
        {
            var contrato = ConceptoCN.ObtenerDetalleConcepto(id);
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ConceptoCE concepto)
        {
            try
            {
                if (ConceptoAplicadoCN.ConceptoExiste(concepto.Id_Concepto) == true)
                    return Json(new { ok = false, msg = "Este Concepto ya se ha aplicado para el siguiente periodo de pago, elimine el concepto aplicado o bien espere a la siguiente corrida de nómina para ejecutar esta acción" }, JsonRequestBehavior.AllowGet);

                ConceptoCN.Editar(concepto);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult Eliminar(int identificador)
        {
            try
            {
                if (ConceptoAplicadoCN.ConceptoExiste(identificador) == true)
                    return Json(new { ok = false, msg = "Este Concepto ya se ha aplicado para el siguiente periodo de pago, elimine el concepto aplicado o bien espere a la siguiente corrida de nómina para ejecutar esta acción" }, JsonRequestBehavior.AllowGet);
                ConceptoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}