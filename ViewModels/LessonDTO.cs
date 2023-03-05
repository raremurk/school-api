namespace School_API.ViewModels
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Index { get; set; }
        public int ClassId { get; set; }
        public int? AcademicSubjectId { get; set; }
        public string AcademicSubjectName { get; set; }
    }
}
