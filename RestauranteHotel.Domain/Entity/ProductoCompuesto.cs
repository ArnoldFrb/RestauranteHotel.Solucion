using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain.Entity
{
    public class ProductoCompuesto : Producto
    {
       

        public List<ProductoSimple> Productos { get; private set; }

        public ProductoCompuesto(string nombre, decimal existencia, decimal precio, decimal costo) : base(nombre, existencia, precio, costo)
        {
        }

        public override string Entrada(decimal existencia)
        {
            throw new NotImplementedException();
        }

        public override string Salida(decimal existencia)
        {
            if (existencia <= 0)
            {
                return $"Registro Fallido, Existencia Solicitada: {existencia}";
            }
            foreach (var pro in Productos) 
            {
                if (pro.Existencia < existencia && existencia > 0)
                {
                    return $"Registro Fallido, La Existencia solicitada {existencia} del prodcuto {pro.Nombre} es Mayor a {pro.Existencia}";
                }
            }
            if (existencia > 0)
            {
                foreach (var pro in Productos)
                {

                    if (pro.Existencia > existencia)
                    {
                        var res = pro.Salida(existencia);
                        if (res == $"Registro Exitoso, Nueva Existencia: {pro.Existencia} del Prodcuto {pro.Nombre}")
                        {
                            return res;
                        }
                        Precio += pro.Precio;
                        Costo += pro.Costo;
                    }
                }
                return $"Venta Exitosa, Cantidad: {existencia}; Costo: {Costo}; Precio: {Precio}; Utilidad: {((Precio * existencia) - (Costo * existencia))}";
            }
            throw new NotImplementedException();
        }

        public void ListaProductos(List<ProductoSimple> productos)
        {
            Productos = productos;
        }
    }
}
