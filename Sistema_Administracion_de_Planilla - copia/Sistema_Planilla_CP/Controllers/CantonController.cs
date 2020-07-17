using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class CantonController : Controller
    {
        // GET: Canton
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetCantones(int Id_Provincia)
        //{
        //    var canton = CantonCN.ObtenerCantones(Id_Provincia);
        //    return View(canton);
        //}

        public JsonResult GetCantones(int Id_Provincia)
        {
            var lista = CantonCN.ObtenerCantones(Id_Provincia);
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}