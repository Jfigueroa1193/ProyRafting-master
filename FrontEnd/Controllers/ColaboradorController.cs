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
        private ColaboradorViewModel Convertir(Colaboradore colaborador)
        {
            ColaboradorViewModel colaboradorViewModel = new ColaboradorViewModel
            {
               Colaborador_ID = colaborador.Colaborador_ID,
               Nombre = colaborador.Nombre,
               Apellidos = colaborador.Apellidos,
               Telefono = (int)colaborador.Telefono,
               Correo = colaborador.Correo,
               Rol_ID = (int)colaborador.Rol_ID




            };
            return colaboradorViewModel;
        }// FIN DE CONVERTIR


        private Colaboradore Convertir(ColaboradorViewModel colaboradorViewModel)
        {
            Colaboradore ColaboradorViewModel = new Colaboradore
            {
                Colaborador_ID = colaboradorViewModel.Colaborador_ID,
                Nombre = colaboradorViewModel.Nombre,
                Apellidos = colaboradorViewModel.Apellidos,
                Telefono = (int)colaboradorViewModel.Telefono,
                Correo = colaboradorViewModel.Correo,
                Rol_ID = (int)colaboradorViewModel.Rol_ID

            };
            return ColaboradorViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Colaboradore> colaboradore;
            using (UnidadDeTrabajo<Colaboradore> Unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
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
            Colaboradore colaborador = this.Convertir(colaboradorViewModel);

            using (UnidadDeTrabajo<Colaboradore> unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
            {
                unidad.genericDAL.Add(colaborador);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Colaboradore colaborador;
            using (UnidadDeTrabajo<Colaboradore> unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
            {
                colaborador = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(colaborador));
        }


        [HttpPost]
        public ActionResult Edit(ColaboradorViewModel colaboradorViewModel)
        {


            using (UnidadDeTrabajo<Colaboradore> unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(colaboradorViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Colaboradore colaborador;
            using (UnidadDeTrabajo<Colaboradore> unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
            {
                colaborador = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(colaborador));
        }



        public ActionResult Delete(int id)
        {

            Colaboradore colaborador;
            using (UnidadDeTrabajo<Colaboradore> unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
            {
                colaborador = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(colaborador));
        }

        [HttpPost]
        public ActionResult Delete(ColaboradorViewModel colaboradorViewModel)
        {
            using (UnidadDeTrabajo<Colaboradore> unidad = new UnidadDeTrabajo<Colaboradore>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(colaboradorViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}