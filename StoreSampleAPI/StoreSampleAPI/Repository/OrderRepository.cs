using System;
using StoreSampleAPI.Data;
using StoreSampleAPI.Models;
using StoreSampleAPI.Repository.IRepository;

namespace StoreSampleAPI.Repository
{
	public class OrderRepository:Repository<Order>, IOrderRepository
	{
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Order>Actualizar(Order entidad)
        {
            _db.Orders.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
	}
}

