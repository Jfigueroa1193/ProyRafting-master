using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.Entities;
using BackEnd.DAL;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private UsuarioViewModel Convertir(Usuario usuario)
        {
            UsuarioViewModel clienteViewModel = new UsuarioViewModel
            {
                Usuario_ID = usuario.Usuario_ID,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = (int)usuario.Telefono,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                Rol_ID = usuario.Rol_ID




            };
            return clienteViewModel;
        }// FIN DE CONVERTIR


        private Usuario Convertir(UsuarioViewModel usuarioViewModel)
        {
            Usuario UsuarioViewModel = new Usuario            {
                Usuario_ID = usuarioViewModel.Usuario_ID,
                Nombre = usuarioViewModel.Nombre,
                Apellidos = usuarioViewModel.Apellidos,
                Nacionalidad = usuarioViewModel.Nacionalidad,
                Telefono = (int)usuarioViewModel.Telefono,
                Correo = usuarioViewModel.Correo,
                Clave = usuarioViewModel.Clave,
                Rol_ID = usuarioViewModel.Rol_ID

            };
            return UsuarioViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Usuario> usuarios;
            using (UnidadDeTrabajo<Usuario> Unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                usuarios = Unidad.genericDAL.GetAll().ToList();
            }

            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

            foreach (var item in usuarios)
            {
                lista.Add(this.Convertir(item));
            }




            return View(lista);
        }

        public ActionResult Create()
        {


            return View();
        }//FIN DE INDEX

        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            Usuario usuario = this.Convertir(usuarioViewModel);

            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                unidad.genericDAL.Add(usuario);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Usuario usuario;
            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(usuario));
        }


        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {


            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(usuarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Usuario usuario;
            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(usuario));
        }



        public ActionResult Delete(int id)
        {

            Usuario usuario;
            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(usuario));
        }

        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usuarioViewModel)
        {
            using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(usuarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}