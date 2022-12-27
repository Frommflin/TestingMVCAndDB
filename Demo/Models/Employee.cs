using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        [Required]
        public bool IsCEO { get; set; }

        [Required]
        public bool IsManager { get; set; }

        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

    }
}
