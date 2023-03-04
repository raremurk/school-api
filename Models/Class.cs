using System.Collections.Generic;

namespace School.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClassTeacherId { get; set; }
        public Teacher ClassTeacher { get; set; }        
        public List<Student> Students { get; set; } = new List<Student>();
        public List<SchoolDay> SchoolDays { get; set; } = new List<SchoolDay>();
    }
}
