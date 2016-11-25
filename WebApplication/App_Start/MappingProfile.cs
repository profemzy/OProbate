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
            Mapper.CreateMap<Archive, ArchiveDto>();
            Mapper.CreateMap<ArchiveDto, Archive>();
        }
    }
}