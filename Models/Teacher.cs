using System.Collections.Generic;

namespace School.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int? AcademicSubjectId { get; set; }
        public AcademicSubject AcademicSubject { get; set; }
    }
}