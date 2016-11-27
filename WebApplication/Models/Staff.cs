using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string  Lastname { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department")]
        public byte DepartmentId { get; set; }

     
    }
}