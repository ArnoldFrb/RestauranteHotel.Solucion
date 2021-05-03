using RestauranteHotel.Domain.Entity;
using RestauranteHotel.Domain.Repositories;
using RestauranteHotel.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.Data.Repositories
{
    public class ProductoSimpleRepository : GenericRepository<ProductoSimple>, IProductoSimpleRepository
    {
        public ProductoSimpleRepository(IDbContext context) : base(context)
        {
        }
    }
}
