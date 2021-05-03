using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Infrastructure.Data.Base
{
    public class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase()
        {
        }
        public DbContextBase(DbContextOptions options) : base(options)
        {

        }
    }
}
