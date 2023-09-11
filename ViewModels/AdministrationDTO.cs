using School_API.Models;

namespace School_API.ViewModels
{
    public class AdministrationDTO
    {
        public string Position { get; set; }
        public int? TeacherId { get; set; }
        public string? FullName { get; set; }
    }
}
