﻿using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using WebApplication.Dtos;
using WebApplication.Models;

namespace WebApplication.Controllers.Api
{
   
    public class ArchivesController : ApiController
    {
        private ApplicationDbContext _context;

        public ArchivesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/archives
        public IHttpActionResult GetArchives(string query = null)
        {
            var archivesQuery = _context.Archives;


            if (!String.IsNullOrWhiteSpace(query))
                archivesQuery = archivesQuery.Where(a => a.Name.Contains(query)) as DbSet<Archive>;  

            var archiveDtos = archivesQuery
                .ToList()
                .Select(Mapper.Map<Archive, ArchiveDto>);

            return Ok(archiveDtos);
        }


        // GET /api/archives/1
        public IHttpActionResult GetArchive(int id)
        {
            var archive = _context.Archives.SingleOrDefault(a => a.Id == id);
            if (archive == null)
                return NotFound();

            return Ok(Mapper.Map<Archive, ArchiveDto>(archive));
        }

        // POST /api/archives
        [HttpPost]
        public IHttpActionResult CreateArchive(ArchiveDto archiveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            const string folderName = @"c:\OndoProbate";
            var pathString = Path.Combine(folderName, "CASE" + Guid.NewGuid());

            var archive = Mapper.Map<ArchiveDto, Archive>(archiveDto);
            archive.FilePath = pathString;
            _context.Archives.Add(archive);
            Directory.CreateDirectory(pathString);
            _context.SaveChanges();

            archiveDto.Id = archive.Id;
            return Created(new Uri(Request.RequestUri + "/" + archive.Id), archiveDto);
        }


        // PUT /api/archives/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, ArchiveDto archiveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var archiveInDb = _context.Archives.SingleOrDefault(a => a.Id == id);

            if (archiveInDb == null)
                return NotFound();

            Mapper.Map(archiveDto, archiveInDb);

            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/archives/1
        [HttpDelete]
        public IHttpActionResult DeleteArchive(int id)
        {
            var archiveInDb = _context.Archives.SingleOrDefault(a => a.Id == id);

            if (archiveInDb == null)
                return NotFound();

            _context.Archives.Remove(archiveInDb);
            _context.SaveChanges();

            return Ok();
        }


    }
}
