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
        private UsuarioViewModel Convertir(Usuarios usuario)
        {
            UsuarioViewModel clienteViewModel = new UsuarioViewModel
            {
                Usuario_ID = usuario.Usuario_ID,
                NombreUsuario = usuario.NombreUsuario,
                Apellidos = usuario.Apellidos,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                Rol_ID = usuario.Rol_ID

            };
            return clienteViewModel;
        }// FIN DE CONVERTIR


        private Usuarios Convertir(UsuarioViewModel usuarioViewModel)
        {
            Usuarios UsuarioViewModel = new Usuarios           {
                Usuario_ID = usuarioViewModel.Usuario_ID,
                NombreUsuario = usuarioViewModel.NombreUsuario,
                Apellidos = usuarioViewModel.Apellidos,
                Nacionalidad = usuarioViewModel.Nacionalidad,
                Telefono = usuarioViewModel.Telefono,
                Correo = usuarioViewModel.Correo,
                Clave = usuarioViewModel.Clave,
                Rol_ID = usuarioViewModel.Rol_ID

            };
            return UsuarioViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Usuarios> usuarios;
            using (UnidadDeTrabajo<Usuarios> Unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
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
            Usuarios usuario = this.Convertir(usuarioViewModel);

            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                unidad.genericDAL.Add(usuario);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Usuarios usuario;
            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(usuario));
        }


        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {


            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(usuarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Usuarios usuario;
            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(usuario));
        }

        public ActionResult Delete(int id)
        {

            Usuarios usuario;
            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                usuario = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(usuario));
        }

        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usuarioViewModel)
        {
            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(usuarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}