using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public DbSet<SchoolDay> SchoolDays { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicSubject>().HasData(
                new AcademicSubject[]
                {
                new AcademicSubject { Id = 1, Name = "Белорусский язык" },
                new AcademicSubject { Id = 2, Name = "Белорусская литература" },
                new AcademicSubject { Id = 3, Name = "Русский язык" },
                new AcademicSubject { Id = 4, Name = "Русская литература" },
                new AcademicSubject { Id = 5, Name = "Иностранный язык" },
                new AcademicSubject { Id = 6, Name = "Математика" },
                new AcademicSubject { Id = 7, Name = "Информатика" },
                new AcademicSubject { Id = 8, Name = "Человек и мир" },
                new AcademicSubject { Id = 9, Name = "Всемирная история" },
                new AcademicSubject { Id = 10, Name = "История Беларуси" },
                new AcademicSubject { Id = 11, Name = "Обществоведение" },
                new AcademicSubject { Id = 12, Name = "География" },
                new AcademicSubject { Id = 13, Name = "Биология" },
                new AcademicSubject { Id = 14, Name = "Физика" },
                new AcademicSubject { Id = 15, Name = "Астрономия" },
                new AcademicSubject { Id = 16, Name = "Химия" },
                new AcademicSubject { Id = 17, Name = "Изобразительное искусство" },
                new AcademicSubject { Id = 18, Name = "Музыка" },
                new AcademicSubject { Id = 19, Name = "Трудовое обучение" },
                new AcademicSubject { Id = 20, Name = "Искусство" },
                new AcademicSubject { Id = 21, Name = "Черчение" },
                new AcademicSubject { Id = 22, Name = "Физическая культура и здоровье" },
                new AcademicSubject { Id = 23, Name = "Допризывная и медицинская подготовка" },
                new AcademicSubject { Id = 24, Name = "Основы безопасности жизнедеятельности" }

                });
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher[]
                {
                new Teacher { Id = 1, FirstName = "Иван", MiddleName = "Иванович", LastName = "Иванов",
                            Position = "Директор", AcademicSubjectId = 1},
                new Teacher { Id = 2, FirstName = "Алексей", MiddleName = "Александрович", LastName = "Глыбин",
                            Position = "Завуч", AcademicSubjectId = 2},
                new Teacher { Id = 3, FirstName = "Евгений", MiddleName = "Андреевич", LastName = "Корбут",
                            Position = "Учитель", AcademicSubjectId = 3 }
                });
            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                new Student { Id = 1, FirstName = "Александр", MiddleName = "Иванович", LastName = "Пельш",
                            Gender = "мужской", Birthday = new DateTime(2007, 7, 15).ToShortDateString(), ClassId = 1 },
                new Student { Id = 2, FirstName = "Иван", MiddleName = "Олегович", LastName = "Кролов",
                            Gender = "мужской", Birthday = new DateTime(2005, 9, 27).ToShortDateString(), ClassId = 2 },
                new Student { Id = 3, FirstName = "Игорь", MiddleName = "Петрович", LastName = "Абоба",
                            Gender = "мужской", Birthday = new DateTime(2009, 1, 20).ToShortDateString(), ClassId = 3 }
                });
            modelBuilder.Entity<Class>().HasData(
                new Class[]
                {
                new Class { Id = 1, Name = "1", ClassTeacherId = 1 },
                new Class { Id = 2, Name = "2", ClassTeacherId = 2 },
                new Class { Id = 3, Name = "3", ClassTeacherId = 2 },
                new Class { Id = 4, Name = "4", ClassTeacherId = 2 },
                new Class { Id = 5, Name = "5", ClassTeacherId = 2 },
                new Class { Id = 6, Name = "6", ClassTeacherId = 2 },
                new Class { Id = 7, Name = "7", ClassTeacherId = 2 },
                new Class { Id = 8, Name = "8", ClassTeacherId = 2 },
                new Class { Id = 9, Name = "9", ClassTeacherId = 2 },
                new Class { Id = 10, Name = "10", ClassTeacherId = 2 },
                new Class { Id = 11, Name = "11", ClassTeacherId = 3 }
                });
            modelBuilder.Entity<SchoolDay>().HasData(
                new SchoolDay[]
                {
                new SchoolDay { Id = 1, Name = "Понедельник", ClassId = 1 , Lesson1Id = 1 },
                new SchoolDay { Id = 2, Name = "Вторник", ClassId = 1 },
                new SchoolDay { Id = 3, Name = "Среда", ClassId = 1 },
                new SchoolDay { Id = 4, Name = "Четверг", ClassId = 1 },
                new SchoolDay { Id = 5, Name = "Пятница", ClassId = 1 }
                });
        }
    }
}
