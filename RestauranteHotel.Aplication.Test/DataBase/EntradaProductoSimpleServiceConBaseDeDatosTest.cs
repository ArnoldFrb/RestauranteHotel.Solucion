using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestauranteHotel.Aplication.Test.Dobles;
using RestauranteHotel.Infrastructure.Data;
using RestauranteHotel.Infrastructure.Data.Base;
using RestauranteHotel.Infrastructure.Data.ObjectMother;
using RestauranteHotel.Infrastructure.Data.Repositories;

namespace RestauranteHotel.Aplication.Test.DataBase
{
    public class EntradaProductoSimpleServiceFakeTest
    {
        private RestauranteHotelContext _dbContext;
        private EntradaProductoSimpleService _entradaProductoSimpleService;//SUT - Objeto bajo prueba

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

            _entradaProductoSimpleService = new EntradaProductoSimpleService(
                new UnitOfWork(_dbContext),
                new ProductoSimpleRepository(_dbContext));

        }


        [Test]
        public void EntradaTest_ExistenciaIgualACero()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _entradaProductoSimpleService.Entrada(new EntradaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no fue actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }

        [Test]
        public void EntradaTest_ProductoNoExiste()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _entradaProductoSimpleService.Entrada(new EntradaProductoSimpleRequest(10, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no encontrado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }

        [Test]
        public void EntradaTest_ExistenciaSolicitadaMayorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _entradaProductoSimpleService.Entrada(new EntradaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 20, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }

        [Test]
        public void EntradaTest_ExistenciaSolicitadaMenorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");

            _dbContext.ProductoSimples.Add(productoSimple);
            _dbContext.SaveChanges();

            //Act
            var response = _entradaProductoSimpleService.Entrada(new EntradaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 2, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoSimples.Remove(productoSimple);
            _dbContext.SaveChanges();
        }
    }
}