using RestauranteHotel.Domain.Entity;
using RestauranteHotel.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteHotel.Aplication.Test.Dobles
{
    class ProyectoRepositoryFake : IProductoSimpleRepository
    {
        public void Add(ProductoSimple entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<ProductoSimple> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductoSimple entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<ProductoSimple> entities)
        {
            throw new NotImplementedException();
        }

        public ProductoSimple Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoSimple> FindBy(Expression<Func<ProductoSimple, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoSimple> FindBy(Expression<Func<ProductoSimple, bool>> filter = null, Func<IQueryable<ProductoSimple>, IOrderedQueryable<ProductoSimple>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public ProductoSimple FindFirstOrDefault(Expression<Func<ProductoSimple, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoSimple> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductoSimple entity)
        {
            throw new NotImplementedException();
        }
    }
}
