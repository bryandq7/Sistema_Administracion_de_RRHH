using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class TipoConceptoController : Controller
    {
        // GET: TipoConcepto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTipoConceptos()
        {
            var lista = TipoConceptoCN.ListarTipoConceptos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}