using School.Models;
using System.Collections.Generic;

namespace School.ViewModels
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public List<OnlyIdDTO> TeacherSubjects { get; set; }
        public List<OnlyIdDTO> TeacherClasses { get; set; }
    }
}