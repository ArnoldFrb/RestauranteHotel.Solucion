using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Aplication
{
    class SalidaProductoCompuestoService
    {
    }

    public record SalidaProductoCompuestoRequest(string nombre, decimal existencia, decimal precio, decimal costo);
    public record SalidaProductoCompuestoResponse(string Mensaje);
}
