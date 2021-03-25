using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain
{
    public class ProductoSimple : Producto
    {
        
        public ProductoSimple(string id, string nombre, int existencia, decimal precio, decimal costo) : base(id, nombre, existencia, precio, costo)
        {
        }
    }
}
