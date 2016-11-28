using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Dtos
{
    public class NewArchiveRequestDto
    {
        public int StaffId { get; set; }
        public List<int> ArchiveIds { get; set; }   
    }
}