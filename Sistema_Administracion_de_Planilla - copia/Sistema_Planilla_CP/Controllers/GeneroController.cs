using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult Index()
        {
            var lista = GeneroCN.ListarGeneros();
            return View(lista);
        }

        public JsonResult GetGeneros()
        {
            var lista = GeneroCN.ListarGeneros();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}