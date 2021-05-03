using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteHotel.Aplication;
using RestauranteHotel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoCompuestoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoCompuestoRepository _productoCompuestoRepository;
        public ProductoCompuestoController(IUnitOfWork unitOfWork, IProductoCompuestoRepository productoCompuestoRepository)
        {

            _unitOfWork = unitOfWork;
            _productoCompuestoRepository = productoCompuestoRepository;


            /*if (!productoSimpleRepository.GetAll().Any())
            {
                var cuenta = new CuentaAhorro("10001", "Cuenta ejemplo", "VALLEDUPAR", "cliente@bancoacme.com");
                cuentaBancariaRepository.Add(cuenta);
                unitOfWork.Commit();
            }*/
        }

        [HttpPost("salida-compuesto-simple")]
        public SalidaProductoCompuestoResponse PostSalida(SalidaProductoCompuestoRequest request)
        {
            var service = new SalidaProductoCompuestoService(_unitOfWork, _productoCompuestoRepository);
            var response = service.Salida(request);
            return response;
        }
    }
}
