using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models
{
	public class OrderInsertParameters
	{
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ShipperId { get; set; }
        [Required]
        public string ShipName { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string ShipCity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime RequiredDate { get; set; }
        [Required]
        public decimal Freight { get; set; }
        [Required]
        public string ShipCountry { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public decimal Discount { get; set; }
    }
}

