using Microsoft.EntityFrameworkCore;
using School.Models;
using System;

namespace School.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<AcademicSubject> AcademicSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Classes)
                .WithMany(s => s.Teachers)
                .UsingEntity(j => j.ToTable("Relations"));

            modelBuilder.Entity<Class>()                
                .HasMany(c => c.Teachers)
                .WithMany(s => s.Classes)
                .UsingEntity(j => j.ToTable("Relations"))
                .HasOne(s => s.ClassTeacher);

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
                            Position = "Директор"},
                new Teacher { Id = 2, FirstName = "Алексей", MiddleName = "Александрович", LastName = "Глыбин",
                            Position = "Завуч"},
                new Teacher { Id = 3, FirstName = "Евгений", MiddleName = "Андреевич", LastName = "Корбут",
                            Position = "Учитель" }
                });
            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                new Student { Id = 1, FirstName = "Александр", MiddleName = "Иванович", LastName = "Пельш",
                            Gender = "мужской", Birthday = new DateTime(2007, 7, 15).ToShortDateString() },
                new Student { Id = 2, FirstName = "Иван", MiddleName = "Олегович", LastName = "Кролов",
                            Gender = "мужской", Birthday = new DateTime(2005, 9, 27).ToShortDateString() },
                new Student { Id = 3, FirstName = "Игорь", MiddleName = "Петрович", LastName = "Абоба",
                            Gender = "мужской", Birthday = new DateTime(2009, 1, 20).ToShortDateString() }
                });
            modelBuilder.Entity<Class>().HasData(
                new Class[]
                {
                new Class { Id = 1, Name = "9" },
                new Class { Id = 2, Name = "10А" },
                new Class { Id = 3, Name = "11" }
                });
        }
    }
}
