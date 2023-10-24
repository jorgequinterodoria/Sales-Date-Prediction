using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreSampleAPI.Models;
using StoreSampleAPI.Models.DTO;
using StoreSampleAPI.Models.Especifications;
using StoreSampleAPI.Repository.IRepository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreSampleAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public ProductController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> getProducts()
        {
            try
            {
                IEnumerable<Product> productList = await _productRepo.ObtenerTodos();
                _response.Resultado = _mapper.Map<IEnumerable<Product>>(productList);
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("ProductsPaginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> getCategoriesPaginated([FromQuery] Parameters parameters)
        {
            try
            {
                var productList = _productRepo.ObtenerTodosPaginado(parameters);
                _response.Resultado = _mapper.Map<IEnumerable<ProductDTO>>(productList);
                _response.statusCode = HttpStatusCode.OK;
                _response.TotalPaginas = productList.MetaData.TotalPages;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}

