using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class DistritoController : Controller
    {
        // GET: Distrito
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetDistritos()
        //{
        //    var lista = DistritoCN.ListarDistritos();
        //    return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetDistritos(int Id_Canton)
        {
            var lista = DistritoCN.ObtenerDistritos(Id_Canton);
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

    }
}