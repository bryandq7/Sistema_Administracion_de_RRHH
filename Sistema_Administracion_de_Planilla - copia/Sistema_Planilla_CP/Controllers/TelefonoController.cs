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


        public ActionResult ObtenerListaTelefonosPersona(int Id_Persona, string Nombre_Persona, string Apellido1_Persona, string Apellido2_Persona)
        {
            //var telefono = TelefonoCN.ObtenerListaTelefonosPersona(Id_Persona);
            //    return View(telefono);
            try
            {
                var telefono = TelefonoCN.ObtenerListaTelefonosPersona(Id_Persona);
                bool isEmpty = !telefono.Any();

                if (isEmpty)
                {
                    //return View(telefono);
                    return RedirectToAction("Crear2", "Telefono", new { Id_Persona = Id_Persona, Nombre_Persona = Nombre_Persona, Apellido1_Persona = Apellido1_Persona, Apellido2_Persona = Apellido2_Persona });
                    //return Json(new { ok = true, toRedirect = Url.Action("Crear", "Telefono", new { Id_Persona = Id_Persona }) }, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return View(telefono);
                    //return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaTelefonosPersona", "Telefono", new { Id_Persona = Id_Persona }) }, JsonRequestBehavior.AllowGet);
                }
                //return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaTelefonosPersona", "Telefono", new { id_persona = Id_Persona }) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }



        //public ActionResult Crear(int Id_Persona)
        //{
        //    var telefono = TelefonoCN.Crear(Id_Persona);
        //    return View(telefono);
        //}

        public ActionResult Crear2(int Id_Persona, string Nombre_Persona, string Apellido1_Persona, string Apellido2_Persona)
        {
            //var telefono = TelefonoCN.Crear(Id_Persona);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(TelefonoCE telefono)
        {
            try
            {
                //if (cargo.Nombre_Cargo == null)
                //    return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);

                ////System.Threading.Thread.Sleep(5000);
                //cargo.FechaActualizacion_Cargo = DateTime.Now;
                TelefonoCN.Crear(telefono);
                return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaTelefonosPersona", "Telefono", new { id_persona = telefono.Id_Persona }) }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Departamento - " + ex.Message);
                //return View();
            }

        }

        public ActionResult Editar(int Id_Telefono)
        {
            var telefono = TelefonoCN.Editar(Id_Telefono);
            return View(telefono);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(TelefonoCE telefono)
        {
            try
            {
                TelefonoCN.Editar(telefono);
                return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaTelefonosPersona", "Telefono", new { id_persona = telefono.FKId_Persona_Telefono }) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult EliminarTelefono(int id_telefono, int id_persona)
        {

            try
            {
                if (TelefonoCN.ExisteTelefono(id_persona)==1)
                return Json(new { ok = false, msg = "Debe mantener al menos un teléfono en la lista" });
                TelefonoCN.Eliminar(id_telefono);
                return Json(new { ok = true, toRedirect = Url.Action("ObtenerListaTelefonosPersona", "Telefono", new { id_persona = id_persona }) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}