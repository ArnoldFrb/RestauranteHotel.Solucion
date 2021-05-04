using NUnit.Framework;
using RestauranteHotel.Aplication.Test.Dobles;
using RestauranteHotel.Aplication.Test.Dobles.RepositoriesFake;
using RestauranteHotel.Infrastructure.Data.ObjectMother;

namespace RestauranteHotel.Aplication.Test.DataBase
{
    public class SalidaProductoCompuestoServiceFakeTestx
    {

        private SalidaProductoCompuestoService _SalidaProductoCompuestoService;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _SalidaProductoCompuestoService = new SalidaProductoCompuestoService(
                new UnitOfWorkFake(),
                new ProductoCompuestoRepositoryFake());
        }


        [Test]
        public void SalidaTest_ExistenciaIgualACero()
        {
            //Arrange
            var producto = ProductoMother.CreateProductoCompuesto("Perro Cliente"); 
            //Act
            var response = _SalidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(producto.Id, producto.Nombre, 0, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto no fue actualizado", response.Mensaje);
 
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMayorAExistenciaGuardada()
        {
            //Arrange
            var producto = ProductoMother.CreateProductoCompuesto("Perror caliente"); 

            //Act
            var response = _SalidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(producto.Id, producto.Nombre, 20, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto actualizado", response.Mensaje); 
        }

        [Test]
        public void SalidaTest_ExistenciaSolicitadaMenorAExistenciaGuardada()
        {
            //Arrange
            var producto = ProductoMother.CreateProductoCompuesto("Pan"); 
            //Act
            var response = _SalidaProductoCompuestoService.Salida(new SalidaProductoCompuestoRequest(producto.Id, producto.Nombre, 2, producto.Precio, producto.Costo, producto.Productos));
            //Assert
            Assert.AreEqual("Producto compuesto actualizado", response.Mensaje); 
        }
    }
}