using StoreSampleAPI.Models;

namespace StoreSampleAPI.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> Actualizar(Customer entidad);
    }
}