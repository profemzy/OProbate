using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
   
    public class ArchivesController : Controller
    {
        private ApplicationDbContext _context;

        public ArchivesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Archives
        public ActionResult Index()
        {
            return User.IsInRole("CanManageArchives") ? View("List") : View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageArchives)]
        public ViewResult New()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new ArchiveFormViewModel
            {
                Categories = categories
            };

            return View("ArchiveForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageArchives)]
        public ActionResult Edit(int id)
        {
            var archive = _context.Archives.SingleOrDefault(a => a.Id == id);
            if (archive == null)
                return HttpNotFound();

            var viewModel = new ArchiveFormViewModel(archive)
            {
                Categories = _context.Categories.ToList()
            };

            return View("ArchiveForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var archive = _context.Archives.Include(a => a.Category).SingleOrDefault(a => a.Id == id);

            if (archive == null)
                return HttpNotFound();

            return View(archive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageArchives)]
        public ActionResult Save(Archive archive)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ArchiveFormViewModel(archive)
                {
                    Categories = _context.Categories.ToList()
                };
                return View("ArchiveForm", viewModel);
            }

            // Create New Archive
            if (archive.Id == 0)
            {
                // Specify a name for your top-level folder.
                const string folderName = @"c:\OndoProbate";

                // To create a string that specifies the path to a subfolder under your 
                // top-level folder, add a name for the subfolder to folderName.
                var pathString = Path.Combine(folderName, "CASE" + Guid.NewGuid());

                archive.FilePath = pathString;

                Category category = _context.Categories.Single(c => c.Id == archive.CategoryId);
                archive.Category = category;
                _context.Archives.Add(archive);
                Directory.CreateDirectory(pathString);
            }
            // Edit Existing Archive
            else
            {
                var archiveInDb = _context.Archives.Single(a => a.Id == archive.Id);
                archiveInDb.Name = archive.Name;
                archiveInDb.FilePath = archive.FilePath;
                archiveInDb.CaseDate = archive.CaseDate;
                archiveInDb.CategoryId = archive.CategoryId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Archives");
        }



        public ActionResult OpenFile(int id)
        {
            var archive = _context.Archives.Find(id);
           
            if (archive == null)
                return HttpNotFound();

            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", archive.FilePath);
            return View("details", archive);

        }

    }
}
