using School_API.Models;

namespace School_API.Context
{
    public class Data
    {
        private List<AcademicSubject> academicSubjects = new()
        {
            new AcademicSubject { Name = "Трудовое обучение", MinClass = 1, MaxClass = 11 },
            new AcademicSubject { Name = "Черчение", MinClass = 10, MaxClass = 10 },
            new AcademicSubject { Name = "ОБЖ", MinClass = 2, MaxClass = 5 },
            new AcademicSubject { Name = "ДиМП", MinClass = 10, MaxClass = 11 },
            new AcademicSubject { Name = "Всемирная история", MinClass = 5, MaxClass = 11 },
            new AcademicSubject { Name = "История Беларуси", MinClass = 6, MaxClass = 11 },
            new AcademicSubject { Name = "Обществоведение", MinClass = 9, MaxClass = 11 },
            new AcademicSubject { Name = "Русский язык", MinClass = 1, MaxClass = 11 },
            new AcademicSubject { Name = "Русская лит.", MinClass = 1, MaxClass = 11 },
            new AcademicSubject { Name = "Белорусский язык", MinClass = 1, MaxClass = 11 },
            new AcademicSubject { Name = "Белорусская лит.", MinClass = 1, MaxClass = 11 },
            new AcademicSubject { Name = "Информатика", MinClass = 6, MaxClass = 11 },
            new AcademicSubject { Name = "Физика", MinClass = 7, MaxClass = 11 },
            new AcademicSubject { Name = "Астрономия", MinClass = 11, MaxClass = 11 },
            new AcademicSubject { Name = "Биология", MinClass = 6, MaxClass = 11 },
            new AcademicSubject { Name = "Химия", MinClass = 7, MaxClass = 11 },
            new AcademicSubject { Name = "Человек и мир", MinClass = 1, MaxClass = 5 },
            new AcademicSubject { Name = "География", MinClass = 6, MaxClass = 11 },
            new AcademicSubject { Name = "Математика", MinClass = 1, MaxClass = 11 },
            new AcademicSubject { Name = "Иностранный язык", MinClass = 3, MaxClass = 11 },
            new AcademicSubject { Name = "Физкультура", MinClass = 1, MaxClass = 11 },            
            new AcademicSubject { Name = "Искусство", MinClass = 5, MaxClass = 9 },
            new AcademicSubject { Name = "Изобр. искусство", MinClass = 1, MaxClass = 4 },
            new AcademicSubject { Name = "Музыка", MinClass = 1, MaxClass = 4 }           
        };

        private List<Administration> administration = new()
        {
            new Administration { Position = "Директор", TeacherId = 15 },
            new Administration { Position = "Завуч", TeacherId = 16 }          
        };

        private List<Teacher> teachers = new()
        {
            new Teacher { FirstName = "Светлана", MiddleName = "Ивановна", LastName = "Карпенко", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Евгения", MiddleName = "Александровна", LastName = "Бондаренко", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Юлия", MiddleName = "Степановна", LastName = "Нестерович", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Ярослав", MiddleName = "Иванович", LastName = "Кравченко", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Елена", MiddleName = "Алексеевна", LastName = "Королёва", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Евгений", MiddleName = "Леонидович", LastName = "Солонович", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Мария", MiddleName = "Николаевна", LastName = "Сечко", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Светлана", MiddleName = "Павловна", LastName = "Мурашко", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Карина", MiddleName = "Артемовна", LastName = "Смирнова", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Дарья", MiddleName = "Даниловна", LastName = "Савицкая", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Татьяна", MiddleName = "Федоровна", LastName = "Тарасевич", Specialization = "Учитель начальных классов" },
            new Teacher { FirstName = "Полина", MiddleName = "Мефодьевна", LastName = "Василевская", Specialization = "Учитель начальных классов" },
            new Teacher { FirstName = "Наталья", MiddleName = "Михайловна", LastName = "Пинчук", Specialization = "Учитель начальных классов" },
            new Teacher { FirstName = "Елизавета", MiddleName = "Ефстафьевна", LastName = "Старовойтова", Specialization = "Учитель начальных классов" },
            new Teacher { FirstName = "Иван", MiddleName = "Ксенофонтович", LastName = "Касперович", Specialization = "Учитель старших классов" },
            new Teacher { FirstName = "Ирина", MiddleName = "Викторовна", LastName = "Станкевич", Specialization = "Учитель старших классов" }
        };

        private List<Student> students = new()
        {
            new Student { FirstName = "Юлия", MiddleName = "Анатольевна", LastName = "Салей", Gender = "W" },
            new Student { FirstName = "Елизавета", MiddleName = "Валентиновна", LastName = "Хацкевич", Gender = "W" },
            new Student { FirstName = "Арсений", MiddleName = "Кириллович", LastName = "Волков", Gender = "M" },
            new Student { FirstName = "Ирина", MiddleName = "Викторовна", LastName = "Колесникова", Gender = "W" },
            new Student { FirstName = "Диана", MiddleName = "Андреевна", LastName = "Тарасова", Gender = "W" },
            new Student { FirstName = "Павел", MiddleName = "Артемович", LastName = "Васильев", Gender = "M" },
            new Student { FirstName = "Владислав", MiddleName = "Борисович", LastName = "Петров", Gender = "M" },
            new Student { FirstName = "Виталий", MiddleName = "Матвеевич", LastName = "Новиков", Gender = "M" },
            new Student { FirstName = "Елена", MiddleName = "Михайловна", LastName = "Юрченко", Gender = "W" },
            new Student { FirstName = "Карина", MiddleName = "Ивановна", LastName = "Новикова", Gender = "W" },
            new Student { FirstName = "Александра", MiddleName = "Георгиевна", LastName = "Климович", Gender = "W" },
            new Student { FirstName = "Дмитрий", MiddleName = "Борисович", LastName = "Романовский", Gender = "M" },
            new Student { FirstName = "Олег", MiddleName = "Леонидович", LastName = "Дробышевский", Gender = "M" },
            new Student { FirstName = "Семен", MiddleName = "Давыдович", LastName = "Петров", Gender = "M" },
            new Student { FirstName = "Яна", MiddleName = "Валериевна", LastName = "Новикова", Gender = "W" },
            new Student { FirstName = "Эдуард", MiddleName = "Анатольевич", LastName = "Гапоненко", Gender = "M" },
            new Student { FirstName = "Борис", MiddleName = "Афанасьевич", LastName = "Карпович", Gender = "M" },
            new Student { FirstName = "Наталья", MiddleName = "Геннадиевна", LastName = "Лукашевич", Gender = "W" },
            new Student { FirstName = "Алексей", MiddleName = "Назарович", LastName = "Лисовский", Gender = "M" },
            new Student { FirstName = "Филипп", MiddleName = "Яковлевич", LastName = "Савченко", Gender = "M" },
            new Student { FirstName = "Евгения", MiddleName = "Федоровна", LastName = "Сенько", Gender = "W" },
            new Student { FirstName = "Ольга", MiddleName = "Сергеевна", LastName = "Зайцева", Gender = "W" },
            new Student { FirstName = "Юрий", MiddleName = "Платонович", LastName = "Павлов", Gender = "M" },
            new Student { FirstName = "Ангелина", MiddleName = "Эдуардовна", LastName = "Орлова", Gender = "W" },
            new Student { FirstName = "Константин", MiddleName = "Родионович", LastName = "Петров", Gender = "M" },
            new Student { FirstName = "Александр", MiddleName = "Назарович", LastName = "Миронов", Gender = "M" },
            new Student { FirstName = "Олег", MiddleName = "Михайлович", LastName = "Коваленко", Gender = "M" },
            new Student { FirstName = "Ольга", MiddleName = "Глебовна", LastName = "Кулешова", Gender = "W" },
            new Student { FirstName = "Филипп", MiddleName = "Макарович", LastName = "Василенко", Gender = "M" },
            new Student { FirstName = "Руслан", MiddleName = "Борисович", LastName = "Вашкевич", Gender = "M" },
            new Student { FirstName = "Анастасия", MiddleName = "Давыдовна", LastName = "Денисенко", Gender = "W" },
            new Student { FirstName = "Давид", MiddleName = "Васильевич", LastName = "Белый", Gender = "M" },
            new Student { FirstName = "Ирина", MiddleName = "Андреевна", LastName = "Климович", Gender = "W" },
            new Student { FirstName = "Богдан", MiddleName = "Витальевич", LastName = "Волков", Gender = "M" },
            new Student { FirstName = "Светлана", MiddleName = "Евгеньевна", LastName = "Барановская", Gender = "W" },
            new Student { FirstName = "Александра", MiddleName = "Ефимовна", LastName = "Кузнецова", Gender = "W" },
            new Student { FirstName = "Евгения", MiddleName = "Матвеевна", LastName = "Медведева", Gender = "W" },
            new Student { FirstName = "Егор", MiddleName = "Георгиевич", LastName = "Якимович", Gender = "M" },
            new Student { FirstName = "Светлана", MiddleName = "Борисовна", LastName = "Медведева", Gender = "W" },
            new Student { FirstName = "Анна", MiddleName = "Егоровна", LastName = "Михайлова", Gender = "W" },
            new Student { FirstName = "Денис", MiddleName = "Константинович", LastName = "Петров", Gender = "M" },
            new Student { FirstName = "Яна", MiddleName = "Вадимовна", LastName = "Федорова", Gender = "W" },
            new Student { FirstName = "Денис", MiddleName = "Андреевич", LastName = "Бельский", Gender = "M" },
            new Student { FirstName = "Назар", MiddleName = "Борисович", LastName = "Макаревич", Gender = "M" },
            new Student { FirstName = "Николай", MiddleName = "Родионович", LastName = "Матусевич", Gender = "M" },
            new Student { FirstName = "Максим", MiddleName = "Наумович", LastName = "Казак", Gender = "M" },
            new Student { FirstName = "Александра", MiddleName = "Тимофеевна", LastName = "Борисюк", Gender = "W" },
            new Student { FirstName = "Яна", MiddleName = "Юрьевна", LastName = "Шевченко", Gender = "W" },
            new Student { FirstName = "Екатерина", MiddleName = "Яковлевна", LastName = "Гулевич", Gender = "W" },
            new Student { FirstName = "Артур", MiddleName = "Савельевич", LastName = "Петровский", Gender = "M" },
            new Student { FirstName = "Карина", MiddleName = "Олеговна", LastName = "Солонович", Gender = "W" },
            new Student { FirstName = "Татьяна", MiddleName = "Глебовна", LastName = "Шаповал", Gender = "W" },
            new Student { FirstName = "Дарья", MiddleName = "Ивановна", LastName = "Тарасова", Gender = "W" },
            new Student { FirstName = "Денис", MiddleName = "Егорович", LastName = "Селезнёв", Gender = "M" },
            new Student { FirstName = "Ольга", MiddleName = "Анатольевна", LastName = "Хомич", Gender = "W" },
            new Student { FirstName = "Ярослав", MiddleName = "Вадимович", LastName = "Юрченко", Gender = "M" },
            new Student { FirstName = "Эдуард", MiddleName = "Денисович", LastName = "Кузьменков", Gender = "M" },
            new Student { FirstName = "Ангелина", MiddleName = "Геннадиевна", LastName = "Ковалевич", Gender = "W" },
            new Student { FirstName = "Матвей", MiddleName = "Артемович", LastName = "Кравченко", Gender = "M" },
            new Student { FirstName = "Захар", MiddleName = "Леонидович", LastName = "Юркевич", Gender = "M" },
            new Student { FirstName = "Максим", MiddleName = "Дмитриевич", LastName = "Боричевский", Gender = "M" },
            new Student { FirstName = "Иван", MiddleName = "Константинович", LastName = "Новицкий", Gender = "M" },
            new Student { FirstName = "Александра", MiddleName = "Давыдовна", LastName = "Ковалёва", Gender = "W" },
            new Student { FirstName = "Игорь", MiddleName = "Александрович", LastName = "Савицкий", Gender = "M" },
            new Student { FirstName = "Анатолий", MiddleName = "Андреевич", LastName = "Новик", Gender = "M" },
            new Student { FirstName = "Николай", MiddleName = "Витальевич", LastName = "Смирнов", Gender = "M" },
            new Student { FirstName = "Илья", MiddleName = "Вадимович", LastName = "Мартинович", Gender = "M" },
            new Student { FirstName = "Илья", MiddleName = "Богданович", LastName = "Кравцов", Gender = "M" },
            new Student { FirstName = "Виталий", MiddleName = "Леонидович", LastName = "Богданов", Gender = "M" },
            new Student { FirstName = "Глеб", MiddleName = "Маркович", LastName = "Андреюк", Gender = "M" },
            new Student { FirstName = "Вячеслав", MiddleName = "Митрофанович", LastName = "Барановский", Gender = "M" },
            new Student { FirstName = "Елена", MiddleName = "Назаровна", LastName = "Колб", Gender = "W" },
            new Student { FirstName = "Антон", MiddleName = "Сергеевич", LastName = "Давидович", Gender = "M" },
            new Student { FirstName = "Артур", MiddleName = "Андреевич", LastName = "Семенов", Gender = "M" },
            new Student { FirstName = "Виталий", MiddleName = "Данилович", LastName = "Шаповал", Gender = "M" },
            new Student { FirstName = "Матвей", MiddleName = "Константинович", LastName = "Семенов", Gender = "M" },
            new Student { FirstName = "Екатерина", MiddleName = "Глебовна", LastName = "Цыбулько", Gender = "W" },
            new Student { FirstName = "Дмитрий", MiddleName = "Михайлович", LastName = "Сахарчук", Gender = "M" },
            new Student { FirstName = "Федор", MiddleName = "Эдуардович", LastName = "Шишло", Gender = "M" },
            new Student { FirstName = "Тимур", MiddleName = "Романович", LastName = "Зуев", Gender = "M" },
            new Student { FirstName = "Матвей", MiddleName = "Николаевич", LastName = "Романовский", Gender = "M" },
            new Student { FirstName = "Анастасия", MiddleName = "Олеговна", LastName = "Романов", Gender = "W" },
            new Student { FirstName = "Валерия", MiddleName = "Степановна", LastName = "Юрченко", Gender = "W" },
            new Student { FirstName = "Надежда", MiddleName = "Федоровна", LastName = "Гавриленко", Gender = "W" },
            new Student { FirstName = "Роман", MiddleName = "Петрович", LastName = "Новик", Gender = "M" },
            new Student { FirstName = "Надежда", MiddleName = "Ивановна", LastName = "Прудникова", Gender = "W" },
            new Student { FirstName = "Ангелина", MiddleName = "Максимовна", LastName = "Приходько", Gender = "W" },
            new Student { FirstName = "Анастасия", MiddleName = "Михайловна", LastName = "Мацкевич", Gender = "W" },
            new Student { FirstName = "Наталья", MiddleName = "Владимировна", LastName = "Дубовик", Gender = "W" },
            new Student { FirstName = "Павел", MiddleName = "Леонидович", LastName = "Король", Gender = "M" },
            new Student { FirstName = "Анастасия", MiddleName = "Константиновна", LastName = "Морозова", Gender = "W" },
            new Student { FirstName = "Карина", MiddleName = "Вадимовна", LastName = "Макаренко", Gender = "W" },
            new Student { FirstName = "Диана", MiddleName = "Андреевна", LastName = "Савицкая", Gender = "W" },
            new Student { FirstName = "Елизавета", MiddleName = "Артемовна", LastName = "Гончарова", Gender = "W" },
            new Student { FirstName = "Сергей", MiddleName = "Владимирович", LastName = "Марченко", Gender = "M" },
            new Student { FirstName = "Полина", MiddleName = "Вячеславовна", LastName = "Климович", Gender = "W" },
            new Student { FirstName = "Юрий", MiddleName = "Денисович", LastName = "Мартинович", Gender = "M" },
            new Student { FirstName = "Филипп", MiddleName = "Родионович", LastName = "Ковалёв", Gender = "M" },
            new Student { FirstName = "Юлия", MiddleName = "Николаевна", LastName = "Павловский", Gender = "W" },
            new Student { FirstName = "Василий", MiddleName = "Михайлович", LastName = "Булыга", Gender = "M" },
            new Student { FirstName = "Анастасия", MiddleName = "Григорьевна", LastName = "Павлович", Gender = "W" },
            new Student { FirstName = "Ангелина", MiddleName = "Александровна", LastName = "Радевич", Gender = "W" },
            new Student { FirstName = "Богдан", MiddleName = "Вадимович", LastName = "Гузаревич", Gender = "M" },
            new Student { FirstName = "Кирилл", MiddleName = "Валентинович", LastName = "Кравчук", Gender = "M" },
            new Student { FirstName = "Владимир", MiddleName = "Денисович", LastName = "Шпаковский", Gender = "M" },
            new Student { FirstName = "Анатолий", MiddleName = "Максимович", LastName = "Михайлов", Gender = "M" },
            new Student { FirstName = "Вячеслав", MiddleName = "Эдуардович", LastName = "Иванов", Gender = "M" },
            new Student { FirstName = "Екатерина", MiddleName = "Федоровна", LastName = "Соловьёва", Gender = "W" },
            new Student { FirstName = "Анастасия", MiddleName = "Николаевна", LastName = "Бурак", Gender = "W" },
            new Student { FirstName = "Ирина", MiddleName = "Глебовна", LastName = "Морозова", Gender = "W" }

        };

        private List<TeacherSubject> teachersSubjects = new()
        { 
            new TeacherSubject { TeacherId = 1, AcademicSubjectId = 8 },
            new TeacherSubject { TeacherId = 1, AcademicSubjectId = 9 },
            new TeacherSubject { TeacherId = 2, AcademicSubjectId = 10 },
            new TeacherSubject { TeacherId = 2, AcademicSubjectId = 11 },
            new TeacherSubject { TeacherId = 3, AcademicSubjectId = 5 },
            new TeacherSubject { TeacherId = 3, AcademicSubjectId = 6 },
            new TeacherSubject { TeacherId = 3, AcademicSubjectId = 7 },
            new TeacherSubject { TeacherId = 4, AcademicSubjectId = 1 },
            new TeacherSubject { TeacherId = 4, AcademicSubjectId = 2 },
            new TeacherSubject { TeacherId = 4, AcademicSubjectId = 3 },
            new TeacherSubject { TeacherId = 4, AcademicSubjectId = 4 },
            new TeacherSubject { TeacherId = 5, AcademicSubjectId = 15 },
            new TeacherSubject { TeacherId = 5, AcademicSubjectId = 16 },
            new TeacherSubject { TeacherId = 6, AcademicSubjectId = 12 },
            new TeacherSubject { TeacherId = 6, AcademicSubjectId = 13 },
            new TeacherSubject { TeacherId = 6, AcademicSubjectId = 14 },
            new TeacherSubject { TeacherId = 7, AcademicSubjectId = 17 },
            new TeacherSubject { TeacherId = 7, AcademicSubjectId = 18 },
            new TeacherSubject { TeacherId = 8, AcademicSubjectId = 19 },
            new TeacherSubject { TeacherId = 9, AcademicSubjectId = 20 },
            new TeacherSubject { TeacherId = 10, AcademicSubjectId = 21 },
            new TeacherSubject { TeacherId = 16, AcademicSubjectId = 22 },
        };

        private List<Class> classes = new();

        public List<Administration> GetAdministration()
        {
            return administration;
        }

        public List<AcademicSubject> GetAcademicSubjects()
        {
            for (int i = 0; i < academicSubjects.Count; i++)
            {
                academicSubjects[i].Id = i + 1;
            }

            return academicSubjects;
        }

        public List<Teacher> GetTeachers()
        {
            for (int i = 0; i < teachers.Count; i++)
            {
                teachers[i].Id = i + 1;
            }

            return teachers;
        }

        public List<Student> GetStudents()
        {
            for (int i = 0; i < students.Count; i++)
            {
                int classId = i / 10 + 1;
                var start = new DateTime(DateTime.Today.Year - 7 - classId, 08, 31);
                students[i].Id = i + 1;
                students[i].Birthday = start.AddDays(Random.Shared.Next(366)).ToString("yyyy-MM-dd");
                students[i].ClassId = classId;
            }
            return students;
        }

        public List<Class> GetClasses()
        {
            for (int i = 1; i <= 11; i++)
            {
                classes.Add(new Class { Id = i, ClassTeacherId = teachers[i - 1].Id });
            }

            return classes;
        }

        public IEnumerable<Lesson> GetLessons()
        {
            int id = 1;
            for (int classId = 1; classId <= classes.Count; classId++)
            {
                var academicSubjects_filtered = academicSubjects.Where(p => p.MinClass <= classId && p.MaxClass >= classId).ToList();
                int max_hours = classId switch
                {
                    1 => 4,
                    2 or 3 or 4 => 5,
                    5 or 6 => 6,
                    _ => 7
                };

                for (int day = 1; day <= (classId < 5 ? 5 : 6); day++)
                {
                    for (int hour = 1; hour <= max_hours; hour++)
                    {
                        yield return new Lesson
                        {
                            Id = id++,
                            Index = hour,
                            Day = day,
                            ClassId = classId,
                            AcademicSubjectId = academicSubjects_filtered[Random.Shared.Next(academicSubjects_filtered.Count)].Id
                        };
                    }
                }
            };
        }

        public List<TeacherSubject> GetTeacherSubjects() => teachersSubjects;
    }
}
