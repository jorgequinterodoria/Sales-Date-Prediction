using StoreSampleAPI.Models;
namespace StoreSampleAPI.Repository.IRepository
{
	public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        Task<OrderDetails> Actualizar(OrderDetails entidad);
    }
}

