using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ClaseConceptoController : Controller
    {
        // GET: ClaseConcepto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarClaseConceptos()
        {
            var lista = ClaseConceptoCN.ListarClaseConceptos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}