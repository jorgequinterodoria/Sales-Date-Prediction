using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSampleAPI.Models
{
    [Table("CustomerPredictions", Schema = "Sales")]
    public class SalesCustomerPrediction
	{
        public string? CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}

