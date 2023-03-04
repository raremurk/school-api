using System;
using System.Collections.Generic;
using School.Models;

namespace School.ViewModels
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public List<OnlyIdDTO> AcademicSubjects { get; set; }
        public List<OnlyIdDTO> Classes { get; set; }
    }
}