using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreSampleAPI.Models;
using StoreSampleAPI.Models.DTO;
using StoreSampleAPI.Models.Especifications;
using StoreSampleAPI.Repository.IRepository;

namespace StoreSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public EmployeeController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> getEmployees()
        {
            try
            {
                IEnumerable<Employee> employeeList = await _employeeRepo.ObtenerTodos();
                _response.Resultado = _mapper.Map<IEnumerable<Employee>>(employeeList);
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("EmployeesPaginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> getEmployeesPaginated([FromQuery] Parameters parameters)
        {
            try
            {
                var employeeList = _employeeRepo.ObtenerTodosPaginado(parameters);
                _response.Resultado = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeList);
                _response.statusCode = HttpStatusCode.OK;
                _response.TotalPaginas = employeeList.MetaData.TotalPages;
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

