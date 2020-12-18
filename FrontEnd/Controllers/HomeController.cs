using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel loginDataModel)
        {
            try
            {
                using (BDContext unidad = new BDContext())

                {
                    string verifica = Encrypt.GetSha256(loginDataModel.Clave);
                    var oUser = (from d in unidad.Usuarios
                                 where d.Correo == loginDataModel.Correo.Trim() && d.Clave == verifica.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                    Session["User"] = oUser;
                    return RedirectToAction("Index", "Reserva");

                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        


            //if (ModelState.IsValid)
            //{
            //    String url = "";
            //    using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            //    {
            //        List<Usuarios> usuarios = unidad.genericDAL.GetAll().ToList();
            //        foreach (Usuarios usuario in usuarios) {
            //            if (usuario.Correo == loginDataModel.Correo) {
            //                if (usuario.Clave == Encrypt.GetSha256(loginDataModel.Clave))
            //                {
            //                    url = "Reserva/Index";
            //                }
            //            } else
            //            {
            //                ModelState.AddModelError("Credenciales incorrectas",new  Exception());
            //                url = "Login"; 
            //            }
            //        }
            //    }
            //    return RedirectToAction(url);
            //}
            //else
            //{
            //    return View(loginDataModel);
            //}
        }



        public ActionResult LoginOK()
        {
            // LA VALIDACIÓN DEL USUARIO HA SIDO CORRECTA
            return View();
        }

        public ActionResult Inicio()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}