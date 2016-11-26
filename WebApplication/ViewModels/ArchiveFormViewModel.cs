using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class ArchiveFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "File Name")]
        public string Name { get; set; }

        [Display(Name = "File Path")]
        public string FilePath { get; set; }

        [Required]
        [Display(Name = "File Date")]
        public DateTime CaseDate { get; set; }  

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Archive" : "New Archive";
            }
        }

        public ArchiveFormViewModel()
        {
            Id = 0;
        }

        public ArchiveFormViewModel(Archive archive)
        {
            Id = archive.Id;
            Name = archive.Name;
            CaseDate = archive.CaseDate;
            FilePath = archive.FilePath;
            CategoryId = archive.CategoryId;
        }
    }
}