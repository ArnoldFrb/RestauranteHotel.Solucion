using NUnit.Framework;
using System.Collections.Generic;

namespace RestauranteHotel.Domain.Test
{
    class UTProdcutoCompuerto
    {
        [SetUp]
        public void Setup()
        {
        }

        //Metodo Salida()

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero solicitar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Exite producto en el inventario 
            id "111", Nombre "Queso", Existencia 50, Precio 700, Costo 500
            id "112", Nombre "Pan", Existencia 30, Precio 700, Costo 600
            id "113", Nombre "Salchicha", Existencia 40, Precio 800, Costo 500
            Cuando Ingrese una Existencia Menor o igual a 0; => Existencia = 0
            Entonces El sistema presentará el mensaje. “Registro Fallido, Existencia Solicitada 0”
        */
        [Test]
        public void NoPuedeIngresarExistenciaMenorOIgualACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var list = new List<Producto>();

            list.Add(new ProductoSimple("111", "Queso", 50, 700, 500));
            list.Add(new ProductoSimple("112", "Pan", 30, 1000, 600));
            list.Add(new ProductoSimple("113", "Salchicha", 40, 800, 500));

            var producto = new ProductoCompuesto("114", "PERRO CALIENTE", 0, 0, 0, list);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(0);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Solicitada: 0", resultado);
        }

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero solicitar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia puede ser  mayor a 0 Y mayor a Existencia de los producto.
            Dado Exite producto en el inventario 
            id "111", Nombre "Queso", Existencia 50, Precio 700, Costo 500
            id "112", Nombre "Pan", Existencia 30, Precio 700, Costo 600
            id "113", Nombre "Salchicha", Existencia 40, Precio 800, Costo 500
            Cuando Ingrese una Existencia mayor a 0 Y mayor a Existencia de los producto; => Existencia = 35
            Entonces El sistema presentará el mensaje. “Registro Fallido, La Existencia solicitada 35 del prodcuto Pan es Mayor a 30”
        */
        [Test]
        public void NoPuedeSoloicitarExistenciaMayorALaExistenciaDelProducto()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var list = new List<Producto>();

            list.Add(new ProductoSimple("111", "Queso", 50, 700, 500));
            list.Add(new ProductoSimple("112", "Pan", 30, 1000, 600));
            list.Add(new ProductoSimple("113", "Salchicha", 40, 800, 500));

            var producto = new ProductoCompuesto("114", "PERRO CALIENTE", 0, 0, 0, list);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(35);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, La Existencia solicitada 35 del prodcuto Pan es Mayor a 30", resultado);
        }

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero solicitar las existencia del producto para mantener la informacion actualizada.
            Criterio de Aceptación:
            1.2 la existencia puede ser mayor a 0 Y menor o igual a Existencia de los producto.
            Dado Exite producto en el inventario 
            id "111", Nombre "Queso", Existencia 50, Precio 700, Costo 500
            id "112", Nombre "Pan", Existencia 30, Precio 700, Costo 600
            id "113", Nombre "Salchicha", Existencia 40, Precio 800, Costo 500
            Cuando Ingrese una Existencia mayor a 0 Y menor o igual a Existencia de los producto; => Existencia = 2
            Entonces El sistema presentará el mensaje. “Venta Exitosa, Cantidad: 2; Costo: 1.600,00; Precio: 2.500,00; Utilidad: 1.800,00”
        */
        [Test]
        public void PuedeSoloicitarExistenciaMayorALaExistenciaDelProductoYMayorACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var list = new List<Producto>();

            list.Add(new ProductoSimple("111", "Queso", 50, 700, 500));
            list.Add(new ProductoSimple("112", "Pan", 30, 1000, 600));
            list.Add(new ProductoSimple("113", "Salchicha", 40, 800, 500));

            var producto = new ProductoCompuesto("114", "PERRO CALIENTE", 0, 0, 0, list);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = producto.Salida(2);
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Venta Exitosa, Cantidad: 2; Costo: 1.600,00; Precio: 2.500,00; Utilidad: 1.800,00", resultado);
        }
    }
}
