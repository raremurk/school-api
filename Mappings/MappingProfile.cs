using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.ViewModels;
using School.Models;

namespace School.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherDTO>();                
        }
    }
}
