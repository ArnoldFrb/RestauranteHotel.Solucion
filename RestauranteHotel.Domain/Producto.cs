using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain
{
    public abstract class Producto
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public int Existencia { get; set; }
        public decimal Precio { get; protected set; }
        public decimal Costo { get; protected set; }

        protected Producto(string id, string nombre, int existencia, decimal precio, decimal costo)
        {
            Id = id;
            Nombre = nombre;
            Existencia = existencia;
            Precio = precio;
            Costo = costo;
        }
    }
}
