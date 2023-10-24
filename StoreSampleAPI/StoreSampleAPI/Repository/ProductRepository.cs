using StoreSampleAPI.Data;
using StoreSampleAPI.Models;
using StoreSampleAPI.Repository.IRepository;

namespace StoreSampleAPI.Repository
{
	public class ProductRepository:Repository<Product>, IProductRepository
	{
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Product> Actualizar(Product entidad)
        {
            _db.Products.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}

