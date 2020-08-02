using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            var bancos = BancoCN.ListarBancos();
            return View(bancos);
        }

        public JsonResult GetBancos()
        {
            var lista = BancoCN.ListarBancos();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Banco Banco)
        {
            try
            {
                if (Banco.Nombre_Banco == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del Banco" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                Banco.FechaActualizacion_Banco = DateTime.Now;
                BancoCN.Crear(Banco);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Banco - " + ex.Message);
                //return View();
            }

        }

        public ActionResult Editar(int id)
        {
            var banco = BancoCN.ObtenerBanco(id);
            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Banco banco)
        {
            try
            {
                if (banco.Nombre_Banco == null)
                    return Json(new { ok = false, msg = "Debe ingresar el nombre del banco" }, JsonRequestBehavior.AllowGet);

                //System.Threading.Thread.Sleep(5000);
                banco.FechaActualizacion_Banco = DateTime.Now;
                BancoCN.Editar(banco);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Banco - " + ex.Message);
                //return View();
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int identificador)
        {
            try
            {
                BancoCN.Eliminar(identificador);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
