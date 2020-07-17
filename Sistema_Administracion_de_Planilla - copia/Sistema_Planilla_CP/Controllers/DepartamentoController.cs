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
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var dptos = DepartamentoCN.ListarDepartamentos();
            return View(dptos);
        }



        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Departamento departamento)
        {
            try
            {
                if (departamento.Nombre_Departamento == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del departamento" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                departamento.FechaActualizacion_Departamento = DateTime.Now;
                DepartamentoCN.Crear(departamento);
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
            var departamento = DepartamentoCN.ObtenerDepartamento(id);
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Departamento departamento)
        {
            try
            {
                if (departamento.Nombre_Departamento == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del departamento" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                departamento.FechaActualizacion_Departamento = DateTime.Now;
                DepartamentoCN.Editar(departamento);
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
                DepartamentoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}