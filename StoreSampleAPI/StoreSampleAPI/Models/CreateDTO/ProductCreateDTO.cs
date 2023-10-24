using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.CreateDTO
{
	public class ProductCreateDTO
	{
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}

