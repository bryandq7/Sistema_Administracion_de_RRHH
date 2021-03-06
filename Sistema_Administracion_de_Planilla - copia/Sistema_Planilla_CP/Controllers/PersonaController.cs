﻿using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            var personas = PersonaCN.ListarPersonas();
            return View(personas);

        }

        //public ActionResult ListarPersonasNOEmpleados()
        //{
        //    var personas = PersonaCN.ListarPersonasNOEmpleados();
        //    return View(personas);

        //}

        public JsonResult ListarPersonasNOEmpleados()
        {
            var lista = PersonaCN.ListarPersonasNOEmpleados();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(PersonaCE persona)
        {
            try
            {
                //if (cargo.Nombre_Cargo == null)
                //    return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);

                ////System.Threading.Thread.Sleep(5000);
                //cargo.FechaActualizacion_Cargo = DateTime.Now;
                PersonaCN.Crear(persona);
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
            var persona = PersonaCN.ObtenerDetallePersona(id);
            return View(persona);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PersonaCE persona)
        {
            try
            {
                PersonaCN.Editar(persona);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult DetallesPersona(int id_persona)
        {
            var persona = PersonaCN.ObtenerDetallePersona(id_persona);
            return View(persona);
        }

        [HttpPost]
        public ActionResult EliminarPersona(int id_persona, string id_usuario)
        {

            try
            {
                if (EmpleadoCN.ExisteEmpleado(id_persona))
                    return Json(new { ok = false, msg = "Esta persona es un empleado y debe eliminarla desde la Lista de Empleados" });
                PersonaCN.EliminarPersona(id_persona, id_usuario);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}