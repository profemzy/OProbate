using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ArchivesController : Controller
    {
        private ApplicationDbContext _context;

        public ArchivesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Archives
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Archives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var archive = _context.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            return View(archive);
        }

        // GET: Archives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Archives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CaseDate,FilePath")] Archive archive)
        {
            if (ModelState.IsValid)
            {
                // Specify a name for your top-level folder.
                const string folderName = @"c:\OndoProbate";

                // To create a string that specifies the path to a subfolder under your 
                // top-level folder, add a name for the subfolder to folderName.
                var pathString = Path.Combine(folderName, "CASE" + Guid.NewGuid());

                archive.FilePath = pathString;

                _context.Archives.Add(archive);
                Directory.CreateDirectory(pathString);

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(archive);
        }

        // GET: Archives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var archive = _context.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            return View(archive);
        }

        // POST: Archives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CaseDate,FilePath")] Archive archive)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(archive).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(archive);
        }

        // GET: Archives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var archive = _context.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            return View(archive);
        }

        // POST: Archives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var archive = _context.Archives.Find(id);
            _context.Archives.Remove(archive);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OpenFile(int id)
        {
            var archive = _context.Archives.Find(id);
           
            if (archive == null)
                return HttpNotFound();

            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", archive.FilePath);
            return View("details", archive);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
