using RestauranteHotel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Aplication
{
    public class SalidaProductoCompuestoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;

        public SalidaProductoCompuestoService(IUnitOfWork unitOfWork, IProductoRepository productoRepository)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }

        
        public SalidaProductoCompuestoResponse salidaProductoCompuesto(SalidaProductoCompuestoRequest request)
        {
            var producto = _productoRepository.Find(request.Id);//infraestructura-datos// }

            if (producto != null)
            {
                producto.Salida(request.existencia);
                _unitOfWork.Commit();
                return new SalidaProductoCompuestoResponse("Producto compuesto actualizado");
            }
            else
            {
                return new SalidaProductoCompuestoResponse("Producto compuesto no encontrado");
            }

        }

    }

    public record SalidaProductoCompuestoRequest(int Id, string nombre, decimal existencia, decimal precio, decimal costo);
    public record SalidaProductoCompuestoResponse(string Mensaje);
}
