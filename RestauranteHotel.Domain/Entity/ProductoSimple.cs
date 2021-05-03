using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteHotel.Domain.Entity
{
    public class ProductoSimple : Producto
    {
        public ProductoSimple(string nombre, decimal existencia, decimal precio, decimal costo) : base(nombre, existencia, precio, costo)
        {
        }

        public override string Entrada(decimal existencia)
        {
            if (Existencia == 0 && existencia <= 0)
            {
                return $"Registro Fallido, Existencia Ingresada: {existencia}";
            }
            if (Existencia > 0 && existencia <= 0)
            {
                return $"Registro Fallido, No Puede Sumar Existencias { existencia}";
            }
            if (Existencia == 0 && existencia > 0)
            {
                Existencia = existencia;
                return $"Registro Exitoso, Nueva Existencia: {Existencia} del Prodcuto {Nombre}";
            }
            if (Existencia > 0 && existencia > 0)
            {
                Existencia += existencia;
                return $"Registro Exitoso, Nueva Existencia: {Existencia} del Prodcuto {Nombre}";
            }
            throw new NotImplementedException();
        }

        public override string Salida(decimal existencia)
        {
            if (existencia <= 0)
            {
                return $"Registro Fallido, Existencia Solicitada: {existencia}";
            }
            if (Existencia < existencia)
            {
                return $"Registro Fallido, La Existencia solicitada {existencia} es Mayor a {Existencia}";
            }
            if (Existencia > existencia && existencia > 0)
            {
                Existencia -= existencia;
                return $"Venta Exitosa, Cantidad: {existencia}; Costo: {Costo}; Precio: {Precio}; Utilidad: {((Precio * existencia) - (Costo * existencia))}";
            }
            throw new NotImplementedException();
        }
    }
}
