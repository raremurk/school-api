using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int? Day { get; set; }
        public int? Index { get; set; }
        public int ClassId { get; set; }
        public int? AcademicSubjectId { get; set; }
        public AcademicSubject AcademicSubject { get; set; }
    }
}
