using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class DireccionController : Controller
    {
        // GET: Direccion
        public ActionResult ObtenerDireccionDetalle(int id_direccion)
        {
            var direccion = DireccionCN.ObtenerDireccion(id_direccion);
            return View(direccion);

        }
    }
}
