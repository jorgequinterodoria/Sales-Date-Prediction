﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSampleAPI.Models
{
    [Table("Suppliers", Schema = "Production")]
    public class Supplier
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

