using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSampleAPI.Models.DTO
{
	public class EmployeeUpdateDTO
	{
        [Required]
        public int EmpId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TitleOfCourtesy { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public string? Region { get; set; }
        public string? PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        public int? MgrId { get; set; }
    }
}

