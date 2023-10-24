using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreSampleAPI.Models;
using StoreSampleAPI.Models.CreateDTO;
using StoreSampleAPI.Models.DTO;
using StoreSampleAPI.Models.Especifications;
using StoreSampleAPI.Repository.IRepository;


namespace StoreSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public CategoryController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> getCategories()
        {
            try
            {
                IEnumerable<Category> categoryList = await _categoryRepo.ObtenerTodos();
                _response.Resultado = _mapper.Map<IEnumerable<CategoryDTO>>(categoryList);
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("CategoriesPaginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> getCategoriesPaginated([FromQuery] Parameters parameters)
        {
            try
            {
                var categoryList = _categoryRepo.ObtenerTodosPaginado(parameters);
                _response.Resultado = _mapper.Map<IEnumerable<CategoryDTO>>(categoryList);
                _response.statusCode = HttpStatusCode.OK;
                _response.TotalPaginas = categoryList.MetaData.TotalPages;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>>getCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.statusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }
                var category = await _categoryRepo.Obtener(c => c.CategoryId == id);
                if (category == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = _mapper.Map<CategoryDTO>(category);
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CategoryCreateDTO createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if(await _categoryRepo.Obtener(c => c.CategoryName.ToLower() == createDto.CategoryName.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Category name already exists!");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                Category modelo = _mapper.Map<Category>(createDto);
                await _categoryRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetCategory", new { id = modelo.CategoryId }, _response);
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

