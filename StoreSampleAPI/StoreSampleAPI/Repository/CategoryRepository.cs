using System;
using StoreSampleAPI.Data;
using StoreSampleAPI.Models;
using StoreSampleAPI.Repository.IRepository;

namespace StoreSampleAPI.Repository
{
	public class CategoryRepository:Repository<Category>, ICategoryRepository
	{
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Category> Actualizar(Category entidad)
        {
            _db.Categories.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}

