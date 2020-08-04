using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class PeriodoDePagoController : Controller
    {
        // GET: PeriodoDePago
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerPeriododePago()
        {
            var lista = PeriodoDePagoCN.ObtenerPeriododePago();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}