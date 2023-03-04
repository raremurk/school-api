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
            CreateMap<Student, StudentDTO>();
            CreateMap<Class, ClassDTO>().ForMember("ClassTeacherFullName", opt => opt.MapFrom
            (c => c.ClassTeacher.LastName + " " + c.ClassTeacher.FirstName + " " + c.ClassTeacher.MiddleName));
            CreateMap<Teacher, TeacherFullNameDTO>().ForMember("FullName", opt => opt.MapFrom
            (c => c.LastName + " " + c.FirstName + " " + c.MiddleName));
            CreateMap<SchoolDay, SchoolDayDTO>()
                .ForMember("Lesson1", x => x.MapFrom(c => c.Lesson1.Name))
                .ForMember("Lesson2", x => x.MapFrom(c => c.Lesson2.Name))
                .ForMember("Lesson3", x => x.MapFrom(c => c.Lesson3.Name))
                .ForMember("Lesson4", x => x.MapFrom(c => c.Lesson4.Name))
                .ForMember("Lesson5", x => x.MapFrom(c => c.Lesson5.Name))
                .ForMember("Lesson6", x => x.MapFrom(c => c.Lesson6.Name))
                .ForMember("Lesson7", x => x.MapFrom(c => c.Lesson7.Name));
        }
    }
}
