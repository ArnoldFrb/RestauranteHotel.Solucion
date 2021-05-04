using Microsoft.EntityFrameworkCore;
using RestauranteHotel.Infrastructure.Data.Base;
using RestauranteHotel.Domain.Entity;
using System;

namespace RestauranteHotel.Infrastructure.Data
{
    public class RestauranteHotelContext : DbContextBase
    {
        public RestauranteHotelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }//equivale a Repositorios
        public DbSet<ProductoSimple> ProductoSimples { get; set; }//equivale a Repositorios
        public DbSet<ProductoCompuesto> ProductoCompuestos { get; set; }//equivale a Repositorios

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasKey(c => c.Id);

            modelBuilder.Entity<ProductoCompuesto>().ToTable("ProductoCompuesto");
            modelBuilder.Entity<ProductoSimple>().ToTable("ProductoSimple");

            modelBuilder.Entity<ProductoSimple>()
                 .HasOne(p => p.ProductoCompuesto)
                 .WithMany(b => b.Productos);


            modelBuilder.Entity<Producto>().Property(p => p.Existencia).HasColumnType("Decimal");
            modelBuilder.Entity<Producto>().Property(p => p.Precio).HasColumnType("Decimal");
            modelBuilder.Entity<Producto>().Property(p => p.Costo).HasColumnType("Decimal");



            modelBuilder.Entity<ProductoCompuesto>().HasData(
            new { Id = 1, Nombre = "perro sencillo", Existencia = 10.0m, Precio = 5.000m, Costo = 3.0000m }
            );

            modelBuilder.Entity<ProductoSimple>().HasData(
            new { Id = 2, Nombre = "salchicha", Existencia = 10.0m, Precio = 0.0m, Costo = 1.000m, ProductoCompuestoId = 1 },
            new { Id = 3, Nombre = "pan de perro", Existencia = 10.0m, Precio = 0.0m, Costo = 1.000m, ProductoCompuestoId = 1 },
            new { Id = 4, Nombre = "lamina de queso", Existencia = 10.0m, Precio = 0.0m, Costo = 1.000m, ProductoCompuestoId = 1 },
            new { Id = 5, Nombre = "pan de perro extragrande", Existencia = 1.0m, Precio = 0.0m, Costo = 2.000m, ProductoCompuestoId = 1 },
            new { Id = 6, Nombre = "salchicha ranchera", Existencia = 10.0m, Precio = 0.0m, Costo = 2.000m });


            //inicailizacion de datos 

            //modelBuilder.Entity<CuentaBancaria>().HasData(new { Id = 1, Numero = "1010", Ciudad = "Valleduar", Email = "Email" });
        }
    }
}

