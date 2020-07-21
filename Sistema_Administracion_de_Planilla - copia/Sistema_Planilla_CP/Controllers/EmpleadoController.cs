using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            var empleados = EmpleadoCN.ListarEmpleados();
            return View(empleados);

        }


        public ActionResult Crear()
        {
            return View();
        }


        public ActionResult DetallesEmpleado(int id_empleado)
        {
            var empleado = EmpleadoCN.ObtenerDetalleEmpleado(id_empleado);
            return View(empleado);
        }


        [HttpPost]
        public ActionResult Eliminar(int id_persona, int id_empleado, string id_usuario)
        {

            try
            {
                PersonaCN.EliminarPersona(id_persona, id_usuario);
                EmpleadoCN.Eliminar(id_empleado);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}