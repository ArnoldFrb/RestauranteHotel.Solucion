using RestauranteHotel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Aplication
{
    public class EntradaProductoSimpleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;

        public EntradaProductoSimpleService(IUnitOfWork unitOfWork, IProductoRepository productoRepository)
        {
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }

        public EntradaProductoSimpleResponse entradaProductoSiemple(EntradaProductoSimpleRequest request)
        {
            var producto = _productoRepository.Find(request.Id);//infraestructura-datos// }

            if (producto != null)
            {
                producto.Entrada(request.existencia);
                _unitOfWork.Commit();
                return new EntradaProductoSimpleResponse("Producto siemple actualizado");
            }
            else
            {
                return new EntradaProductoSimpleResponse("Producto simple no encontrado");
            }
        }

    }


    public record EntradaProductoSimpleRequest(int Id, string nombre, decimal existencia, decimal precio, decimal costo);
    public record EntradaProductoSimpleResponse(string Mensaje);
}
