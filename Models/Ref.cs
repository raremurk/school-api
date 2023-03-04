namespace School.Models
{
    public class Ref
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}