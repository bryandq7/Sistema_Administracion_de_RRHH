using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    [Authorize(Roles = "Empleado, Administrador")]
    public class AspNetRolesController : Controller
    {
        // GET: AspNetRoles
        public ActionResult Index()
        {
            var roles = AspNetRolesCN.ListarAspNetRoles();
            return View(roles);
        }

        public ActionResult ListarRoles()
        {
            try
            {
                var lista = AspNetRolesCN.ListarAspNetRoles();
                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}