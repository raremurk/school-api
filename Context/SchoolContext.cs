using Microsoft.EntityFrameworkCore;
using School_API.Models;

namespace School_API.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<AcademicSubject> AcademicSubjects { get; set; } = null!;
        public DbSet<Administration> Administration { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;

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
            var data = new Data();
            modelBuilder.Entity<AcademicSubject>().HasData(data.GetAcademicSubjects());
            modelBuilder.Entity<Administration>().HasData(data.GetAdministration());
            modelBuilder.Entity<Teacher>().HasData(data.GetTeachers());
            modelBuilder.Entity<Class>().HasData(data.GetClasses());
            modelBuilder.Entity<Student>().HasData(data.GetStudents());
            modelBuilder.Entity<Lesson>().HasData(data.GetLessons());
            modelBuilder.Entity<TeacherSubject>().HasData(data.GetTeacherSubjects());

            modelBuilder.Entity<Administration>()
                .HasOne(j => j.Teacher)
                .WithOne(j => j.Position)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Class>()
                .HasOne(j => j.ClassTeacher)
                .WithOne(j => j.Class)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Lesson>()
                .HasOne(j => j.AcademicSubject)
                .WithMany(j => j.Lessons)
                .OnDelete(DeleteBehavior.SetNull);

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
