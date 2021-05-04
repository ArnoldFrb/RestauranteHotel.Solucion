using RestauranteHotel.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.Data.ObjectMother
{
    public static class ProductoMother
    {
        public static ProductoSimple CreateProducto(string nombre)
        {
            return new ProductoSimple(nombre, 13, 5000, 3500);
        }

        public static ProductoCompuesto CreateProductoCompuesto(string nombre)
        {
            var producto = new ProductoCompuesto(nombre, 13, 5000, 3500);
            var list = new List<ProductoSimple>();

            list.Add(new ProductoSimple("Queso", 50, 700, 500));
            list.Add(new ProductoSimple("Pan", 30, 1000, 600));
            list.Add(new ProductoSimple("Salchicha", 40, 800, 500));

            producto.ListaProductos(list);

            return producto;
        }
    }
}
