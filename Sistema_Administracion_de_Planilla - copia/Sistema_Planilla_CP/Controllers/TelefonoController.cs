using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class TelefonoController : Controller
    {
        // GET: Telefono
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ObtenerListaTelefonosPersona(int Id_Persona)
        {
            var telefono = TelefonoCN.ObtenerListaTelefonosPersona(Id_Persona);
            return View(telefono);
        }
    }
}