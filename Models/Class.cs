using System.Collections.Generic;

namespace School.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int? ClassTeacherId { get; set; }
        public Teacher ClassTeacher { get; set; }
        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }
    }
}
