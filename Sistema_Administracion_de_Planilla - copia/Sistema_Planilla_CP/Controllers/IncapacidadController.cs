using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class IncapacidadController : Controller
    {
        // GET: Incapacidad
        public ActionResult Index()
        {
            var incapacidades = IncapacidadCN.ListarIncapacidades();
            return View(incapacidades);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(IncapacidadCE incapacidad)
        {
            try
            {
                IncapacidadCN.Crear(incapacidad);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }


    }
}