﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.Entities;
using BackEnd.DAL;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class HistorialController : Controller
    {


        private HistorialViewModel Convertir(Historial historial)
        {
            HistorialViewModel historialViewModel = new HistorialViewModel
            {
                Historial_ID = historial.Historial_ID,
                Colaborador_ID = historial.Colaborador_ID,
                Fecha = (DateTime)historial.Fecha,
                Observacion = historial.Observacion

            };
            return historialViewModel;
        }// FIN DE CONVERTIR
        private Historial Convertir(HistorialViewModel historialViewModel)
        {
            Historial HistorialViewModel = new Historial
            {
               Historial_ID = historialViewModel.Historial_ID,
               Colaborador_ID = historialViewModel.Colaborador_ID,
               Fecha = historialViewModel.Fecha,
               Observacion = historialViewModel.Observacion

            };
            return HistorialViewModel;
        }



        // GET: Historial
        public ActionResult Index()
        {
            List<Historial> historial;
            using (UnidadDeTrabajo<Historial> Unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                historial = Unidad.genericDAL.GetAll().ToList();
            }

            List<HistorialViewModel> lista = new List<HistorialViewModel>();

            foreach (var item in historial)
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
        public ActionResult Create(HistorialViewModel historialViewModel)
        {
           Historial historial = this.Convertir(historialViewModel);

            using (UnidadDeTrabajo<Historial> unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                unidad.genericDAL.Add(historial);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Historial historial;
            using (UnidadDeTrabajo<Historial> unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                historial = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(historial));
        }


        [HttpPost]
        public ActionResult Edit(HistorialViewModel historialViewModel)
        {


            using (UnidadDeTrabajo<Historial> unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(historialViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Historial historial;
            using (UnidadDeTrabajo<Historial> unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                historial = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(historial));
        }



        public ActionResult Delete(int id)
        {

            Historial historial;
            using (UnidadDeTrabajo<Historial> unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                historial = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(historial));
        }

        [HttpPost]
        public ActionResult Delete(HistorialViewModel historialViewModel)
        {
            using (UnidadDeTrabajo<Historial> unidad = new UnidadDeTrabajo<Historial>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(historialViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}