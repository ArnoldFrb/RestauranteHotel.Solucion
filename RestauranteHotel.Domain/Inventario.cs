using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain
{
    public class Inventario
    {
        private List<Producto> Productos;
        public Inventario(List<Producto> productos)
        {
            Productos = productos;
        }

        public string EntradaProducto(Producto producto)
        {
            //AGRAGAR PRODUCTO
            if (Productos.Count == 0 && producto.Existencia <= 0)
            {
                return $"Registro Fallido, Existencia Ingresada: {producto.Existencia}";
            }
            if (Productos.Count == 0 && producto.Existencia > 0)
            {
                Productos.Add(producto);
                return $"Registro Exitoso, Nuevo Producto en el sistema: {producto.Nombre}; Existencia: {producto.Existencia}";
            }
            if (Productos.Count > 0 && producto.Existencia <= 0)
            {
                return $"Registro Fallido, Existencia Ingresada: {producto.Existencia}";
            }
            if (Productos.Count > 0 && producto.Existencia > 0)
            {
                foreach (var pro in Productos)
                {
                    if (!pro.Id.Equals(producto.Id))
                    {
                        Productos.Add(producto);
                        return $"Registro Exitoso, Nuevo Producto en el sistema: {producto.Nombre}; Existencia: {producto.Existencia}";
                    }
                }
            }
            //AUMENTAR EXISTENCIAS
            foreach (var pro in Productos)
            {
                if (pro.Id.Equals(producto.Id))
                {
                    if (producto.Existencia <= 0)
                    {
                        return $"Registro Fallido, Existencia Ingresada: {producto.Existencia}";
                    }
                    if (producto.Existencia > 0)
                    {
                        pro.Existencia += producto.Existencia;
                        return $"Registro Exitoso, Producto: {pro.Nombre}; Nueva Existencia: {pro.Existencia}";
                    }
                }
            }
            /*if (costo <= 0)
            {
                return $"Registro Fallido, Costo Ingresado ${costo:n2}";
            }
            if (Existencia == 0 && existencia <= 0)
            {
                return $"Registro Fallido, Existencia Ingresada: {existencia}";
            }
            if (Existencia == 0 && existencia > 0)
            {
                Existencia += existencia;
                Costo = costo;
                return $"Registro Exitoso, Nuevo Producto en el sistema {Producto.Nombre} Existencia: {Existencia}";
            }
            if (Existencia > 0 && existencia <= 0)
            {
                return $"Registro Fallido, Existencia Actual: {Existencia}; Existencia Ingresada: {existencia}";
            }
            if (Existencia > 0 && existencia > 0)
            {
                Existencia += existencia;
                return $"Registro Exitoso, Nueva Existencia: {Existencia} Producto: {Producto.Nombre}";
            }*/
            throw new NotImplementedException();
        }

        public string SalidaProducto(ProductoSimple producto)
        {
            //AGRAGAR PRODUCTO
            if (producto.Existencia <= 0)
            {
                return $"Registro Fallido, Existencia Solicitada: {producto.Existencia}";
            }
            if (producto.Existencia > 0)
            {
                foreach (var pro in Productos)
                {
                    if (pro.Id.Equals(producto.Id))
                    {
                        pro.Existencia -= producto.Existencia;
                        return $"Registro Exitoso, Producto : {pro.Nombre}; Nueva Existencia: {pro.Existencia}, Existencia Solicitada: {producto.Existencia}; Precio: {pro.Precio:n2}; Costo: {pro.Costo:n2}; Utilidad: {((pro.Precio * producto.Existencia) - (pro.Costo*producto.Existencia)):n2}";
                    }
                }
            }
            throw new NotImplementedException();
        }

        public string SalidaProducto(ProductoCompuesto producto)
        {
            decimal Costo = 0;
            decimal Precio = 0;
            //AGRAGAR PRODUCTO
            if (producto.Existencia <= 0)
            {
                return $"Registro Fallido, Existencia Solicitada: {producto.Existencia}";
            }
            if (producto.Existencia > 0)
            {
                foreach (var pro in Productos)
                {
                    foreach (var com in producto.Productos)
                    {
                        if (pro.Id.Equals(com.Id))
                        {
                            pro.Existencia -= producto.Existencia;
                            Costo += producto.Existencia * pro.Costo;
                            Precio += producto.Existencia * pro.Precio;
                        }
                    }
                }
                return $"Registro Exitoso, Producto : {producto.Nombre}; Existencia Solicitada: {producto.Existencia}; Precio: {Precio:n2}; Costo: {Costo:n2}; Utilidad: {(Precio - Costo):n2}";
            }
            throw new NotImplementedException();
        }

        public void EntradaProducto(int existencia, decimal costo, decimal precio, Producto producto)
        {
            //inventario.Add(new Inventario(existencia, precio, costo, producto));
        }
    }
}
