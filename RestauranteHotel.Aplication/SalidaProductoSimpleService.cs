using RestauranteHotel.Domain.Contracts;
using RestauranteHotel.Domain.Repositories;
using System;

namespace RestauranteHotel.Aplication
{
    
    public class SalidaProductoSimpleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoSimpleRepository _productoSimpleRepository;

        public SalidaProductoSimpleService(IUnitOfWork unitOfWork, IProductoRepository productoRepository)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }

        public SalidaProductoSimpleResponse salidaProductoSimple(SalidaProductoSimpleRequest request)

        {
            _unitOfWork = unitOfWork;
            _productoSimpleRepository = productoSimpleRepository;
        }

        public SalidaProductoSimpleResponse Salida(SalidaProductoSimpleRequest request)
        {
            var producto = _productoSimpleRepository.Find(request.Id);//infraestructura-datos// }

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
