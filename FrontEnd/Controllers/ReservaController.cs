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
using System.Text;

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
                Cantidad_Personas = (int)reserva.Cantidad_Personas,
                Tipo_Pago = reserva.Tipo_Pago,
                Total = (double)reserva.Total,
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
            ReservaViewModel reserva = new ReservaViewModel { };

            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
                reserva.Usuarios = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(new BDContext()))
            {
                reserva.Servicios = unidad.genericDAL.GetAll().ToList();
            }
            return View(reserva);
        }

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

            ReservaViewModel reservas = this.Convertir(reserva);

            Usuarios  usuario;
            List<Usuarios> usuarios;

            using (UnidadDeTrabajo<Usuarios> unidad = new UnidadDeTrabajo<Usuarios>(new BDContext()))
            {
               usuarios = unidad.genericDAL.GetAll().ToList();
               usuario = unidad.genericDAL.Get(reservas.Usuario_ID);
            }
            usuarios.Insert(0, usuario);
            reservas.Usuarios = usuarios;


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


        public ActionResult Report()
        {

            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local,
                ShowExportControls = true,
                ShowParameterPrompts = true,
                ShowPageNavigationControls = true,
                ShowRefreshButton = true,
                ShowPrintButton = true,
                SizeToReportContent = true,
                AsyncRendering = false,
            };
            string rutaReporte = "~/Reports/rptDetalleReserva.rdlc";
            ///construir la ruta física
            string rutaServidor = Server.MapPath(rutaReporte);
            reportViewer.LocalReport.ReportPath = rutaServidor;
            //reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportCategories.rdlc";
            var infoFuenteDatos = reportViewer.LocalReport.GetDataSourceNames();
            reportViewer.LocalReport.DataSources.Clear();

            List<BackEnd.Entities.sp_infoReserva_Result> datosReporte;
            using (UnidadDeTrabajo<BackEnd.Entities.sp_infoReserva_Result> unidad = new UnidadDeTrabajo<BackEnd.Entities.sp_infoReserva_Result>(new BDContext()))
            {
                datosReporte = unidad.genericDAL.GetAll().ToList();
            }
            ReportDataSource fuenteDatos = new ReportDataSource();
            fuenteDatos.Name = infoFuenteDatos[0];
            fuenteDatos.Value = datosReporte;
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("InfoReservasDataSet", datosReporte));

            reportViewer.LocalReport.Refresh();
            ViewBag.ReportViewer = reportViewer;


            return View();

        }
    }
}
