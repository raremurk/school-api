﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class AcademicSubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }        
        public int? MinClass { get; set; }
        public int? MaxClass { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }        
    }
}
