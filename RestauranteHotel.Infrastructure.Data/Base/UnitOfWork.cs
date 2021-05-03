using RestauranteHotel.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context) => _context = context;

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
