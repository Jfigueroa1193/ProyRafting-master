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
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        private ColaboradorViewModel Convertir(Colaboradores colaborador)
        {
            ColaboradorViewModel colaboradorViewModel = new ColaboradorViewModel
            {
               Colaborador_ID = colaborador.Colaborador_ID,
               Nombre = colaborador.Nombre,
               Apellidos = colaborador.Apellidos,
               Telefono = colaborador.Telefono,
               Correo = colaborador.Correo,
               Rol_ID = (int)colaborador.Rol_ID




            };
            return colaboradorViewModel;
        }// FIN DE CONVERTIR


        private Colaboradores Convertir(ColaboradorViewModel colaboradorViewModel)
        {
            Colaboradores ColaboradorViewModel = new Colaboradores
            {
                Colaborador_ID = colaboradorViewModel.Colaborador_ID,
                Nombre = colaboradorViewModel.Nombre,
                Apellidos = colaboradorViewModel.Apellidos,
                Telefono = colaboradorViewModel.Telefono,
                Correo = colaboradorViewModel.Correo,
                Rol_ID = (int)colaboradorViewModel.Rol_ID

            };
            return ColaboradorViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Colaboradores> colaboradore;
            using (UnidadDeTrabajo<Colaboradores> Unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                colaboradore = Unidad.genericDAL.GetAll().ToList();
            }

            List<ColaboradorViewModel> lista = new List<ColaboradorViewModel>();

            foreach (var item in colaboradore)
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
        public ActionResult Create(ColaboradorViewModel colaboradorViewModel)
        {
            Colaboradores colaborador = this.Convertir(colaboradorViewModel);

            using (UnidadDeTrabajo<Colaboradores> unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                unidad.genericDAL.Add(colaborador);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Colaboradores colaborador;
            using (UnidadDeTrabajo<Colaboradores> unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                colaborador = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(colaborador));
        }


        [HttpPost]
        public ActionResult Edit(ColaboradorViewModel colaboradorViewModel)
        {


            using (UnidadDeTrabajo<Colaboradores> unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(colaboradorViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Colaboradores colaborador;
            using (UnidadDeTrabajo<Colaboradores> unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                colaborador = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(colaborador));
        }



        public ActionResult Delete(int id)
        {

            Colaboradores colaborador;
            using (UnidadDeTrabajo<Colaboradores> unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                colaborador = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(colaborador));
        }

        [HttpPost]
        public ActionResult Delete(ColaboradorViewModel colaboradorViewModel)
        {
            using (UnidadDeTrabajo<Colaboradores> unidad = new UnidadDeTrabajo<Colaboradores>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(colaboradorViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}