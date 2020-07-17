using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class TipoSolicitudController : Controller
    {

        public ActionResult Index()
        {
            var tpsolic = TipoSolicitudCN.ListarTipoSolicitudes();
            return View(tpsolic);
        }



        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(TipoSolicitud tiposolicitud)
        {
            try
            {
                if (tiposolicitud.Detalle_TipoSolicitud == null)
                    return Json(new { ok = false, msg = "Debe ingresar el detalle del tipo de solictud" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                tiposolicitud.FechaActualizacion_TipoSolicitud = DateTime.Now;
                TipoSolicitudCN.Crear(tiposolicitud);
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
            var tiposolicitud = TipoSolicitudCN.ObtenerTipoSolicitud(id);
            return View(tiposolicitud);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(TipoSolicitud tiposolicitud)
        {
            try
            {
                if (tiposolicitud.Detalle_TipoSolicitud == null)
                    return Json(new { ok = false, msg = "Debe ingresar el detalle del tipo de solictud" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                tiposolicitud.FechaActualizacion_TipoSolicitud = DateTime.Now;
                TipoSolicitudCN.Editar(tiposolicitud);
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
                TipoSolicitudCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}