using Sistema_Planilla_CN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP.Controllers
{
    [Authorize(Roles = "Empleado, Administrador")]
    public class AspNetUsersController : Controller
    {

        // GET: AspNetUsers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AsignarRolUsuario()
        {
            return View(AspNetUsersCN.ListarAsignacionesrolusuario());

        }

        public ActionResult ListarRolusuarioNuevos()
        {
            return View(AspNetUsersCN.ListarAsignacionesrolusuarionuevos());

        }

        public ActionResult ListarAsignacionesrolusuario()
        {
            return View(AspNetUsersCN.ListarAsignacionesrolusuario());

        }




        public ActionResult ListarUsuarios()
        {
            try
            {
                var lista = AspNetUsersCN.ListarAspNetUsers();
                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult ListarUsuarios2()
        {
            try
            {
                var lista = AspNetUsersCN.ListarAspNetUsers2();
                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult AsignarRolUsuario(string usuarioId, string rolId)
        {

            try
            {
                if (AspNetUsersCN.ExisteAsignacionrolusuario(usuarioId, rolId))
                    return Json(new { ok = false, msg = "Ya existe esta relación entre usuario y rol" });
                if (AspNetUsersCN.ExisteUsuarioEnEmpleado(usuarioId)==false)
                    return Json(new { ok = false, msg = "No se ha asignado un perfil de persona para este usuario. Por favor asigne un perfil de persona primero e intentelo de nuevo" });
                AspNetUsersCN.AsignarRolUsuario(usuarioId, rolId);
                return Json(new { ok = true, toRedirect = Url.Action("AsignarRolUsuario") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EliminarAsignacionRolUsuario(string usuarioId, string rolId)
        {

            try
            {
                if (AspNetUsersCN.ExisteUnRolParaUsuario(usuarioId)==1)
                    return Json(new { ok = false, msg = "Debe al menos existir una asignacion de Rol para este usuario" });
                AspNetUsersCN.EliminarAsignacionRolUsuario(usuarioId, rolId);
                return Json(new { ok = true, toRedirect = Url.Action("AsignarRolUsuario") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EliminarAsignacionRolUsuarioSeg(string usuarioId, string rolId)
        {

            try
            {
                if (AspNetUsersCN.ExisteUnRolParaUsuario(usuarioId) == 1)
                    return Json(new { ok = false, msg = "Debe al menos existir una asignacion de Rol para este usuario" });
                AspNetUsersCN.EliminarAsignacionRolUsuario(usuarioId, rolId);
                return Json(new { ok = true, toRedirect = Url.Action("ListarAsignacionesrolusuario") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EliminarUsuario(string usuarioId, string rolId)
        {

            try
            {
                AspNetUsersCN.EliminarUsuario(usuarioId, rolId);
                return Json(new { ok = true, toRedirect = Url.Action("ListarRolusuarioNuevos") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



    }

}
