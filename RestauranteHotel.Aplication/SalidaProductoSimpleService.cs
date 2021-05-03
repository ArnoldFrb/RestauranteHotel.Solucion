using RestauranteHotel.Domain.Contracts;
using System;

namespace RestauranteHotel.Aplication
{
    
    public class SalidaProductoSimpleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;

         
        public SalidaProductoSimpleResponse salidaProductoSimple(SalidaProductoSimpleRequest request)
        {
            var producto = _productoRepository.Find(request.Id);//infraestructura-datos// }

            if (producto != null)
            {
                producto.Salida(request.existencia);
                _unitOfWork.Commit();
                return new SalidaProductoSimpleResponse("Producto simple actualizado");
            }
            else
            {
                return new SalidaProductoSimpleResponse("Producto simple no encontrado");
            }
        }
    }
     
    public record SalidaProductoSimpleRequest(int Id,string nombre, decimal existencia, decimal precio, decimal costo);
    public record SalidaProductoSimpleResponse(string Mensaje);
}
