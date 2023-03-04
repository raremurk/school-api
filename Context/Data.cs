using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Models;

namespace School.Context
{
    public class Data
    {
        Random rand = new Random();

        List<AcademicSubject> academicSubjects = new List<AcademicSubject>();
        List<Teacher> teachers = new List<Teacher>();
        List<Student> students = new List<Student>();
        List<Class> classes = new List<Class>();
        List<Lesson> lessons = new List<Lesson>();
        
        List<AcademicSubject> academicSubjects_filtered = new List<AcademicSubject>();

        List<TeacherSubject> teachersSubjects = new List<TeacherSubject>();
        List<TeacherClass> teachersClasses = new List<TeacherClass>();

        public List<AcademicSubject> InitializeAcademicSubjects()
        {
            academicSubjects.AddRange(new List<AcademicSubject>()
            {
                new AcademicSubject { Id = 1, Name ="Белорусский язык", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 2, Name ="Белорусская лит.", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 3, Name = "Русский язык", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 4, Name = "Русская лит.", MinClass = 1, MaxClass = 11 },                
                new AcademicSubject { Id = 5, Name = "Трудовое обучение", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 6, Name = "Черчение", MinClass = 10, MaxClass = 10 },       
                new AcademicSubject { Id = 7, Name = "Всемирная история", MinClass = 5, MaxClass = 11 },
                new AcademicSubject { Id = 8, Name = "История Беларуси", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 9, Name = "Обществоведение", MinClass = 9, MaxClass = 11 },
                new AcademicSubject { Id = 10, Name = "Информатика", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 11, Name = "Физика", MinClass = 7, MaxClass = 11 },
                new AcademicSubject { Id = 12, Name = "Астрономия", MinClass = 11, MaxClass = 11 },
                new AcademicSubject { Id = 13, Name = "Биология", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 14, Name = "Химия", MinClass = 7, MaxClass = 11 },
                new AcademicSubject { Id = 15, Name = "География", MinClass = 6, MaxClass = 11 },
                new AcademicSubject { Id = 16, Name = "Математика", MinClass = 1, MaxClass = 11 },                
                new AcademicSubject { Id = 17, Name = "Иностранный язык", MinClass = 3, MaxClass = 11 },
                new AcademicSubject { Id = 18, Name = "Физкультура", MinClass = 1, MaxClass = 11 },
                new AcademicSubject { Id = 19, Name = "ДиМП", MinClass = 10, MaxClass = 11 },
                new AcademicSubject { Id = 20, Name = "Искусство", MinClass = 5, MaxClass = 9 },
                new AcademicSubject { Id = 21, Name = "Человек и мир", MinClass = 1, MaxClass = 5 },                
                new AcademicSubject { Id = 22, Name = "Изобр. искусство", MinClass = 1, MaxClass = 4 },
                new AcademicSubject { Id = 23, Name = "Музыка", MinClass = 1, MaxClass = 4 },
                new AcademicSubject { Id = 24, Name = "ОБЖ", MinClass = 2, MaxClass = 5 }
            });

            return academicSubjects;
        }

        public List<Teacher> InitializeTeachers()
        {
            teachers.AddRange(new List<Teacher>()
            {
                new Teacher { Id = 1, FirstName = "Светлана", MiddleName = "Ивановна", LastName = "Карпенко",
                            Position = "Учитель" },
                new Teacher { Id = 2, FirstName = "Евгения", MiddleName = "Александровна", LastName = "Бондаренко",
                            Position = "Учитель" },
                new Teacher { Id = 3, FirstName = "Елена", MiddleName = "Алексеевна", LastName = "Королёва",
                            Position = "Учитель" },
                new Teacher { Id = 4, FirstName = "Мария", MiddleName = "Николаевна", LastName = "Сечко",
                            Position = "Учитель" },
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

            return teachers;
        }

        public List<Student> InitializeStudents()
        {
            students.AddRange(new List<Student>()
            {
                new Student { Id = 1, FirstName = "Александр", MiddleName = "Иванович", LastName = "Пельш",
                            Gender = "Мужской", Birthday = new DateTime(2007, 7, 15).ToString("yyyy-MM-dd"), ClassId = 1 },
                new Student { Id = 2, FirstName = "Иван", MiddleName = "Олегович", LastName = "Кролов",
                            Gender = "Мужской", Birthday = new DateTime(2005, 9, 27).ToString("yyyy-MM-dd"), ClassId = 2 },
                new Student { Id = 3, FirstName = "Игорь", MiddleName = "Петрович", LastName = "Абоба",
                            Gender = "Мужской", Birthday = new DateTime(2009, 1, 20).ToString("yyyy-MM-dd"), ClassId = 3 }

            });

            return students;
        }

        public List<Class> InitializeClasses()
        {
            for (int i = 1; i < 12; i++)
            {
                classes.Add(new Class { Id = i, ClassTeacherId = teachers[i-1].Id });
            }

            return classes;
        }

        public List<Lesson> InitializeLessons()
        {
            int id = 1;
            int max_hours;
            for (int i = 1; i <= classes.Count; i++)
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
                for (int j = 1; j <= (i < 5 ? 5 : 6); j++)
                {
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

            return lessons;
        }

        public List<TeacherSubject> InitializeTeacherSubjects()
        {
            teachersSubjects.AddRange(new List<TeacherSubject>()
            {
                new TeacherSubject { TeacherId = 1, AcademicSubjectId = 1 },
                new TeacherSubject { TeacherId = 1, AcademicSubjectId = 2 },
                new TeacherSubject { TeacherId = 2, AcademicSubjectId = 3 },
                new TeacherSubject { TeacherId = 2, AcademicSubjectId = 4 },
                new TeacherSubject { TeacherId = 9, AcademicSubjectId = 5 },
                new TeacherSubject { TeacherId = 9, AcademicSubjectId = 6 },
                new TeacherSubject { TeacherId = 9, AcademicSubjectId = 24 },
                new TeacherSubject { TeacherId = 4, AcademicSubjectId = 7 },
                new TeacherSubject { TeacherId = 4, AcademicSubjectId = 8 },
                new TeacherSubject { TeacherId = 4, AcademicSubjectId = 9 },
                new TeacherSubject { TeacherId = 5, AcademicSubjectId = 10 },
                new TeacherSubject { TeacherId = 5, AcademicSubjectId = 11 },
                new TeacherSubject { TeacherId = 5, AcademicSubjectId = 12 },
                new TeacherSubject { TeacherId = 6, AcademicSubjectId = 13 },
                new TeacherSubject { TeacherId = 6, AcademicSubjectId = 14 },
                new TeacherSubject { TeacherId = 7, AcademicSubjectId = 15 },
                new TeacherSubject { TeacherId = 8, AcademicSubjectId = 16 },
                new TeacherSubject { TeacherId = 9, AcademicSubjectId = 17 },
                new TeacherSubject { TeacherId = 10, AcademicSubjectId = 18 },
                new TeacherSubject { TeacherId = 11, AcademicSubjectId = 19 },
                new TeacherSubject { TeacherId = 12, AcademicSubjectId = 20 },
            });

            return teachersSubjects;
        }

        public List<TeacherClass> InitializeTeacherClasses()
        {
            teachersClasses.AddRange(new List<TeacherClass>()
            {
                new TeacherClass { TeacherId = 1, ClassId = 3 },
                new TeacherClass { TeacherId = 1, ClassId = 4 },
                new TeacherClass { TeacherId = 1, ClassId = 5 },
                new TeacherClass { TeacherId = 1, ClassId = 6 },
                new TeacherClass { TeacherId = 1, ClassId = 7 },
                new TeacherClass { TeacherId = 1, ClassId = 8 },
                new TeacherClass { TeacherId = 1, ClassId = 9 },
                new TeacherClass { TeacherId = 1, ClassId = 10 },
                new TeacherClass { TeacherId = 1, ClassId = 11 },
                new TeacherClass { TeacherId = 8, ClassId = 6 },
                new TeacherClass { TeacherId = 8, ClassId = 1 },
                new TeacherClass { TeacherId = 8, ClassId = 8 },
                new TeacherClass { TeacherId = 9, ClassId = 9 },
                new TeacherClass { TeacherId = 9, ClassId = 11 },
                new TeacherClass { TeacherId = 9, ClassId = 10 },
                new TeacherClass { TeacherId = 10, ClassId = 10 },
                new TeacherClass { TeacherId = 10, ClassId = 8 },
                new TeacherClass { TeacherId = 10, ClassId = 9 },
                new TeacherClass { TeacherId = 11, ClassId = 6 },
                new TeacherClass { TeacherId = 12, ClassId = 7 },
                new TeacherClass { TeacherId = 12, ClassId = 6 },
                new TeacherClass { TeacherId = 13, ClassId = 9 },
                new TeacherClass { TeacherId = 14, ClassId = 11 },
                new TeacherClass { TeacherId = 15, ClassId = 10 }
            });

            return teachersClasses;
        }
    }
}