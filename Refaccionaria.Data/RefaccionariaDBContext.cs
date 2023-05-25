using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Refaccionaria.Data.Maping;

namespace Refaccionaria.Data
{
    public class RefaccionariaDBContext:DbContext
    {
        
        public RefaccionariaDBContext(DbContextOptions<RefaccionariaDBContext> option) : base(option)
        {
            
        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Sale> Venta { get; set; }
        public DbSet<DetalleVenta> Detalleventa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Producto>().ToTable("producto");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<DetalleVenta>().ToTable("Detalleventa");
        }
    }
}
