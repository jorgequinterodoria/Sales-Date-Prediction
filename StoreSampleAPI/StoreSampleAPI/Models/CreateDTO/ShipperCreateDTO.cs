using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.CreateDTO
{
	public class ShipperCreateDTO
	{
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}

