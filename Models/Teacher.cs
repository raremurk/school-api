﻿using System.IO;

namespace School_API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }

        public Administration Position { get; set; }
        public Class Class { get; set; }

        public List<AcademicSubject> AcademicSubjects { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }

        public List<Class> Classes { get; set; }
        public List<TeacherClass> TeacherClasses { get; set; }

        public string GetFullName() => string.Join(' ', LastName, FirstName, MiddleName);
        public string GetShortFullName() => string.Join(' ', LastName, $"{FirstName[0]}.", $"{MiddleName[0]}.");
    }
}
