using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if (ModelState.IsValid)
            {
                // AQUÍ EL CÓDIGO DE VALIDACIÓN DEL USUARIO
                return RedirectToAction("LoginOk");
            }
            else
            {
                return View(loginDataModel);
            }
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