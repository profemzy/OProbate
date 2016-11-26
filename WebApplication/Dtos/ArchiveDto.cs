using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Dtos
{
    public class ArchiveDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string  Name { get; set; }

        public DateTime CaseDate { get; set; }

        public string FilePath { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        public CategoryDto Category { get; set; }

    }
}