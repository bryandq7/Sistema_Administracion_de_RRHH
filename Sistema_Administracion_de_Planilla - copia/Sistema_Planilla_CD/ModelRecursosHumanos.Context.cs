﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Planilla_CE
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RecursosHumanosDBContext : DbContext
    {
        public RecursosHumanosDBContext()
            : base("name=RecursosHumanosDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<BoletaCurso> BoletaCurso { get; set; }
        public virtual DbSet<Canton> Canton { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<ClaseConcepto> ClaseConcepto { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<DestinatarioConcepto> DestinatarioConcepto { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Distrito> Distrito { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<ImpactaPlanilla> ImpactaPlanilla { get; set; }
        public virtual DbSet<ImpuestoRenta> ImpuestoRenta { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Planilla> Planilla { get; set; }
        public virtual DbSet<PlanillaPatrono> PlanillaPatrono { get; set; }
        public virtual DbSet<PlanillaPatronoDetalle> PlanillaPatronoDetalle { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<StatusSolicitud> StatusSolicitud { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }
        public virtual DbSet<TipoConcepto> TipoConcepto { get; set; }
        public virtual DbSet<TipoContrato> TipoContrato { get; set; }
        public virtual DbSet<TipoSolicitud> TipoSolicitud { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Vacaciones> Vacaciones { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<PeriodoDePago> PeriodoDePago { get; set; }
        public virtual DbSet<Concepto> Concepto { get; set; }
        public virtual DbSet<ConceptoAplicado> ConceptoAplicado { get; set; }
        public virtual DbSet<PlanillaDetalle> PlanillaDetalle { get; set; }
    }
}
