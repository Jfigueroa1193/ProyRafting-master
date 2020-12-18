using BackEnd.Entities;
using FrontEnd.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softwood_v1._0.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Usuarios oUsuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Usuarios)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is HomeController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Login");
                }
            }
            else
            {
                if (filterContext.Controller is HomeController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Reserva/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }

    }
}