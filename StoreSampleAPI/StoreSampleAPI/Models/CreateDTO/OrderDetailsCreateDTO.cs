using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.CreateDTO
{
	public class OrderDetailsCreateDTO
	{
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short Qty { get; set; }

        [Required]
        public decimal Discount { get; set; }
    }
}

