using System.Collections.Generic;
using System.Reflection.Emit;
using TrabajoFinalCoderHouse.Modelos;
using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TrabajoFinalCoderHouse.Database
{
    public partial class coderhouse : DbContext
    {
        public coderhouse()
        {
        }

        public coderhouse(DbContextOptions<coderhouse> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductoVendido> ProductosVendidos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.comentarioVenta).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
