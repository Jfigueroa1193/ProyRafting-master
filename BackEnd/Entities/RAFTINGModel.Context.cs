﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDContext : DbContext
    {
        public BDContext()
            : base("name=BDContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Colaboradore> Colaboradores { get; set; }
        public virtual DbSet<Equipo> Equipoes { get; set; }
        public virtual DbSet<Historial> Historials { get; set; }
        public virtual DbSet<Operacion> Operacions { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}