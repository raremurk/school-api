using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.ViewModels
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Index { get; set; }
        public int ClassId { get; set; }
        public int AcademicSubjectId { get; set; }
        public string AcademicSubjectName { get; set; }
    }
}
