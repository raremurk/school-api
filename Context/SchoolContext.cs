using Microsoft.EntityFrameworkCore;

namespace School.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<AcademicSubject> AcademicSubjects { get; set; }

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
        }
    }
}
