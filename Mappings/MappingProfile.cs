using AutoMapper;
using School_API.ViewModels;
using School_API.Models;

namespace School_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AcademicSubject, AcademicSubjectDTO>().ReverseMap();

            CreateMap<Student, StudentDTO>().ReverseMap();

            CreateMap<Teacher, TeacherDTO>().ReverseMap();

            CreateMap<Class, OnlyIdDTO>();
            CreateMap<ClassDTO, Class>();
            CreateMap<Class, ClassDTO>()
                .ForMember("ClassTeacherFullName", opt => opt.MapFrom
                    (c => c.ClassTeacher.LastName + " " + c.ClassTeacher.FirstName[0] + "." + c.ClassTeacher.MiddleName[0] + "."));

            CreateMap<LessonDTO, Lesson>();
            CreateMap<Lesson, LessonDTO>()
                .ForMember("AcademicSubjectName", opt => opt.MapFrom(c => c.AcademicSubject.Name));

            CreateMap<Teacher, TeacherFullNameDTO>()
                .ForMember("FullName", opt => opt.MapFrom
                    (c => c.LastName + " " + c.FirstName[0] + ". " + c.MiddleName[0] + "."));

            CreateMap<TeacherSubject, OnlyIdDTO>()
                .ForMember("Id", opt => opt.MapFrom(c => c.AcademicSubjectId));
            CreateMap<OnlyIdDTO, TeacherSubject>()
                .ForMember("AcademicSubjectId", opt => opt.MapFrom(c => c.Id));

            CreateMap<TeacherClass, OnlyIdDTO>()
                .ForMember("Id", opt => opt.MapFrom(c => c.ClassId));
            CreateMap<OnlyIdDTO, TeacherClass>()
                .ForMember("ClassId", opt => opt.MapFrom(c => c.Id));
        }
    }
}
