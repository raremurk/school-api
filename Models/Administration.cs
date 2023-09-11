using System.ComponentModel.DataAnnotations;

namespace School_API.Models
{
    public class Administration
    {
        [Key]
        public string Position { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
