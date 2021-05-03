using RestauranteHotel.Domain.Contracts;
using RestauranteHotel.Domain.Entity;
using RestauranteHotel.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.Data.Repositories
{
    public class ProductoCompuestoRepository : GenericRepository<ProductoCompuesto>, IProductoCompuestoRepository
    {
        public ProductoCompuestoRepository(IDbContext context) : base(context)
        {
        }
    }
}
