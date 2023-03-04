using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<AcademicSubject> AcademicSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random rand = new Random();
            List<AcademicSubject> academicSubjects = new List<AcademicSubject>();
            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>();
            List<Lesson> lessons = new List<Lesson>();
            List<Class> classes = new List<Class>();
            List<AcademicSubject> academicSubjects_filtered = new List<AcademicSubject>();

            academicSubjects.AddRange(new List<AcademicSubject>()
            {
                new AcademicSubject { Id = 1, Name = "Белорусский язык", ShortName ="Белорусский язык", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 2, Name = "Белорусская литература", ShortName ="Белорусская лит.", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 3, Name = "Русский язык", ShortName ="Русский язык", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 4, Name = "Русская литература", ShortName ="Русская лит.", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 5, Name = "Математика", ShortName ="Математика", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 6, Name = "Трудовое обучение", ShortName ="Трудовое обучение", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 7, Name = "Физическая культура и здоровье", ShortName ="Физкультура", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 8, Name = "Иностранный язык", ShortName ="Иностранный язык", MinClass = 3, MaxClass = 11 },
                new AcademicSubject { Id = 9, Name = "Всемирная история", ShortName ="Всемирная история", MinClass = 5, MaxClass = 11 },
                new AcademicSubject { Id = 10, Name = "Информатика", ShortName ="Информатика", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 11, Name = "История Беларуси", ShortName ="История Беларуси", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 12, Name = "География", ShortName ="География", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 13, Name = "Биология", ShortName ="Биология", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 14, Name = "Физика", ShortName ="Физика", MinClass = 7, MaxClass = 11 },
                new AcademicSubject { Id = 15, Name = "Химия", ShortName ="Химия", MinClass = 7, MaxClass = 11 },
                new AcademicSubject { Id = 16, Name = "Обществоведение", ShortName ="Обществоведение", MinClass = 9, MaxClass = 11 },
                new AcademicSubject { Id = 17, Name = "Черчение", ShortName ="Черчение", MinClass = 10, MaxClass = 10 },
                new AcademicSubject { Id = 18, Name = "Допризывная и медицинская подготовка", ShortName ="ДиМП", MinClass = 10, MaxClass = 11 },
                new AcademicSubject { Id = 19, Name = "Астрономия", ShortName ="Астрономия", MinClass = 11, MaxClass = 11 },
                new AcademicSubject { Id = 20, Name = "Искусство", ShortName ="Искусство", MinClass = 5, MaxClass = 9 },
                new AcademicSubject { Id = 21, Name = "Человек и мир", ShortName ="Человек и мир", MinClass = 1, MaxClass = 5 },
                new AcademicSubject { Id = 22, Name = "Основы безопасности жизнедеятельности", ShortName ="ОБЖ", MinClass = 2, MaxClass = 5 },
                new AcademicSubject { Id = 23, Name = "Изобразительное искусство", ShortName ="Изобр. искусство", MinClass = 1, MaxClass = 4 },
                new AcademicSubject { Id = 24, Name = "Музыка", ShortName ="Музыка", MinClass = 1, MaxClass = 4 },
                new AcademicSubject { Id = 25, Name = "Форточка", ShortName ="---", MinClass = 1, MaxClass = 11 }
            });

            teachers.AddRange(new List<Teacher>()
            {
                new Teacher { Id = 1, FirstName = "Светлана", MiddleName = "Ивановна", LastName = "Карпенко",
                            Position = "Учитель младших классов" },
                new Teacher { Id = 2, FirstName = "Евгения", MiddleName = "Александровна", LastName = "Бондаренко",
                            Position = "Учитель младших классов" },
                new Teacher { Id = 3, FirstName = "Елена", MiddleName = "Алексеевна", LastName = "Королёва",
                            Position = "Учитель младших классов" },
                new Teacher { Id = 4, FirstName = "Мария", MiddleName = "Николаевна", LastName = "Сечко",
                            Position = "Учитель младших классов" },
                new Teacher { Id = 5, FirstName = "Светлана", MiddleName = "Павловна", LastName = "Мурашко",
                            Position = "Учитель" },
                new Teacher { Id = 6, FirstName = "Кирилл", MiddleName = "Александрович", LastName = "Жилинский",
                            Position = "Учитель" },
                new Teacher { Id = 7, FirstName = "Карина", MiddleName = "Артемовна", LastName = "Смирнова",
                            Position = "Учитель" },
                new Teacher { Id = 8, FirstName = "Дарья", MiddleName = "Даниловна", LastName = "Савицкая",
                            Position = "Учитель" },
                new Teacher { Id = 9, FirstName = "Денис", MiddleName = "Николаевич", LastName = "Марченко",
                            Position = "Учитель" },
                new Teacher { Id = 10, FirstName = "Юлия", MiddleName = "Степановна", LastName = "Нестерович",
                            Position = "Учитель" },
                new Teacher { Id = 11, FirstName = "Евгений", MiddleName = "Леонидович", LastName = "Солонович",
                            Position = "Учитель" },
                new Teacher { Id = 12, FirstName = "Ирина", MiddleName = "Викторовна", LastName = "Станкевич",
                            Position = "Учитель" },
                new Teacher { Id = 13, FirstName = "Ярослав", MiddleName = "Иванович", LastName = "Кравченко",
                            Position = "Учитель" },
                new Teacher { Id = 14, FirstName = "Татьяна", MiddleName = "Федоровна", LastName = "Тарасевич",
                            Position = "Учитель" },
                new Teacher { Id = 15, FirstName = "Полина", MiddleName = "Мефодьевна", LastName = "Василевская",
                            Position = "Учитель" },
                new Teacher { Id = 16, FirstName = "Наталья", MiddleName = "Михайловна", LastName = "Пинчук",
                            Position = "Учитель" },
                new Teacher { Id = 17, FirstName = "Елизавета", MiddleName = "Ефстафьевна", LastName = "Старовойтова",
                            Position = "Завуч" },
                new Teacher { Id = 18, FirstName = "Иван", MiddleName = "Ксенофонтович", LastName = "Касперович",
                            Position = "Директор" }
            });

            students.AddRange(new List<Student>()
            {
                new Student { Id = 1, FirstName = "Александр", MiddleName = "Иванович", LastName = "Пельш",
                            Gender = "мужской", Birthday = new DateTime(2007, 7, 15).ToShortDateString(), ClassId = 1 },
                new Student { Id = 2, FirstName = "Иван", MiddleName = "Олегович", LastName = "Кролов",
                            Gender = "мужской", Birthday = new DateTime(2005, 9, 27).ToShortDateString(), ClassId = 2 },
                new Student { Id = 3, FirstName = "Игорь", MiddleName = "Петрович", LastName = "Абоба",
                            Gender = "мужской", Birthday = new DateTime(2009, 1, 20).ToShortDateString(), ClassId = 3 }

            });  
            
            for (int i = 1; i < 12; i++)
            {
                classes.Add(new Class { Id = i, ClassTeacherId = teachers[rand.Next(0, teachers.Count)].Id });
            }

            int id = 1;
            int max_hours;            
            for (int i = 1; i <= classes.Count; i++)
            {
                for (int j = 1; j <= (i < 5 ? 5 : 6); j++)
                {
                    if (i == 1)
                    {
                        max_hours = 4;
                    }
                    else if (i > 1 & i < 5)
                    {
                        max_hours = 5;
                    }
                    else if (i > 4 & i < 7)
                    {
                        max_hours = 6;
                    }
                    else
                    {
                        max_hours = 7;
                    }
                    academicSubjects_filtered = academicSubjects.Where(p => p.MinClass <= i && p.MaxClass >= i).ToList();
                    for (int k = 1; k <= max_hours; k++)
                    {
                        Lesson lesson = new Lesson();
                        lesson.Id = id;
                        lesson.Index = k;
                        lesson.Day = j;
                        lesson.ClassId = i;
                        lesson.AcademicSubjectId = academicSubjects_filtered[rand.Next(0, academicSubjects_filtered.Count)].Id;
                        lessons.Add(lesson);
                        id++;
                    }
                }
            };

            modelBuilder.Entity<AcademicSubject>()
                .HasMany(c => c.Teachers)
                .WithMany(s => s.AcademicSubjects)
                .UsingEntity(j => j.ToTable("SubjectsDistribution"))
                .HasData(academicSubjects);

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.AcademicSubjects)
                .WithMany(s => s.Teachers)
                .UsingEntity(j => j.ToTable("SubjectsDistribution"))
                .HasData(teachers);

            modelBuilder.Entity<Student>().HasData(students);

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Teachers)
                .WithMany(s => s.Classes)
                .UsingEntity(j => j.ToTable("ClassesDistribution"))
                .HasOne(p => p.ClassTeacher)
                .WithOne(x => x.Class);                   

            modelBuilder.Entity<Class>().HasData(classes);

            modelBuilder.Entity<Lesson>().HasData(lessons);
        }
    }
}
