using StoreSampleAPI.Models;

namespace StoreSampleAPI.Repository.IRepository
{
	public interface ICategoryRepository:IRepository<Category>
	{
        Task<Category> Actualizar(Category entidad);
    }
}

