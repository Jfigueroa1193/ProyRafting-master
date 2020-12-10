using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        private ServicioViewModel Convertir(Servicio servicio)
        {
            ServicioViewModel servicioViewModel = new ServicioViewModel
            {
                Servicio_ID = servicio.Servicio_ID,
                Nombre = servicio.Nombre,
                Precio = (double)servicio.Precio

            };
            return servicioViewModel;
        }// FIN DE CONVERTIR
        private Servicio Convertir(ServicioViewModel servicioViewModel)
        {
            Servicio ServicioViewModel = new Servicio
            {
                Servicio_ID = servicioViewModel.Servicio_ID,
                Nombre = servicioViewModel.Nombre,
                Precio = servicioViewModel.Precio
            };
            return ServicioViewModel;
        }



        // GET: Historial
        public ActionResult Index()
        {
            List<Servicio> servicio;
            using (UnidadDeTrabajo<Servicio> Unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                servicio = Unidad.genericDAL.GetAll().ToList();
            }

            List<ServicioViewModel> lista = new List<ServicioViewModel>();

            foreach (var item in servicio)
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
        public ActionResult Create(ServicioViewModel servicioViewModel)
        {
            Servicio servicio = this.Convertir(servicioViewModel);

            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                unidad.genericDAL.Add(servicio);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Servicio servicio;
            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                servicio = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(servicio));
        }


        [HttpPost]
        public ActionResult Edit(ServicioViewModel servicioViewModel)
        {


            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(servicioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Servicio servicio;
            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                servicio = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(servicio));
        }



        public ActionResult Delete(int id)
        {

            Servicio servicio;
            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                servicio = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(servicio));
        }

        [HttpPost]
        public ActionResult Delete(ServicioViewModel servicioViewModel)
        {
            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(servicioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}