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
            var producto = ProductoMother.CreateProductoCompuesto("Perro Cliente");

            _dbContext.ProductoCompuestos.Add(producto);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(producto.Id, producto.Nombre, 0, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto no fue actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoCompuestos.Remove(producto);
            _dbContext.SaveChanges();
        }

        [Test]
        public void SalidaTest_ProductoNoExiste()
        {
            //Arrange
            var producto = ProductoMother.CreateProductoCompuesto("Pan");

            _dbContext.ProductoCompuestos.Add(producto);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(10, producto.Nombre, 0, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto no encontrado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoCompuestos.Remove(producto);
            _dbContext.SaveChanges();
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMayorAExistenciaGuardada()
        {
            //Arrange
            var producto = ProductoMother.CreateProductoCompuesto("Perror caliente");

            _dbContext.ProductoCompuestos.Add(producto);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(producto.Id, producto.Nombre, 20, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoCompuestos.Remove(producto);
            _dbContext.SaveChanges();
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMenorAExistenciaGuardada()
        {
            //Arrange
            var producto = ProductoMother.CreateProductoCompuesto("Pan");

            _dbContext.ProductoCompuestos.Add(producto);
            _dbContext.SaveChanges();

            //Act
            var response = _salidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(producto.Id, producto.Nombre, 2, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto actualizado", response.Mensaje);

            //
            //Revertir
            _dbContext.ProductoCompuestos.Remove(producto);
            _dbContext.SaveChanges();
        }
    }
}