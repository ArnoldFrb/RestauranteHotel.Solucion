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
    public class EntradaProductoSimpleServiceFakeTestx
    {
        private EntradaProductoSimpleService _productosimpleservice;
         
        [SetUp]
        public void Setup()
        {
            //Arrange

            _productosimpleservice = new EntradaProductoSimpleService(
                new UnitOfWorkFake(),
                new ProductoSimpleRepositoryFake());

        }


        [Test]
        public void EntradaTest_ExistenciaIgualACero()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan");
             
            //Act
            var response = _productosimpleservice.Entrada(new EntradaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 0, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple no fue actualizado", response.Mensaje);
             
        }

       
        [Test]
        public void EntradaTest_ExistenciaSolicitadaMayorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan"); 

            //Act
            var response = _productosimpleservice.Entrada(new EntradaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 20, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje); 
        }

        [Test]
        public void EntradaTest_ExistenciaSolicitadaMenorAExistenciaGuardada()
        {
            //Arrange
            var productoSimple = ProductoMother.CreateProducto("Pan"); 
            //Act
            var response = _productosimpleservice.Entrada(new EntradaProductoSimpleRequest(productoSimple.Id, productoSimple.Nombre, 2, productoSimple.Precio, productoSimple.Costo));
            //Assert
            Assert.AreEqual("Producto simple actualizado", response.Mensaje); 
        }
    }
}