using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softwood_v1._0.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuarios oUsuario;
        private BDContext db = new BDContext();
        private int idOperacion;

        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                oUsuario = (Usuarios)HttpContext.Current.Session["User"];
                var lstMisOperaciones = from m in db.Rol_Acceso
                          where m.Rol_ID == oUsuario.Rol_ID
                              && m.ID_Acceso == idOperacion //error encontrado y corregido
                          select m;


                if (lstMisOperaciones.ToList().Count() ==0)
                {
                    var oOperacion = db.Acceso.Find(idOperacion);
                    int? idModulo =oOperacion.ID_Modulo;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreDelModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=" + ex.Message);
            }
        }

        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.Acceso
                      where op.ID_Acceso == idOperacion
                      select op.Nombre_Operacion;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.Modulo
                         where m.ID_Modulo == idModulo
                         select m.Nombre_Modulo;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
    }
}