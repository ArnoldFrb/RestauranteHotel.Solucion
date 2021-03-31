using NUnit.Framework;

namespace RestauranteHotel.Domain.Test
{
    class UTProductoSimple
    {
        [SetUp]
        public void Setup()
        {
        }

        //Metodo Entrada()

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 0, Precio 5000, Costo 3500
            Cuando Ingrese una Existencia Menor o igual a 0; => Existencia = 0
            Entonces El sistema presentará el mensaje. “Registro Fallido, Existencia Ingresada: 0”
        */
        [Test]
        public void NoPuedeIngresarExistenciaMenorOIgualACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 0, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Entrada(0);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Ingresada: 0", resultado);
        }

        /*
         Sumar Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Cuando Ingrese una Existencia Menor o igual a 0; => Existencia = 0
            Entonces El sistema presentará el mensaje. “Registro Fallido, No Puede Sumar Existencias 0”
        */
        [Test]
        public void NoPuedeSumarExistenciaMenorOIgualACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Entrada(0);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, No Puede Sumar Existencias 0", resultado);
        }

        /*
         Existencias mayores de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia puede ser mayor a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 0, Precio 5000, Costo 3500
            Cuando Ingrese una Existencia Mayor a 0; => Existencia = 50
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Nueva Existencia: 50 del Prodcuto COCA-COLA”
        */
        [Test]
        public void PuedeIngresarExistenciaMayorACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 0, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Entrada(50);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitoso, Nueva Existencia: 50 del Prodcuto COCA-COLA", resultado);
        }

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Cuando Ingrese una Existencia Mayor a 0; => Existencia = 24
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Nueva Existencia: 74 del Prodcuto COCA-COLA”
        */
        [Test]
        public void PuedeSumarExistenciaMayorACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Entrada(24);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitoso, Nueva Existencia: 74 del Prodcuto COCA-COLA", resultado);
        }

        //Metodo Salida()

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Cuando Solicite una Existencia Menor o igual a 0; => Existencia = 0
            Entonces El sistema presentará el mensaje. “Registro Fallido, Existencia Solicitada: 0”
        */
        [Test]
        public void NoPuedeSolicitarExistenciaMenorOIgualACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(0);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Solicitada: 0", resultado);
        }

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Cuando Solicite una Existencia mayor a la Existencia en el sistema; => Existencia = 60
            Entonces El sistema presentará el mensaje. “Registro Fallido, La Existencia solicitada 60 es Mayor a 50”
        */
        [Test]
        public void NoPuedeSolicitarExistenciMayorALaRegistrada()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(60);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, La Existencia solicitada 60 es Mayor a 50", resultado);
        }

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Cuando Solicite una Existencia mayor a la Existencia en el sistema; => Existencia = 40
            Entonces El sistema presentará el mensaje. “Venta Exitosa, Cantidad: 40; Costo: 3.500,00; Precio: 5.000,00; Utilidad: 60.000,00”
        */
        [Test]
        public void PuedeSolicitarExistenciMenorOIgualrALaRegistrada()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(40);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Venta Exitosa, Cantidad: 40; Costo: 3.500,00; Precio: 5.000,00; Utilidad: 60.000,00", resultado);
        }

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero cambiar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Cuando Solicite una Existencia mayor a la Existencia en el sistema; => Existencia = 40
            Entonces El sistema presentará el mensaje. “Venta Exitosa, Cantidad: 40; Costo: 3.500,00; Precio: 5.000,00; Utilidad: 60.0000,00”
        */
        [Test]
        public void PuedeSolicitarExistenciMenorOIgualrACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var producto = new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(40);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Venta Exitosa, Cantidad: 40; Costo: 3.500,00; Precio: 5.000,00; Utilidad: 60.000,00", resultado);
        }
    }
}
