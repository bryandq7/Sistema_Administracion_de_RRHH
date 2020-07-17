using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class TipoContratoController : Controller
    {
        public ActionResult Index()
        {
            var tpcontr = TipoContratoCN.ListarTipoContratos();
            return View(tpcontr);
        }



        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(TipoContrato tipocontrato)
        {
            try
            {
                if (tipocontrato.Detalle_TipoContrato == null)
                    return Json(new { ok = false, msg = "Debe ingresar el detalle del tipo de contrato" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                tipocontrato.FechaActualizacion_TipoContrato = DateTime.Now;
                TipoContratoCN.Crear(tipocontrato);
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
            var tipocontrato = TipoContratoCN.ObtenerTipoContrato(id);
            return View(tipocontrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(TipoContrato tipocontrato)
        {
            try
            {
                if (tipocontrato.Detalle_TipoContrato == null)
                    return Json(new { ok = false, msg = "Debe ingresar el detalle del tipo de contrato" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                tipocontrato.FechaActualizacion_TipoContrato = DateTime.Now;
                TipoContratoCN.Editar(tipocontrato);
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
                TipoContratoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}