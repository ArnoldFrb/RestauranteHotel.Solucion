using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
using RestauranteHotel.Infrastructure.Data.Base;
using RestauranteHotel.Domain.Entity;
=======
using RestauranteHotel.Domain.Entity;
using RestauranteHotel.Infrastructure.Data.Base;
>>>>>>> Stashed changes
using System;

namespace RestauranteHotel.Infrastructure.Data
{
    public class RestauranteHotelContext : DbContextBase
    {
        public RestauranteHotelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }//equivale a Repositorios
<<<<<<< Updated upstream
        public DbSet<ProductoSimple> ProductoSimples { get; set; }//equivale a Repositorios
        public DbSet<ProductoCompuesto> ProductoCompuestos { get; set; }//equivale a Repositorios
=======
>>>>>>> Stashed changes

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasKey(c => c.Id);
<<<<<<< Updated upstream
            modelBuilder.Entity<Producto>().HasDiscriminator<string>("producto_type")
                .HasValue<ProductoSimple>("ProductoSimple")
                .HasValue<ProductoCompuesto>("ProductoCompuesto");
=======
            modelBuilder.Entity<ProductoSimple>();
            modelBuilder.Entity<ProductoCompuesto>();
>>>>>>> Stashed changes

            //inicailizacion de datos 
            //modelBuilder.Entity<CuentaBancaria>().HasData(new  { Id=1, Numero="1010", Ciudad="Valleduar", Email="Email"} );
            //modelBuilder.Entity<CuentaBancaria>().HasData(new { Id = 1, Numero = "1010", Ciudad = "Valleduar", Email = "Email" });
        }
    }
}
