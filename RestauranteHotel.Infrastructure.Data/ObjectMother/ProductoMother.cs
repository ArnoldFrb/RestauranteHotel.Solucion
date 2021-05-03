﻿using RestauranteHotel.Domain.Entity;
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
            return new ProductoSimple(nombre, 13, 5000, 3500); ;
        }
    }
}
