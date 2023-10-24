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
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public OrderController(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetOrders(int? id = null)
        {
            try
            {
                if (id.HasValue)
                {
                    IEnumerable<Order> orderList = await _orderRepo.ObtenerTodos(o => o.CustId == id, incluirPropiedades: "Shipper,Employee,Customer");
                    _response.Resultado = _mapper.Map<IEnumerable<OrderDTO>>(orderList);
                }
                else
                {
                    IEnumerable<Order> orderList = await _orderRepo.ObtenerTodos(incluirPropiedades: "Shipper,Employee,Customer");
                    _response.Resultado = _mapper.Map<IEnumerable<OrderDTO>>(orderList);
                }
                
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("OrdersPaginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> getOrdersPaginated([FromQuery] Parameters parameters)
        {
            try
            {
                var orderList = _orderRepo.ObtenerTodosPaginado(parameters, incluirPropiedades: "Shipper,Employee,Customer");
                _response.Resultado = _mapper.Map<IEnumerable<OrderDTO>>(orderList);
                _response.statusCode = HttpStatusCode.OK;
                _response.TotalPaginas = orderList.MetaData.TotalPages;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>>GetOrder(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.statusCode = HttpStatusCode.BadRequest;
                    _response.IsExitoso = false;
                    return BadRequest(_response);
                }

                var orderByCustomer = await _orderRepo
                    .Obtener(o => o.CustId == id, incluirPropiedades: "Shipper,Employee,Customer");



                if (orderByCustomer == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }

                _response.Resultado = _mapper.Map<OrderDTO>(orderByCustomer);
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
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
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody] OrderCreateDTO createDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if(await _orderRepo.Obtener(o => o.CustId == createDTO.CustId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "The customer ID doesn't Exist!");
                    return BadRequest(ModelState);
                }

                if (await _orderRepo.Obtener(o => o.EmpId == createDTO.EmpId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "The employee ID doesn't Exist!");
                    return BadRequest(ModelState);
                }

                if (await _orderRepo.Obtener(o => o.ShipperId == createDTO.ShipperId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "The Shipper ID doesn't Exist!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Order modelo = _mapper.Map<Order>(createDTO);
                await _orderRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;
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

