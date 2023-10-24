using System;
using StoreSampleAPI.Data;
using StoreSampleAPI.Models;
using StoreSampleAPI.Repository.IRepository;

namespace StoreSampleAPI.Repository
{
	public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
	{
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Employee> Actualizar(Employee entidad)
        {
            _db.Employees.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}

