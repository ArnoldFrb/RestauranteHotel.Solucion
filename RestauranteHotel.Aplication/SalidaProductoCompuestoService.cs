using RestauranteHotel.Domain.Contracts;
using RestauranteHotel.Domain.Entity;
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
        private readonly IProductoCompuestoRepository _productoCompuestoRepository;

        public SalidaProductoCompuestoService(IUnitOfWork unitOfWork, IProductoCompuestoRepository productoCompuestoRepository)
        {
            _unitOfWork = unitOfWork;
            _productoCompuestoRepository = productoCompuestoRepository;
        }

        
        public SalidaProductoCompuestoResponse Salida(SalidaProductoCompuestoRequest request)
        {
            var producto = _productoCompuestoRepository.Find(request.Id);//infraestructura-datos// }

            if (producto != null)
            {
                producto.ListaProductos(request.productos);
                var res = producto.Salida(request.existencia);
                if (res == "Venta Exitosa")
                {
                    _unitOfWork.Commit();
                    return new SalidaProductoCompuestoResponse("Producto compuesto actualizado");
                }
                return new SalidaProductoCompuestoResponse("Producto compuesto no fue actualizado");
            }
            else
            {
                return new SalidaProductoCompuestoResponse("Producto compuesto no encontrado");
            }

        }

    }

    public record SalidaProductoCompuestoRequest(int Id, string nombre, decimal existencia, decimal precio, decimal costo, List<ProductoSimple> productos);
    public record SalidaProductoCompuestoResponse(string Mensaje);
}
