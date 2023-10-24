using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.CreateDTO
{
	public class CategoryCreateDTO
	{
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

