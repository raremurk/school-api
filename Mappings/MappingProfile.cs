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
            CreateMap<Lesson, LessonDTO>().ForMember("AcademicSubjectName", opt => opt.MapFrom
            (c => c.AcademicSubject.ShortName));;
            CreateMap<AcademicSubject, AcademicSubjectDTO>();
            CreateMap<Class, ClassDTO>().ForMember("ClassTeacherFullName", opt => opt.MapFrom
            (c => c.ClassTeacher.LastName + " " + c.ClassTeacher.FirstName[0] + "." + c.ClassTeacher.MiddleName[0] + "."));
            CreateMap<Teacher, TeacherFullNameDTO>().ForMember("FullName", opt => opt.MapFrom
            (c => c.LastName + " " + c.FirstName[0] + ". " + c.MiddleName[0] + "."));
        }
    }
}
