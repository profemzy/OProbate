using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Dtos
{
    public class StaffDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(255)]
        public string Lastname { get; set; }

        public byte DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
    }
}