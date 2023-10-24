using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.DTO
{
	public class SupplierDTO
	{
        [Required]
        public int SupplierId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactTitle { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Fax { get; set; }
    }
}

