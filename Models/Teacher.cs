namespace School_API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ManagementPosition { get; set; }

        public Class Class { get; set; }

        public List<AcademicSubject> AcademicSubjects { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }

        public List<Class> Classes { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }
    }
}
