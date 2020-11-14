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
    public class EquipoController : Controller
    {
        // GET: Equipo
        
        private EquipoViewModel Convertir(Equipo equipo)
        {
            EquipoViewModel equipoViewModel = new EquipoViewModel
            {
                Equipo_ID = equipo.Equipo_ID,
                Nombre = equipo.Nombre,
                Estado = equipo.Estado,
                Observacion = equipo.Observacion,
                Cantidad = equipo.Cantidad
               




            };
            return equipoViewModel;
        }// FIN DE CONVERTIR


        private Equipo Convertir(EquipoViewModel equipoViewModel)
        {
            Equipo EquipoViewModel = new Equipo
            {
                Equipo_ID = equipoViewModel.Equipo_ID,
                Nombre = equipoViewModel.Nombre,
                Estado = equipoViewModel.Estado,
                Observacion = equipoViewModel.Observacion,
                Cantidad = equipoViewModel.Cantidad

            };
            return EquipoViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Equipo> equipo;
            using (UnidadDeTrabajo<Equipo> Unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                equipo = Unidad.genericDAL.GetAll().ToList();
            }

            List<EquipoViewModel> lista = new List<EquipoViewModel>();

            foreach (var item in equipo)
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
        public ActionResult Create(EquipoViewModel equipoViewModel)
        {
            Equipo equipo = this.Convertir(equipoViewModel);

            using (UnidadDeTrabajo<Equipo> unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                unidad.genericDAL.Add(equipo);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Equipo equipo;
            using (UnidadDeTrabajo<Equipo> unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                equipo = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(equipo));
        }


        [HttpPost]
        public ActionResult Edit(EquipoViewModel equipoViewModel)
        {


            using (UnidadDeTrabajo<Equipo> unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(equipoViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Equipo equipo;
            using (UnidadDeTrabajo<Equipo> unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                equipo = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(equipo));
        }



        public ActionResult Delete(int id)
        {

            Equipo equipo;
            using (UnidadDeTrabajo<Equipo> unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                equipo = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(equipo));
        }

        [HttpPost]
        public ActionResult Delete(EquipoViewModel equipoViewModel)
        {
            using (UnidadDeTrabajo<Equipo> unidad = new UnidadDeTrabajo<Equipo>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(equipoViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}