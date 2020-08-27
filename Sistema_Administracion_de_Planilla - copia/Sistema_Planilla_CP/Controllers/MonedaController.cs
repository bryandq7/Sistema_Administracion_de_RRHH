using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class MonedaController : Controller
    {
        // GET: Moneda
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMonedas()
        {
            var lista = MonedaCN.ListarMonedas();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}