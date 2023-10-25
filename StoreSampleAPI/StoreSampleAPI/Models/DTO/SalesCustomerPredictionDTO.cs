using System;
namespace StoreSampleAPI.Models.DTO
{
	public class SalesCustomerPredictionDTO
	{
        public string? CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}

