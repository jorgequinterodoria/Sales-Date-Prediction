using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSampleAPI.Models
{
    [Table("Orders", Schema = "Sales")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public int? CustId { get; set; }

        [ForeignKey("CustId")]
        public Customer Customer { get; set; }

        [Required]
        public int EmpId { get; set; }

        [ForeignKey("EmpId")]
        public Employee Employee { get; set; } 

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        [Required]
        public int ShipperId { get; set; }

        [ForeignKey("ShipperId")]
        public Shipper Shipper { get; set; } 

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
    }

}

