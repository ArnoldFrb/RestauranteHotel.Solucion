using RestauranteHotel.Domain.Repositories;

namespace RestauranteHotel.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IProductoRepository ProductoRepository { get; }
        IProductoCompuestoRepository ProductoCompuesto { get; }
        ProductoSiempleRepository ProductoSimple { get; }
        void Commit();
    }
}
