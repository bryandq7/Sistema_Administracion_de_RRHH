using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ConceptoController : Controller
    {
        // GET: Concepto
        public ActionResult Index()
        {
            var conceptos = ConceptoCN.ListarConceptos();
            return View(conceptos);
        }

        public JsonResult GetConceptos(int Id_ClaseConcepto, int Id_TipoConcepto)
        {
            var lista = ConceptoCN.ObtenerConceptos(Id_ClaseConcepto, Id_TipoConcepto);
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}