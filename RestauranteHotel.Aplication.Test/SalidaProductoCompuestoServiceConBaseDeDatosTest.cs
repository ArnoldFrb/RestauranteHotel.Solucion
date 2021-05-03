using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestauranteHotel.Infrastructure.Data;
using RestauranteHotel.Infrastructure.Data.Base;
using RestauranteHotel.Infrastructure.Data.ObjectMother;
using RestauranteHotel.Infrastructure.Data.Repositories;

namespace RestauranteHotel.Aplication.Test
{
    public class SalidaProductoCompuestoServiceConBaseDeDatosTest
    {
        private RestauranteHotelContext _dbContext;
        private SalidaProductoCompuestoService _salidaProductoCompuestoService;//SUT - Objeto bajo prueba

        [SetUp]
        public void Setup()
        {
            //Arrange
            var optionsSqlite = new DbContextOptionsBuilder<RestauranteHotelContext>()
           .UseSqlite(@"Data Source=RestauranteHotelDataBaseTest.db")
           .Options;

            _dbContext = new RestauranteHotelContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _salidaProductoCompuestoService = new SalidaProductoCompuestoService(
                new UnitOfWork(_dbContext),
                new ProductoCompuestoRepository(_dbContext));
        }


        [Test]
        public void SalidaTest_ExistenciaIgualACero()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(productoSimple.Id, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no fue actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }

        [Test]
        public void SalidaTest_ProductoNoExiste()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(10, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no encontrado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMayorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(productoSimple.Id, productoSimple.Nombre, 20, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMenorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(productoSimple.Id, productoSimple.Nombre, 2, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }
    }
}