using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProyectoFinal.Models;

namespace ProyectoFinal.Models
{
    public class SpaDbContext : DbContext
    {
        public SpaDbContext() : base("SpaConexion") { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Terapeuta> Terapeutas { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}