using AutoMapper;
using School_API.Models;
using School_API.ViewModels;

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

            CreateMap<Administration, AdministrationDTO>()
                .ForMember("FullName", opt => opt.MapFrom(x => x.Teacher.GetFullName()));
            CreateMap<AdministrationDTO, Administration>();

            CreateMap<ClassDTO, Class>();
            CreateMap<Class, ClassDTO>()
                .ForMember("ClassTeacherFullName", opt => opt.MapFrom(@class => @class.ClassTeacher.GetShortFullName()));

            CreateMap<LessonDTO, Lesson>();
            CreateMap<Lesson, LessonDTO>()
                .ForMember("AcademicSubjectName", opt => opt.MapFrom(c => c.AcademicSubject.Name));

            CreateMap<Teacher, TeacherFullName>()
                .ForMember("FullName", opt => opt.MapFrom(teacher => teacher.GetFullName()))
                .ForMember("ShortFullName", opt => opt.MapFrom(teacher => teacher.GetShortFullName()));

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
