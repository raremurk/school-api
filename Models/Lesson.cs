namespace School.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Index { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int? AcademicSubjectId { get; set; }
        public AcademicSubject AcademicSubject { get; set; }
    }
}
