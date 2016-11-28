using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ArchiveRequest
    {
        public int Id { get; set; }

        [Required]
        public Staff Staff { get; set; }

        [Required]
        public Archive Archive { get; set; }

        public DateTime ReqDate { get; set; }

    }
}