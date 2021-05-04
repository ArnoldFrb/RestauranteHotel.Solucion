using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestauranteHotel.Aplication.Test.Dobles;
using RestauranteHotel.Aplication.Test.Dobles.RepositoriesFake;
using RestauranteHotel.Infrastructure.Data;
using RestauranteHotel.Infrastructure.Data.Base;
using RestauranteHotel.Infrastructure.Data.ObjectMother;
using RestauranteHotel.Infrastructure.Data.Repositories;

namespace RestauranteHotel.Aplication.Test.DataBase
{
    public class SalidaProductoSimpleServiceFakeTest
    {
        private SalidaProductoSimpleService _salidaProductoSimpleService;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _salidaProductoSimpleService = new SalidaProductoSimpleService(
                new UnitOfWorkFake(),
                new ProductoSimpleRepositoryFake());
        }
    

        [Test]
        public void SalidaTest_ExistenciaIgualACero()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");
            //Act
            var response= _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no fue actualizado", response.Mensaje); 
        }
         
        [Test]
        public void SalidaTest_ExistenciaSolicitadaMayorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");
            //Act
            var response = _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 20, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no fue actualizado", response.Mensaje);
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMenorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");
            //Act
            var response = _salidaProductoSimpleService.Salida(new SalidaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 2, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje);
        }
    }
}