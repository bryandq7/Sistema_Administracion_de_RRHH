using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            var cursos = CursoCN.ListarCursos();
            return View(cursos);
        }



        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Curso curso)
        {
            try
            {
                if (curso.Nombre_Curso == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del curso" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                curso.FechaActualizacion_Curso = DateTime.Now;
                CursoCN.Crear(curso);
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
            var curso = CursoCN.ObtenerCurso(id);
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curso curso)
        {
            try
            {
                if (curso.Nombre_Curso == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del curso" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                curso.FechaActualizacion_Curso = DateTime.Now;
                CursoCN.Editar(curso);
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
                CursoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}