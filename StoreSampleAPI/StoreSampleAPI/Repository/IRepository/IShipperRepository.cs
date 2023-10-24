using StoreSampleAPI.Models;
namespace StoreSampleAPI.Repository.IRepository
{
	public interface IShipperRepository : IRepository<Shipper>
    {
        Task<Shipper> Actualizar(Shipper entidad);
    }
}

