using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestauranteHotel.Aplication.Test.Dobles;
using RestauranteHotel.Infrastructure.Data;
using RestauranteHotel.Infrastructure.Data.Base;
using RestauranteHotel.Infrastructure.Data.ObjectMother;
using RestauranteHotel.Infrastructure.Data.Repositories;

namespace RestauranteHotel.Aplication.Test.Memory
{
    public class SalidaProductoSimpleServiceMemory
    {
        private RestauranteHotelContext _dbContext;
        private SalidaProductoSimpleService _salidaProductoSimpleService;//SUT - Objeto bajo prueba

        [SetUp]
        public void Setup()
        {
            //Arrange
            var optionsSqlite = new DbContextOptionsBuilder<RestauranteHotelContext>()
           .UseSqlite(SqlLiteDatabaseInMemory.CreateConnection())
           .Options;

            _dbContext = new RestauranteHotelContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _salidaProductoSimpleService = new SalidaProductoSimpleService(
                new UnitOfWork(_dbContext),
                new ProductoSimpleRepository(_dbContext));
        }
    

        [Test]
        public void SalidaTest_ExistenciaIgualACero()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");
                 
            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response= _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
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
            var response = _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(10, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
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
            var response = _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 20, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no fue actualizado", response.Mensaje);

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
            var response = _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 2, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }
    }
}