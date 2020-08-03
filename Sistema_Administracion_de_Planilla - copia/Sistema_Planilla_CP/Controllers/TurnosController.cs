using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class TurnosController : Controller
    {
        // GET: Turno
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTurnos()
        {
            var lista = TurnosCN.ListarTurnos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}