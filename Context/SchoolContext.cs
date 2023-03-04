using Microsoft.EntityFrameworkCore;

namespace School.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<AcademicSubject> AcademicSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicSubject>().HasData(
                new AcademicSubject[]
                {
                new AcademicSubject { Id = 1, Name = "Математика" },
                new AcademicSubject { Id = 2, Name = "Русский язык" },
                new AcademicSubject { Id = 3, Name = "Физика" }
                });
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher[]
                {
                new Teacher { Id = 1, FirstName = "Иван", MiddleName = "Иванович", LastName = "Иванов",
                            Position = "Директор", AcademicSubjectId = 1 },
                new Teacher { Id = 2, FirstName = "Алексей", MiddleName = "Александрович", LastName = "Глыбин",
                            Position = "Завуч", AcademicSubjectId = 2 },
                new Teacher { Id = 3, FirstName = "Евгений", MiddleName = "Андреевич", LastName = "Корбут",
                            Position = "Учитель", AcademicSubjectId = 3 }
                });
        }
    }
}
