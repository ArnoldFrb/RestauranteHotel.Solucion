using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Aplication
{
    class EntradaProductoSimpleService
    {
    }

    public record EntradaProductoSimpleRequest(string nombre, decimal existencia, decimal precio, decimal costo);
    public record EntradaProductoSimpleResponse(string Mensaje);
}
