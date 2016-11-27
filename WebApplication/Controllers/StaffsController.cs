using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    [Authorize(Roles = RoleName.CanManageArchives)]
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var departments = _context.Departments.ToList();
            var viewModel = new StaffFormViewModel
            {
                Staff = new Staff(),
                Departments = departments
            };

            return View("StaffForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StaffFormViewModel()
                {
                    Staff = staff,
                    Departments = _context.Departments.ToList()
                };

                return View("StaffForm", viewModel);
            }

            if (staff.Id == 0)
                _context.Staffs.Add(staff);
            else
            {
                var staffInDb = _context.Staffs.Single(c => c.Id == staff.Id);
                staffInDb.Firstname = staff.Firstname;
                staffInDb.Lastname = staff.Lastname;
                staffInDb.DepartmentId = staff.DepartmentId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Staffs");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var staff = _context.Staffs.Include(c => c.Department).SingleOrDefault(c => c.Id == id);

            if (staff == null)
                return HttpNotFound();

            return View(staff);
        }

        public ActionResult Edit(int id)
        {
            var staff = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staff == null)
                return HttpNotFound();

            var viewModel = new StaffFormViewModel()
            {
                Staff = staff,
                Departments = _context.Departments.ToList()
            };

            return View("StaffForm", viewModel);
        }

    }
}