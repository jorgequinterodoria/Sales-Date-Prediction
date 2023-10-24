using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.DTO
{
	public class ProductDTO
	{
        [Required]
        public int ProductId { get; set; }

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

