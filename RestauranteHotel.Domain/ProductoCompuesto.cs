using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain
{
    public class ProductoCompuesto : Producto
    {
        public List<Producto> Productos;
        public ProductoCompuesto(string id, string nombre, int existencia, decimal precio, decimal costo, List<Producto> productos) : base(id, nombre, existencia, precio, costo)
        {

            Productos = productos;
        }
    }
}
