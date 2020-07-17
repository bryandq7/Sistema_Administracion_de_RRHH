using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class AspNetUserRolesController : Controller
    {
        // GET: AspNetUserRoles
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AsignarRoleausurio()
        {
            return View();
        }

    }
}