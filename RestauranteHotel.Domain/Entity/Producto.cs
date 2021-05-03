using RestauranteHotel.Domain.Base;
using RestauranteHotel.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain
{
    public abstract class Producto : Entity<string>, IServicioProducto, IAggregateRoot
    {
        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public decimal Existencia { get; protected set; }
        public decimal Precio { get; protected set; }
        public decimal Costo { get; protected set; }

        protected Producto(string id, string nombre, decimal existencia, decimal precio, decimal costo)
        {
            Id = id;
            Nombre = nombre;
            Existencia = existencia;
            Precio = precio;
            Costo = costo;
        }

        public abstract string Entrada(decimal existencia);
        public abstract string Salida(decimal existencia);
    }
}