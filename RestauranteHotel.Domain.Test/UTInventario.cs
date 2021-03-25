using NUnit.Framework;
using System.Collections.Generic;

namespace RestauranteHotel.Domain.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Metodo EntradaProducto()

        /*
         Existencias negativas o de cero 
            H1: Como Usuario quiero registrar productos en el inventario.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado No exite producto en el inventario 
            Cuando Va a registrar un nuevo producto
            id "111", Nombre "COCA-COLA", Existencia 0, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Fallido, Existencia Ingresada: 0”
        */
        [Test]
        public void NoPuedeIngresarExistenciaMenorOIgualACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var inventario = new Inventario(new List<Producto>());
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.EntradaProducto(new ProductoSimple("111", "COCA-COLA", 0, 5000, 3500));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Ingresada: 0", resultado);
        }

        /*
         Existencias mayores de cero 
            H1: Como Usuario quiero registrar productos en el inventario.
            Criterio de Aceptación:
            1.2 la existencia puede ser mayor a 0.
            Dado No exite producto en el inventario 
            Cuando Va a registrar un nuevo producto
            id "111", Nombre "COCA-COLA", Existencia 100, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Nuevo Producto en el sistema: COCA-COLA; Existencia: 100”
        */
        [Test]
        public void PuedeIngresarExistenciaMayoresACero()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var inventario = new Inventario(new List<Producto>());
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.EntradaProducto(new ProductoSimple("111", "COCA-COLA", 100, 5000, 3500));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitoso, Nuevo Producto en el sistema: COCA-COLA; Existencia: 100", resultado);
        }

        /*
         Existencias menores o igual a cero 
            H1: Como Usuario quiero aumentar las existencias de un producto en el inventario.
            Criterio de Aceptación:
            1.2 la existencia no puede ser menor o igual a 0.
            Dado Existe producto en el sistema
            id "111", Nombre "COCA-COLA", Existencia 100, Precio 5000, Costo 3500
            Cuando Va a registrar un nuevo producto
            id "111", Nombre "COCA-COLA", Existencia 0, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Fallido, Existencia Ingresada: 0”
        */
        [Test]
        public void NoPuedeAgregarExistenciaMenorOIgualACeroAUnProductoSimpleEnElSistema()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            List<Producto> productos = new List<Producto>();
            productos.Add(new ProductoSimple("111", "COCA-COLA", 100, 5000, 3500));
            var inventario = new Inventario(productos);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.EntradaProducto(new ProductoSimple("111", "COCA-COLA", 0, 5000, 3500));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Ingresada: 0", resultado);
        }

        /*
         Existencias mayores a cero 
            H1: Como Usuario quiero aumentar las existencias de un producto en el inventario.
            Criterio de Aceptación:
            1.2 la existencia puede mayor a 0.
            Dado Existe producto en el sistema
            id "111", Nombre "COCA-COLA", Existencia 100, Precio 5000, Costo 3500
            Cuando Va a registrar un nuevo producto
            id "111", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Producto: COCA-COLA; Nueva Existencia: 150”
        */
        [Test]
        public void PuedeAgregarExistenciaMayorACeroAUnProductoSimpleEnElSistema()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            List<Producto> productos = new List<Producto>();
            productos.Add(new ProductoSimple("111", "COCA-COLA", 100, 5000, 3500));
            var inventario = new Inventario(productos);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.EntradaProducto(new ProductoSimple("111", "COCA-COLA", 50, 5000, 3500));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitoso, Producto: COCA-COLA; Nueva Existencia: 150", resultado);
        }

        /*
         Solicitar producto simple
            H1: Como Usuario vender producto registrados en el inventario.
            Criterio de Aceptación:
            1.2 la existencia solicitada no puede ser menor o igual a 0.
            Dado Existe producto en el sistema
            id "116", Nombre "COCA-COLA", Existencia 100, Precio 5000, Costo 3500
            Cuando Va a registrar un nuevo producto
            id "116", Nombre "COCA-COLA", Existencia 0, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Fallido, Existencia Solicitada: 0”
        */
        [Test]
        public void NoPuedeSolicitarExistenciaMenorOIgualACeroAUnProductoSimpleEnElSistema()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            List<Producto> productos = new List<Producto>();
            productos.Add(new ProductoSimple("116", "COCA-COLA", 100, 5000, 3500));
            var inventario = new Inventario(productos);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.SalidaProducto(new ProductoSimple("116", "COCA-COLA", 0, 5000, 3500));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Solicitada: 0", resultado);
        }

        /*
         Solicitar producto simple
            H1: Como Usuario vender producto registrados en el inventario.
            Criterio de Aceptación:
            1.2 la existencia solicitada puede ser mayor a 0.
            Dado Existe producto en el sistema
            id "116", Nombre "COCA-COLA", Existencia 100, Precio 5000, Costo 3500
            Cuando Va a registrar un nuevo producto
            id "116", Nombre "COCA-COLA", Existencia 50, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Producto : COCA-COLA; Nueva Existencia: 50, Existencia Solicitada: 50; Precio: 5.000,00; Costo: 3.500,00; Utilidad: 75.000,00”
        */
        [Test]
        public void PuedeSolicitarExistenciaMayorACeroAUnProductoSimpleEnElSistema()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            List<Producto> productos = new List<Producto>();
            productos.Add(new ProductoSimple("116", "COCA-COLA", 100, 5000, 3500));
            var inventario = new Inventario(productos);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.SalidaProducto(new ProductoSimple("116", "COCA-COLA", 50, 5000, 3500));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitoso, Producto : COCA-COLA; Nueva Existencia: 50, Existencia Solicitada: 50; Precio: 5.000,00; Costo: 3.500,00; Utilidad: 75.000,00", resultado);
        }

        //HASTA AQUI PARCIAL

        /*
         Solicitar producto compuesto
            H1: Como Usuario vender producto registrados en el inventario.
            Criterio de Aceptación:
            1.2 la existencia solicitada no puede ser menor o igual a 0.
            Dado Existe producto en el sistema
            id "112", Nombre "Queso", Existencia 100, Precio 5000, Costo 3500
            id "113", Nombre "Pan", Existencia 100, Precio 5000, Costo 3500
            id "114", Nombre "Salchica", Existencia 100, Precio 5000, Costo 3500
            Cuando Va a registrar un nuevo producto
            id "116", Nombre "Perro Caliente", Existencia 0, Precio 0, Costo 0
            Compuesto por:
            id "112", Nombre "Queso", Existencia 100, Precio 5000, Costo 3500
            id "113", Nombre "Pan", Existencia 100, Precio 5000, Costo 3500
            id "114", Nombre "Salchica", Existencia 100, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Producto : COCA-COLA; Nueva Existencia: 50, Existencia Solicitada: 50; Precio: 5.000,00; Costo: 3.500,00; Utilidad: 75.000,00”
        */
        [Test]
        public void NoPuedeSolicitarExistenciaMenorOIgualACeroAUnProductoCompuestosEnElSistema()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var productos = new List<Producto>();
            productos.Add(new ProductoSimple("112", "Queso", 100, 7000, 6500));
            productos.Add(new ProductoSimple("113", "Pan", 100, 2500, 2000));
            productos.Add(new ProductoSimple("114", "Salchica", 100, 4500, 3500));

            var productosCompuestos = new List<Producto>();
            productosCompuestos.Add(new ProductoSimple("112", "Queso", 100, 7000, 6500));
            productosCompuestos.Add(new ProductoSimple("113", "Pan", 100, 2500, 2000));
            productosCompuestos.Add(new ProductoSimple("114", "Salchica", 100, 4500, 3500));

            var inventario = new Inventario(productos);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.SalidaProducto(new ProductoCompuesto("116", "Perro Caliente", 0, 0, 0, productosCompuestos));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Fallido, Existencia Solicitada: 0", resultado);
        }

        /*
         Solicitar producto compuesto
            H1: Como Usuario vender producto registrados en el inventario.
            Criterio de Aceptación:
            1.2 la existencia solicitada no puede ser menor o igual a 0.
            Dado Existe producto en el sistema
            id "112", Nombre "Queso", Existencia 100, Precio 5000, Costo 3500
            id "113", Nombre "Pan", Existencia 100, Precio 5000, Costo 3500
            id "114", Nombre "Salchica", Existencia 100, Precio 5000, Costo 3500
            Cuando Va a registrar un nuevo producto
            id "116", Nombre "Perro Caliente", Existencia 50, Precio 0, Costo 0
            Compuesto por:
            id "112", Nombre "Queso", Existencia 100, Precio 5000, Costo 3500
            id "113", Nombre "Pan", Existencia 100, Precio 5000, Costo 3500
            id "114", Nombre "Salchica", Existencia 100, Precio 5000, Costo 3500
            Entonces El sistema presentará el mensaje. “Registro Exitoso, Producto : Perro Caliente; Existencia Solicitada: 2; Precio: 28.000,00; Costo: 24.000,00; Utilidad: 4.000,00”
        */
        [Test]
        public void PuedeSolicitarExistenciaMayorACeroAUnProductoCompuestosEnElSistema()
        {
            //ARRANGE //PREPARAR // DADO // GIVEN
            var productos = new List<Producto>();
            productos.Add(new ProductoSimple("112", "Queso", 100, 7000, 6500));
            productos.Add(new ProductoSimple("113", "Pan", 100, 2500, 2000));
            productos.Add(new ProductoSimple("114", "Salchica", 100, 4500, 3500));

            var productosCompuestos = new List<Producto>();
            productosCompuestos.Add(new ProductoSimple("112", "Queso", 100, 7000, 6500));
            productosCompuestos.Add(new ProductoSimple("113", "Pan", 100, 2500, 2000));
            productosCompuestos.Add(new ProductoSimple("114", "Salchica", 100, 4500, 3500));

            var inventario = new Inventario(productos);
            // ACT // ACCION // CUANDO // WHEN
            var resultado = inventario.SalidaProducto(new ProductoCompuesto("116", "Perro Caliente", 2, 0, 0, productosCompuestos));
            //ASSERT //AFIRMACION //ENTONCES //THEN
            Assert.AreEqual("Registro Exitoso, Producto : Perro Caliente; Existencia Solicitada: 2; Precio: 28.000,00; Costo: 24.000,00; Utilidad: 4.000,00", resultado);
        }
    }
}