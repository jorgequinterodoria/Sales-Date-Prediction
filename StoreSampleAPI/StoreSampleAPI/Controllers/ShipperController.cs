using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreSampleAPI.Models;
using StoreSampleAPI.Models.DTO;
using StoreSampleAPI.Models.Especifications;
using StoreSampleAPI.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperRepository _shipperRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public ShipperController(IShipperRepository shipperRepo, IMapper mapper)
        {
            _shipperRepo = shipperRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> getShippers()
        {
            try
            {
                IEnumerable<Shipper> shipperList = await _shipperRepo.ObtenerTodos();
                _response.Resultado = _mapper.Map<IEnumerable<Shipper>>(shipperList);
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
        public ActionResult<APIResponse> getCategoriesPaginated([FromQuery] Parameters parameters)
        {
            try
            {
                var shipperList = _shipperRepo.ObtenerTodosPaginado(parameters);
                _response.Resultado = _mapper.Map<IEnumerable<ShipperDTO>>(shipperList);
                _response.statusCode = HttpStatusCode.OK;
                _response.TotalPaginas = shipperList.MetaData.TotalPages;
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

