using StoreSampleAPI.Models;
namespace StoreSampleAPI.Repository.IRepository
{
	public interface IProductRepository : IRepository<Product>
    {
        Task<Product> Actualizar(Product entidad);
    }
}

