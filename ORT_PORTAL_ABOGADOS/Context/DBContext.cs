using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORT_PORTAL_ABOGADOS.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ORT_PORTAL_ABOGADOS.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Abogado> Abogados { get; set; } = null!;
        public DbSet<Consulta> Consultas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Abogado>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Abogado>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Consulta>()
                .HasKey(c => c.Id);  

            modelBuilder.Entity<Consulta>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}