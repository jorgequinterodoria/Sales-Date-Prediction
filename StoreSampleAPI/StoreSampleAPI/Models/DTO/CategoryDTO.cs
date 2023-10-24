﻿using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.DTO
{
	public class CategoryDTO
	{
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

