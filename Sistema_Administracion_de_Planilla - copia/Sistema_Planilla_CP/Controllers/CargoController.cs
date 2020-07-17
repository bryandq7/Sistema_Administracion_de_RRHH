using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    [Authorize(Roles = "Empleado")]
    public class CargoController : Controller
    {
        public ActionResult Index()
        {
            var dptos = CargoCN.ListarCargos();
            return View(dptos);
        }



        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Cargo cargo)
        {
            try
            {
                if (cargo.Nombre_Cargo == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                cargo.FechaActualizacion_Cargo = DateTime.Now;
                CargoCN.Crear(cargo);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Departamento - " + ex.Message);
                //return View();
            }

        }

        public ActionResult Editar(int id)
        {
            var cargo = CargoCN.ObtenerCargo(id);
            return View(cargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cargo cargo)
        {
            try
            {
                if (cargo.Nombre_Cargo == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                cargo.FechaActualizacion_Cargo = DateTime.Now;
                CargoCN.Editar(cargo);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Departamento - " + ex.Message);
                //return View();
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int identificador)
        {
            try
            {
                CargoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}