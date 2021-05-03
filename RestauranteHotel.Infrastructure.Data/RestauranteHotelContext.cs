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
            modelBuilder.Entity<Producto>().HasKey(c => c.Id);
            modelBuilder.Entity<Producto>().HasDiscriminator<string>("producto_type")
                .HasValue<ProductoSimple>("ProductoSimple")
                .HasValue<ProductoCompuesto>("ProductoCompuesto");

            //inicailizacion de datos 
            //modelBuilder.Entity<CuentaBancaria>().HasData(new  { Id=1, Numero="1010", Ciudad="Valleduar", Email="Email"} );
            //modelBuilder.Entity<CuentaBancaria>().HasData(new { Id = 1, Numero = "1010", Ciudad = "Valleduar", Email = "Email" });
        }
    }
}
