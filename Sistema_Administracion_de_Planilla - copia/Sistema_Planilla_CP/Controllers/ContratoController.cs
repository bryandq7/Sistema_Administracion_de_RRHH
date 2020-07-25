﻿using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            var contratos = ContratoCN.ListarContratos();
            return View(contratos);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ContratoCE contrato)
        {
            try
            {
                //if (cargo.Nombre_Cargo == null)
                //    return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);

                ////System.Threading.Thread.Sleep(5000);
                //cargo.FechaActualizacion_Cargo = DateTime.Now;
                ContratoCN.Crear(contrato);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                //return Json(new { ok = true, toRedirect = Url.Action("Index", "Contrato") }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "Contrato");
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                //ModelState.AddModelError("", "Error al registrar Departamento - " + ex.Message);
                //return View();
            }

        }

        public ActionResult DetallesContrato(int id_contrato)
        {
            var contrato = ContratoCN.ObtenerDetalleContrato(id_contrato);
            return View(contrato);
        }

        public ActionResult Editar(int id)
        {
            var contrato = ContratoCN.ObtenerDetalleContrato(id);
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ContratoCE contrato)
        {
            try
            {
                ContratoCN.Editar(contrato);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}