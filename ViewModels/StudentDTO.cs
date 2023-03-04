using System.Collections.Generic;

namespace School.ViewModels
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }
}