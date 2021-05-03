using RestauranteHotel.Domain.Contracts;
using RestauranteHotel.Domain.Repositories;
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
        private readonly IProductoSimpleRepository _productoSimpleRepository;

        public EntradaProductoSimpleService(IUnitOfWork unitOfWork, IProductoSimpleRepository productoSimpleRepository)
        {
            _unitOfWork = unitOfWork;
            _productoSimpleRepository = productoSimpleRepository;
        }

        public EntradaProductoSimpleResponse Entrada(EntradaProductoSimpleRequest request)
        {
            var producto = _productoSimpleRepository.Find(request.Id);//infraestructura-datos// }

            if (producto != null)
            {
                var res = producto.Entrada(request.existencia);
                if (res == $"Registro Exitoso, Nueva Existencia: {producto.Existencia} del Prodcuto {producto.Nombre}")
                {
                    _unitOfWork.Commit();
                    return new EntradaProductoSimpleResponse("Producto simple actualizado");
                }
                return new EntradaProductoSimpleResponse("Producto simple no fue actualizado");
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
