﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Department
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}