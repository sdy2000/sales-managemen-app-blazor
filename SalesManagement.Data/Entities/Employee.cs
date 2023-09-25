using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be greater than {1}!")]
        [MinLength(2, ErrorMessage = "{0} cannot be less than {1}!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be greater than {1}!")]
        [MinLength(2, ErrorMessage = "{0} cannot be less than {1}!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter {0}.")]
        [MaxLength(100, ErrorMessage = "{0} cannot be greater than {1}!")]
        [MinLength(10, ErrorMessage = "{0} cannot be less than {1}!")]
        [EmailAddress(ErrorMessage ="Please enter valid {0}")]
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ReportToEmpId { get; set; }
        public string ImagePath { get; set; }
        public int EmployeeJobTitleId { get; set; }
    }
}
