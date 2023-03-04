using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class TeacherSubject
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int AcademicSubjectId { get; set; }
        public AcademicSubject AcademicSubject { get; set; }
    }
}
