using System;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public string Birthday { get; set; }
        public int? ClassId { get; set; }
        public Class Class { get; set; }
    }
}