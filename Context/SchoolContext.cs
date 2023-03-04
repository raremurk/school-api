using Microsoft.EntityFrameworkCore;
using School.Context;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=School.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Data data = new Data();

            modelBuilder.Entity<AcademicSubject>().HasData(data.InitializeAcademicSubjects());
            modelBuilder.Entity<Teacher>().HasData(data.InitializeTeachers());
            modelBuilder.Entity<Class>().HasData(data.InitializeClasses());   
            modelBuilder.Entity<Student>().HasData(data.InitializeStudents());
            modelBuilder.Entity<Lesson>().HasData(data.InitializeLessons());
            modelBuilder.Entity<TeacherSubject>().HasData(data.InitializeTeacherSubjects());
            modelBuilder.Entity<TeacherClass>().HasData(data.InitializeTeacherClasses());

            modelBuilder.Entity<Class>()
                .HasOne(j => j.ClassTeacher);        

            modelBuilder.Entity<Teacher>()                
                .HasMany(p => p.AcademicSubjects)
                .WithMany(p => p.Teachers)
                .UsingEntity<TeacherSubject>(
                    j => j
                        .HasOne(pt => pt.AcademicSubject)
                        .WithMany(t => t.TeacherSubjects)
                        .HasForeignKey(pt => pt.AcademicSubjectId),                       
                    j => j
                        .HasOne(pt => pt.Teacher)
                        .WithMany(p => p.TeacherSubjects)
                        .HasForeignKey(pt => pt.TeacherId),
                    j =>
                    {
                        j.HasKey(t => new { t.TeacherId, t.AcademicSubjectId });
                        j.ToTable("TeacherSubjects");
                    })
                .HasMany(c => c.Classes)
                .WithMany(x => x.Teachers)
                .UsingEntity<TeacherClass>(
                    j => j
                        .HasOne(pt => pt.Class)
                        .WithMany(t => t.TeacherClasses)
                        .HasForeignKey(pt => pt.ClassId),
                    j => j
                        .HasOne(pt => pt.Teacher)
                        .WithMany(p => p.TeacherClasses)
                        .HasForeignKey(pt => pt.TeacherId),
                    j =>
                    {
                        j.HasKey(t => new { t.TeacherId, t.ClassId });
                        j.ToTable("TeacherClasses");                        
                    }); 
            
        }
    }
}
  