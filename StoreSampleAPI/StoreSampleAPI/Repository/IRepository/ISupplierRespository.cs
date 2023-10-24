using StoreSampleAPI.Models;
namespace StoreSampleAPI.Repository.IRepository
{
	public interface ISupplierRespository : IRepository<Supplier>
    {
        Task<Supplier> Actualizar(Supplier entidad);
    }
}

