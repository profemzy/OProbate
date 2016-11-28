using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.Dtos;
using WebApplication.Models;
using System.Data.Entity;
using AutoMapper;

namespace WebApplication.Controllers.Api
{
 
    public class NewArchiveRequestController : ApiController
    {
        private ApplicationDbContext _context;

        public NewArchiveRequestController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewArchiveRequest(NewArchiveRequestDto newArchiveRequest)
        {
           var staff = _context.Staffs.Single(s => s.Id == newArchiveRequest.StaffId);

            var archives = _context.Archives.Where(a => newArchiveRequest.ArchiveIds.Contains(a.Id)).ToList();

            foreach (var archive in archives)
            {
                var archiveRequest = new ArchiveRequest
                {
                    Staff = staff,
                    Archive = archive,
                    ReqDate = DateTime.Now
                };
                _context.ArchiveRequests.Add(archiveRequest);
            }

            _context.SaveChanges();
            return Ok();

        }
    }
}
