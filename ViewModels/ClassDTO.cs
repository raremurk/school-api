namespace School_API.ViewModels
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public int? ClassTeacherId { get; set; }
        public string ClassTeacherFullName { get; set; }
    }
}