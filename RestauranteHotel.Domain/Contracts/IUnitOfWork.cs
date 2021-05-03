using RestauranteHotel.Domain.Repositories;

namespace RestauranteHotel.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
