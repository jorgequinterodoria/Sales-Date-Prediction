using System;
using StoreSampleAPI.Data;
using StoreSampleAPI.Models;
using StoreSampleAPI.Repository.IRepository;

namespace StoreSampleAPI.Repository
{
	public class ShipperRepository: Repository<Shipper>, IShipperRepository
    {
        private readonly ApplicationDbContext _db;
        public ShipperRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Shipper> Actualizar(Shipper entidad)
        {
            _db.Shippers.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}

