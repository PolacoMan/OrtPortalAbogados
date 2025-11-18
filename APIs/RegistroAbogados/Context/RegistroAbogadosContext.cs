using Microsoft.EntityFrameworkCore;
using RegistroAbogados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAbogados.Context
{
    public class RegistroAbogadosContext : DbContext
    {
        public RegistroAbogadosContext(DbContextOptions<RegistroAbogadosContext> options) : base(options)
        {
        }

        public DbSet<AbogadoInscripto>AbogadosInscriptos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AbogadoInscripto>()
                .HasKey(c => c.Id);
        }
    }
}
