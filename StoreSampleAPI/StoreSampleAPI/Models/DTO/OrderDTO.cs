using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.DTO
{
	public class OrderDTO
	{
        [Required]
        public int OrderId { get; set; }

        public int? CustId { get; set; }

        [Required]
        public int EmpId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required]
        public int ShipperId { get; set; }

        [Required]
        public decimal Freight { get; set; }

        [Required]
        public string ShipName { get; set; }

        [Required]
        public string ShipAddress { get; set; }

        [Required]
        public string ShipCity { get; set; }

        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }

        [Required]
        public string ShipCountry { get; set; }

        public CustomerDTO Customer { get; set; }
        public EmployeeDTO Employee { get; set; }
        public ShipperDTO Shipper { get; set; }

    }
}

