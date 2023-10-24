using StoreSampleAPI.Models;
namespace StoreSampleAPI.Repository.IRepository
{
	public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> Actualizar(Employee entidad);
    }
}

