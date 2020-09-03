using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            CargarContratos();
            var contratos = ContratoCN.ListarContratos();
            return View(contratos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ContratoCE contrato)
        {
            try
            {
                if (contrato.FechaInicio_Contrato < DateTime.Today)
                    return Json(new { ok = false, msg = "La fecha de inicio del contrato no puede estar en el pasado" }, JsonRequestBehavior.AllowGet);


                var idempleado = ContratoCN.ObtenerIdEmpleado(contrato.Id_Persona);
                if (ContratoCN.ExisteContratoFecha(idempleado, contrato.FechaInicio_Contrato) == true)
                    return Json(new { ok = false, msg = "Ya existe un contrato asignado para este empleado con esta fecha de inicio" }, JsonRequestBehavior.AllowGet);

                ContratoCN.Crear(contrato);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                //return Json(new { ok = true, toRedirect = Url.Action("Index", "Contrato") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Contrato");
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Departamento - " + ex.Message);
                //return View();
            }

        }

        public ActionResult DetallesContrato(int id_contrato)
        {
            var contrato = ContratoCN.ObtenerDetalleContrato(id_contrato);
            return View(contrato);
        }

        public ActionResult Editar(int id)
        {
            var contrato = ContratoCN.ObtenerDetalleContrato(id);
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ContratoCE contrato)
        {
            try
            {
                //if (ContratoCN.ExisteEmpleado(contrato.Id_Persona) > 0 && ContratoCN.ObtenerEmpleadoActivo(contrato.Id_Persona) == false)
                //    return Json(new { ok = false, msg = "Debe cambiar el status de empleado a Activo para hacer cambios en este contrato" }, JsonRequestBehavior.AllowGet);

                ContratoCN.Editar(contrato);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CargarContratos()
        {
            try
            {
                var listacontratos = ContratoCN.CargarContratos();

                if (listacontratos.Any())
                {
                    foreach (var contrato in listacontratos)
                    {

                        var contratoactivoexiste = ContratoCN.ObtenerContratoActivo(contrato.FKId_Empleado_Contrato);

                        if (contratoactivoexiste == true)
                        {
                            var contratoactivo = ContratoCN.ObtenerObjetoContratoActivo(contrato.FKId_Empleado_Contrato);
                            ContratoCN.EditarDesactivar(contratoactivo);
       
                        }

                        ContratoCN.EditarActivar(contrato);
                    }
                }

                //return RedirectToAction("Iniciar sesión", "Login", "Account");

                return Json(new { ok = true, toRedirect = Url.Action("Index", "Home") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}