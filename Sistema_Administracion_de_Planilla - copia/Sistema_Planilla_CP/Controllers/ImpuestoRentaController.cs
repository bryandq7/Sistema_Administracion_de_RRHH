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
            //using (CustomersEntities entities = new CustomersEntities())
            //{
            //    Customer updatedCustomer = (from c in entities.Customers
            //                                where c.CustomerId == customer.CustomerId
            //                                select c).FirstOrDefault();
            //    updatedCustomer.Name = customer.Name;
            //    updatedCustomer.Country = customer.Country;
            //    entities.SaveChanges();
            //}

            ImpuestoRentaCN.Editar(customer);
            return new EmptyResult();
        }


        //[HttpPost]
        //public ActionResult EditarImpuesto(int Id, decimal propertyName, decimal value)
        //{
        //    var status = false;
        //    var message = "";

        //    try
        //    {
        //        ImpuestoRentaCN.Editar(Id, propertyName, value);
        //        var response = new { value = value, status = status, message = message };
        //        JObject o = JObject.FromObject(response);
        //        return Content(o.ToString());
        //        //return Json(new { ok = true, toRedirect = Url.Action("Index") }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }




        //}
    }
}