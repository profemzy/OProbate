using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebApplication.Dtos;
using WebApplication.Models;

namespace WebApplication.Controllers.Api
{
    public class StaffsController : ApiController
    {
        private ApplicationDbContext _context;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/staffs

        public IHttpActionResult GetStaffs(string query = null)
        {
            var staffsQuery = _context.Staffs
               .Include(c => c.Department);

            if (!String.IsNullOrWhiteSpace(query))
                staffsQuery = staffsQuery.Where(s => s.Lastname.Contains(query));

            var staffDtos = staffsQuery
                .ToList()
                .Select(Mapper.Map<Staff, StaffDto>);

            return Ok(staffDtos);
        }

        // GET /api/staffs/1
        public IHttpActionResult GetStaff(int id)
        {
            var staff = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staff == null)
                return NotFound();

            return Ok(Mapper.Map<Staff, StaffDto>(staff));
        }

        // POST /api/staffs
        [HttpPost]
        public IHttpActionResult CreateStaff(StaffDto staffDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var staff = Mapper.Map<StaffDto, Staff>(staffDto);
            _context.Staffs.Add(staff);
            _context.SaveChanges();

            staffDto.Id = staff.Id;
            return Created(new Uri(Request.RequestUri + "/" + staff.Id), staffDto);
        }

        // PUT /api/staffs/1
        [HttpPut]
        public IHttpActionResult UpdateStaff(int id, StaffDto staffDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var staffInDb = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staffInDb == null)
                return NotFound();

            Mapper.Map(staffDto, staffInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteStaff(int id)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(c => c.Id == id);

            if (staffInDb == null)
                return NotFound();

            _context.Staffs.Remove(staffInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
