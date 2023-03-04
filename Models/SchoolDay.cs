using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class SchoolDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int? Lesson1Id { get; set; }
        public AcademicSubject Lesson1 { get; set; }
        public int? Lesson2Id { get; set; }
        public AcademicSubject Lesson2 { get; set; }
        public int? Lesson3Id { get; set; }
        public AcademicSubject Lesson3 { get; set; }
        public int? Lesson4Id { get; set; }
        public AcademicSubject Lesson4 { get; set; }
        public int? Lesson5Id { get; set; }
        public AcademicSubject Lesson5 { get; set; }
        public int? Lesson6Id { get; set; }
        public AcademicSubject Lesson6 { get; set; }
        public int? Lesson7Id { get; set; }
        public AcademicSubject Lesson7 { get; set; }
    }
}
