using StoreSampleAPI.Models;
namespace StoreSampleAPI.Repository.IRepository
{
	public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> Actualizar(Order entidad);
    }
}

