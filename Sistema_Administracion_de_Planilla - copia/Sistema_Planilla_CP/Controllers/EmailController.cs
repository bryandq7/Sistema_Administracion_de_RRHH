using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ObtenerListaCorreosPersona(int Id_Persona, string Nombre_Persona, string Apellido1_Persona, string Apellido2_Persona)
        {
            try
            {
                var correo = CorreoCN.ObtenerListaCorreosPersona(Id_Persona);
                bool isEmpty = !correo.Any();

                if (isEmpty)
                {
                    return RedirectToAction("Crear2", "Email", new { Id_Persona = Id_Persona, Nombre_Persona = Nombre_Persona, Apellido1_Persona = Apellido1_Persona, Apellido2_Persona = Apellido2_Persona });             
                }

                else
                {
                    return View(correo);
                   
                }
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult Crear2(int Id_Persona, string Nombre_Persona, string Apellido1_Persona, string Apellido2_Persona)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(CorreoCE correo)
        {
            try
            {
                CorreoCN.CrearOtro(correo);
                return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaCorreosPersona", "Email", new { id_persona = correo.Id_Persona }) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Editar(int Id_Email)
        {
            var correo = TelefonoCN.Editar(Id_Email);
            return View(correo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CorreoCE correo)
        {
            try
            {
                CorreoCN.Editar(correo);
                return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaCorreosPersona", "Email", new { id_persona = correo.FKId_Persona_Email }) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult EliminarCorreo(int id_email, int id_persona)
        {

            try
            {
                if (CorreoCN.ExisteCorreo(id_persona) == 1)
                    return Json(new { ok = false, msg = "Debe mantener al menos un correo en la lista" });
                CorreoCN.Eliminar(id_email);
                return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaCorreosPersona", "Email", new { id_persona = id_persona }) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}