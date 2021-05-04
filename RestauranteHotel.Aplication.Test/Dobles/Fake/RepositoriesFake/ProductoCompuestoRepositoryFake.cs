using RestauranteHotel.Domain.Contracts;
using RestauranteHotel.Domain.Entity;
using RestauranteHotel.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RestauranteHotel.Aplication.Test.Dobles.RepositoriesFake
{
    class ProductoCompuestoRepositoryFake : IProductoCompuestoRepository
    {
        public void Add(ProductoCompuesto entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<ProductoCompuesto> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductoCompuesto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<ProductoCompuesto> entities)
        {
            throw new NotImplementedException();
        }

        public ProductoCompuesto Find(object id)
        {
            var producto = new ProductoCompuesto("pan sencillo", 13, 5000, 3500);
            var list = new List<ProductoSimple>();

            list.Add(new ProductoSimple("Queso", 50, 700, 500));
            list.Add(new ProductoSimple("Pan", 30, 1000, 600));
            list.Add(new ProductoSimple("Salchicha", 40, 800, 500));

            producto.ListaProductos(list);

            return producto;
        }

        public IEnumerable<ProductoCompuesto> FindBy(Expression<Func<ProductoCompuesto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoCompuesto> FindBy(Expression<Func<ProductoCompuesto, bool>> filter = null, Func<IQueryable<ProductoCompuesto>, IOrderedQueryable<ProductoCompuesto>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public ProductoCompuesto FindFirstOrDefault(Expression<Func<ProductoCompuesto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductoCompuesto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductoCompuesto entity)
        {
            throw new NotImplementedException();
        }
    }
}
