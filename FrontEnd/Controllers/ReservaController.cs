using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.Entities;
using BackEnd.DAL;
using FrontEnd.Models;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WebForms;

namespace FrontEnd.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
         private ReservaViewModel Convertir(Reservas reserva)
        {
            ReservaViewModel reservaViewModel = new ReservaViewModel {
                Reserva_ID = reserva.Reserva_ID,
                Fecha = (DateTime)reserva.Fecha,
                Servicio_ID = reserva.Servicio_ID,
                Consentimiento = reserva.Consentimiento,
                Horario = (DateTime)reserva.Horario,
                Cantidad_Personas = reserva.Cantidad_Personas,
                Tipo_Pago = reserva.Tipo_Pago,
                Total = reserva.Total,
                Observacion = reserva.Observacion
            };
            return reservaViewModel;
        }// FIN DE CONVERTIR


        private  Reservas Convertir(ReservaViewModel reservaViewModel)
        {
            Reservas ReservaViewModel = new Reservas
            {
                Reserva_ID = reservaViewModel.Reserva_ID,
                Fecha = reservaViewModel.Fecha,
                Servicio_ID = reservaViewModel.Servicio_ID,
                Consentimiento = reservaViewModel.Consentimiento,
                Horario = reservaViewModel.Horario,
                Cantidad_Personas = reservaViewModel.Cantidad_Personas,
                Tipo_Pago = reservaViewModel.Tipo_Pago,
                Total = reservaViewModel.Total,
                Observacion = reservaViewModel.Observacion
            };
            return ReservaViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Reservas> reservas;
            using (UnidadDeTrabajo<Reservas> Unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                reservas = Unidad.genericDAL.GetAll().ToList();
            }

            List<ReservaViewModel> lista = new List<ReservaViewModel>();

            foreach (var item in reservas)
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
        public ActionResult Create(ReservaViewModel reservaViewModel)
        {
            Reservas reserva = this.Convertir(reservaViewModel);

            using (UnidadDeTrabajo<Reservas> unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                unidad.genericDAL.Add(reserva);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Reservas reserva;
            using (UnidadDeTrabajo<Reservas> unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                reserva = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(reserva));
        }


        [HttpPost]
        public ActionResult Edit(ReservaViewModel reservaViewModel)
        {


            using (UnidadDeTrabajo<Reservas> unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(reservaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {

            Reservas reserva;
            using (UnidadDeTrabajo<Reservas> unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                reserva = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(reserva));
        }

        public ActionResult Delete(int id)
        {

            Reservas reserva;
            using (UnidadDeTrabajo<Reservas> unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                reserva = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(reserva));
        }

        [HttpPost]
        public ActionResult Delete(ReservaViewModel reservaViewModel)
        {
            using (UnidadDeTrabajo<Reservas> unidad = new UnidadDeTrabajo<Reservas>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(reservaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }


        //public ActionResult Report()
        //{

        //    var reportViewer = new ReportViewer
        //    {
        //        ProcessingMode = ProcessingMode.Local,
        //        ShowExportControls = true,
        //        ShowParameterPrompts = true,
        //        ShowPageNavigationControls = true,
        //        ShowRefreshButton = true,
        //        ShowPrintButton = true,
        //        SizeToReportContent = true,
        //        AsyncRendering = false,
        //    };
        //    string rutaReporte = "~/Reports/rptClientes.rdlc";
        //    ///construir la ruta física
        //    string rutaServidor = Server.MapPath(rutaReporte);
        //    reportViewer.LocalReport.ReportPath = rutaServidor;
        //    //reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportCategories.rdlc";
        //    var infoFuenteDatos = reportViewer.LocalReport.GetDataSourceNames();
        //    reportViewer.LocalReport.DataSources.Clear();

        //    List<InformacionClientes_Result> datosReporte;
        //    using (var contextoBD = new ARMEntities())
        //    {
        //        datosReporte = contextoBD.InformacionClientes().ToList();
        //    }
        //    ReportDataSource fuenteDatos = new ReportDataSource();
        //    fuenteDatos.Name = infoFuenteDatos[0];
        //    fuenteDatos.Value = datosReporte;
        //    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ClientesDataSet", datosReporte));

        //    reportViewer.LocalReport.Refresh();
        //    ViewBag.ReportViewer = reportViewer;


        //    return View();



        //}//FIN REPORT
    }
}
