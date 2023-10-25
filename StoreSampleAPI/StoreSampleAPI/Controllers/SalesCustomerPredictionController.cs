using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StoreSampleAPI.Data;
using StoreSampleAPI.Models.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreSampleAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesCustomerPredictionController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public SalesCustomerPredictionController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetCustomerPredictions()
        {
            var predictions = _db.SalesCustomerPredictions
                .Select(scp => new SalesCustomerPredictionDTO
                {
                    CustomerName = scp.CustomerName,
                    LastOrderDate = scp.LastOrderDate,
                    NextPredictedOrder = scp.NextPredictedOrder
                })
                .ToList();

            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:5173");
            return Ok(predictions);
        }
    }
}

