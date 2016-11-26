using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class StaffFormViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
       
        public Staff Staff { get; set; }

    }
}