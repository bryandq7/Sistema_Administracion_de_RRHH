using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class FotoPersonaController : Controller
    {

        public ActionResult IrFotosPersona(int Id_Persona, string Nombre_Persona, string Apellido1_Persona, string Apellido2_Persona)
        {

            var fotopersona = FotoPersonaCN.ObtenerListaFotosPersona(Id_Persona);
            bool isEmpty = !fotopersona.Any();

            if (isEmpty)
            {
                return RedirectToAction("Add", "FotoPersona", new { Id_Persona = Id_Persona, Nombre_Persona = Nombre_Persona, Apellido1_Persona = Apellido1_Persona, Apellido2_Persona = Apellido2_Persona });

            }
            else
            {
                return RedirectToAction("DetallesFoto", "FotoPersona", new { idpersona = Id_Persona });
            }


        }



        // GET: FotoPersona
        public ActionResult Add(int Id_Persona, string Nombre_Persona, string Apellido1_Persona, string Apellido2_Persona)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(FotoPersonaCE foto)
        {
            try
            {

                var fotopersona = FotoPersonaCN.ObtenerListaFotosPersona(foto.Id_Persona);
                bool isEmpty = !fotopersona.Any();

                string fileName = Path.GetFileNameWithoutExtension(foto.ImageFile.FileName);
                string extension = Path.GetExtension(foto.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                foto.Foto_FotoPersona = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                foto.ImageFile.SaveAs(fileName);


                FotoPersonaCN.Crear(foto);
                //return Json(new { ok = true, toRedirect = Url.Action("DetallesFoto", "FotoPersona", new { id_persona = foto.Id_Persona }) }, JsonRequestBehavior.AllowGet);

                return RedirectToAction("DetallesFoto", "FotoPersona", new { idpersona = foto.Id_Persona });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar la foto - " + ex.Message);
                return RedirectToAction("Index", "Persona", new { idpersona = foto.Id_Persona });

                //return View();
            }

        }

        public ActionResult DetallesFoto(int idpersona)
        {
            var foto = FotoPersonaCN.ObtenerDetalles(idpersona);
            return View(foto);
        }

        public ActionResult Editar(int idpersona)
        {
            var foto = FotoPersonaCN.ObtenerDetalles(idpersona);
            return View(foto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(FotoPersonaCE foto)
        {
            try
            {

                string fileName = Path.GetFileNameWithoutExtension(foto.ImageFile.FileName);
                string extension = Path.GetExtension(foto.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                foto.Foto_FotoPersona = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                foto.ImageFile.SaveAs(fileName);


                FotoPersonaCN.Editar(foto);
                return RedirectToAction("DetallesFoto", "FotoPersona", new { idpersona = foto.Id_Persona });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar la foto - " + ex.Message);
                return RedirectToAction("Index", "Persona", new { idpersona = foto.Id_Persona });
            }
        }




    }
}