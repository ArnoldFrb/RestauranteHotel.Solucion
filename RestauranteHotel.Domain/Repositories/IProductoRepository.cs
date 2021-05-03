using RestauranteHotel.Domain.Base;
using RestauranteHotel.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Domain.Contracts
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        
    }
}
