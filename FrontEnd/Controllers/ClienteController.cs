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
    public class ClienteController : Controller
    {
        // GET: Cliente
        private ClienteViewModel Convertir(Cliente cliente)
        {
            ClienteViewModel clienteViewModel = new ClienteViewModel
            {
                Cliente_ID = cliente.Cliente_ID,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Nacionalidad = cliente.Nacionalidad,
                Telefono = (int)cliente.Telefono,
                Correo = cliente.Correo,
                Clave = cliente.Clave




            };
            return clienteViewModel;
        }// FIN DE CONVERTIR


        private Cliente Convertir(ClienteViewModel clienteViewModel)
        {
            Cliente ClienteViewModel = new Cliente
            {
                Cliente_ID = clienteViewModel.Cliente_ID,
                Nombre = clienteViewModel.Nombre,
                Apellidos = clienteViewModel.Apellidos,
                Nacionalidad = clienteViewModel.Nacionalidad,
                Telefono = (int)clienteViewModel.Telefono,
                Correo = clienteViewModel.Correo,
                Clave = clienteViewModel.Clave

            };
            return ClienteViewModel;
        }



        // GET: Category
        public ActionResult Index()
        {
            List<Cliente> clientes;
            using (UnidadDeTrabajo<Cliente> Unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                clientes = Unidad.genericDAL.GetAll().ToList();
            }

            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            foreach (var item in clientes)
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
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = this.Convertir(clienteViewModel);

            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                unidad.genericDAL.Add(cliente);
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int id)
        {

            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                cliente = unidad.genericDAL.Get(id);

            }


            return View(this.Convertir(cliente));
        }


        [HttpPost]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {


            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(clienteViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Details(int id)
        {

            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                cliente = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(cliente));
        }



        public ActionResult Delete(int id)
        {

            Cliente cliente;
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                cliente = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(cliente));
        }

        [HttpPost]
        public ActionResult Delete(ClienteViewModel clienteViewModel)
        {
            using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(new BDContext()))
            {
                unidad.genericDAL.Remove(this.Convertir(clienteViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}