using System;
using StoreSampleAPI.Models.Especifications;
using System.Linq.Expressions;

namespace StoreSampleAPI.Repository.IRepository
{
	public interface IRepository<T> where T : class
    {
        Task Crear(T entidad);

        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, string? incluirPropiedades = null);

        PagedList<T> ObtenerTodosPaginado(Parameters parametros, Expression<Func<T, bool>>? filtro = null, string? incluirPropiedades = null);

        Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true, string? incluirPropiedades = null);

        Task Remover(T entidad);

        Task Grabar();
    }
}

