using AutoMapper;
using AMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Data.Dtos;

namespace AMS.Data.AutoMapper
{
    public class EfToDtoMappingProfile : Profile
    {
        public EfToDtoMappingProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
