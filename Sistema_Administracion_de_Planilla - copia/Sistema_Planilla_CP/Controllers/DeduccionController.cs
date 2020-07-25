using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class DeduccionController : Controller
    {
        // GET: Deduccion
        public ActionResult Index()
        {
            var deducciones = DeduccionCN.ListarDeducciones();
            return View(deducciones);
        }

        public ActionResult Editar(int id)
        {
            var deduccion = DeduccionCN.ObtenerDetalleDeduccion(id);
            return View(deduccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(DeduccionCE deduccion)
        {
            try
            {
                deduccion.FechaActualizacion_Deducion = DateTime.Now;
                DeduccionCN.Editar(deduccion);

                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}