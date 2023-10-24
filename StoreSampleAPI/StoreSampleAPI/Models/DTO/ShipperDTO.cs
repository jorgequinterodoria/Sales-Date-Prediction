using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.DTO
{
	public class ShipperDTO
	{
        [Required]
        public int ShipperId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}

