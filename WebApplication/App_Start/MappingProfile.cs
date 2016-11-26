using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication.Dtos;
using WebApplication.Models;

namespace WebApplication.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Archive, ArchiveDto>();
            Mapper.CreateMap<Staff, StaffDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Department, DepartmentDto>();


            // Dto to Domain
            Mapper.CreateMap<ArchiveDto, Archive>().ForMember(a => a.Id, opt => opt.Ignore());
            Mapper.CreateMap<ArchiveDto, Archive>().ForMember(a => a.Id, opt => opt.Ignore());
        }
    }
}