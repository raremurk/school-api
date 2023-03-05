namespace School_API.ViewModels
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public int? ClassId { get; set; }
    }
}