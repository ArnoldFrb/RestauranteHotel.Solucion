using System;

namespace RestauranteHotel.Aplication
{
    public class SalidaProductoSimpleService
    {
    }

    public record SalidaProductoSimpleRequest(string nombre, decimal existencia, decimal precio, decimal costo);
    public record SalidaProductoSimpleResponse(string Mensaje);
}
