using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteHotel.Aplication;
using RestauranteHotel.Domain.Contracts;
using RestauranteHotel.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoSimpleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoSimpleRepository _productoSimpleRepository;
        public ProductoSimpleController (IUnitOfWork unitOfWork, IProductoSimpleRepository productoSimpleRepository)
        {

            _unitOfWork = unitOfWork;
            _productoSimpleRepository = productoSimpleRepository;


            /*if (!productoSimpleRepository.GetAll().Any())
            {
                var cuenta = new CuentaAhorro("10001", "Cuenta ejemplo", "VALLEDUPAR", "cliente@bancoacme.com");
                cuentaBancariaRepository.Add(cuenta);
                unitOfWork.Commit();
            }*/
        }

        [HttpPost("salida-producto-simple")]
        public SalidaProductoSimpleResponse PostSalida(SalidaProductoSimpleRequest request)
        {
            var service = new SalidaProductoSimpleService(_unitOfWork, _productoSimpleRepository);
            var response = service.Salida(request);
            return response;
        }

        [HttpPost("entrada-producto-simple")]
        public EntradaProductoSimpleResponse PostEntrada(EntradaProductoSimpleRequest request)
        {
            var service = new EntradaProductoSimpleService(_unitOfWork, _productoSimpleRepository);
            var response = service.Entrada(request);
            return response;
        }
    }
}
