using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreSampleAPI.Data;
using StoreSampleAPI.Models.DTO;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreSampleAPI.Models;

namespace StoreSampleAPI.Controllers
{
    public class OrderInsertParametersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public OrderInsertParametersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new APIResponse();
        }
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody] OrderInsertParametersDTO orderInsertDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                using (var connection = _context.Database.GetDbConnection() as SqlConnection)
                {
                    if (connection?.State != ConnectionState.Open)
                        connection?.Open();

                    using (var command = new SqlCommand("InsertOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeId", orderInsertDTO.EmployeeId);
                        command.Parameters.AddWithValue("@ShipperId", orderInsertDTO.ShipperId);
                        command.Parameters.AddWithValue("@ShipName", orderInsertDTO.ShipName);
                        command.Parameters.AddWithValue("@ShipAddress", orderInsertDTO.ShipAddress);
                        command.Parameters.AddWithValue("@ShipCity", orderInsertDTO.ShipCity);
                        command.Parameters.AddWithValue("@OrderDate", orderInsertDTO.OrderDate);
                        command.Parameters.AddWithValue("@RequiredDate", orderInsertDTO.RequiredDate);
                        command.Parameters.AddWithValue("@Freight", orderInsertDTO.Freight);
                        command.Parameters.AddWithValue("@ShipCountry", orderInsertDTO.ShipCountry);
                        command.Parameters.AddWithValue("@ProductId", orderInsertDTO.ProductId);
                        command.Parameters.AddWithValue("@UnitPrice", orderInsertDTO.UnitPrice);
                        command.Parameters.AddWithValue("@Qty", orderInsertDTO.Qty);
                        command.Parameters.AddWithValue("@Discount", orderInsertDTO.Discount);

                        await command.ExecuteNonQuery();
                    }
                }

                return Created("api/order", new { Message = "Order created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error creating order", Error = ex.Message });
            }
        }

    }
}

