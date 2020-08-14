using Newtonsoft.Json.Linq;
using Sistema_Planilla_CE;
using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    public class ImpuestoRentaController : Controller
    {
        // GET: ImpuestoRenta
        public ActionResult Index()
        {


            var impuestos = ImpuestoRentaCN.ListarImpuestoRenta();
            return View(impuestos);
        }


        [HttpPost]
        public ActionResult UpdateCustomer(ImpuestoRenta customer)
        {

            try
            {

                if (customer.MontoMaximo_ImpuestoRenta <= 0 )
                {
                    //return RedirectToAction("Index", "ImpuestoRentaController");
                    return Json(new { ok = false, msg = "Solo puede ingresar números positivos en este campo", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                    //return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);
                }

                if (customer.Porcentaje_ImpuestoRenta < 0)
                {
                    //return RedirectToAction("Index", "ImpuestoRentaController");
                    return Json(new { ok = false, msg = "Solo puede ingresar números positivos en este campo", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                    //return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);
                }

                if (customer.MontoMinimo_ImpuestoRenta != 0 && customer.Id_ImpuestoRenta == 1)
                {
                    //return RedirectToAction("Index", "ImpuestoRentaController");
                    return Json(new { ok = false, msg = "El Monto Mínimo para esta primera linea debe ser cero", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                    //return Json(new { ok = false, msg = "Debe ingresar el nombre del cargo" }, JsonRequestBehavior.AllowGet);
                }

                var maxIdImpuesto = ImpuestoRentaCN.ObtenerMaxIdImpuestoRenta();

                if (customer.Id_ImpuestoRenta == maxIdImpuesto && customer.MontoMaximo_ImpuestoRenta != null)
                {

                    return Json(new { ok = false, msg = "El campo de Monto Máximo para esta  linea debe estar vacío", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                }

                if (customer.MontoMaximo_ImpuestoRenta<= customer.MontoMinimo_ImpuestoRenta)
                {

                    return Json(new { ok = false, msg = "El Monto Máximo debe ser estrictamente mayor al monto Mínimo de la misma linea", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                }

                if (customer.MontoMaximo_ImpuestoRenta==0)
                {

                    return Json(new { ok = false, msg = "El Monto Máximo no puede ser cero", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                }

                if (customer.Id_ImpuestoRenta < maxIdImpuesto && customer.MontoMaximo_ImpuestoRenta == null)
                {
  
                    return Json(new { ok = false, msg = "El Monto Máximo no puede ser nulo o vacío", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                }


                var maxmontoImpuestosig = ImpuestoRentaCN.ObtenerMaxMontoSiguienteImpuestoRenta(customer.Id_ImpuestoRenta);

                if (customer.Id_ImpuestoRenta < 4 && customer.MontoMaximo_ImpuestoRenta >= (maxmontoImpuestosig-2))
                {

                    return Json(new { ok = false, msg = "El Monto Máximo no puede ser mayor o estar tan cerca del monto máximo de la siguiente linea", toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);

                }



                ImpuestoRentaCN.Editar(customer);
                return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
                //return new EmptyResult();
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


       


        //}
    }
}