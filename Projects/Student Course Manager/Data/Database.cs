using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Student_Course_Manager.Data
{
    public class Database
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();
        List<Enrollment> enrollments = new List<Enrollment>();
        private readonly string studentsJsonFile = "Students.json";
        private readonly string coursesJsonFile = "Courses.json";
        private readonly string enrollmentsJsonFile = "Enrollments.json";
        int _nextStudentId = 1;
        int _nextCourseId = 1;
        int _nextEnrollmentId = 1;

        
        public void SeedData()
        {
            students.Add(new Student(1, "Иван", "Петров", 20, "ivan@mail.ru"));
            students.Add(new Student(2, "Мария", "Сидорова", 22, "maria@mail.ru"));
            students.Add(new Student(3, "Алексей", "Иванов", 19, null));
            students.Add(new Student(4, "Екатерина", "Смирнова", 21, "ekaterina@mail.ru"));

            courses.Add(new Course(1, "Математика", 4));
            courses.Add(new Course(2, "Программирование на C#", 5));
            courses.Add(new Course(3, "Базы данных", 3));
            courses.Add(new Course(4, "Английский язык", 2));
            
            var date = DateTime.Now;
            enrollments.Add(new Enrollment(1, 1, 2, date, 85.5));
            enrollments.Add(new Enrollment(2, 1, 3, date, 90.0));
            enrollments.Add(new Enrollment(3, 2, 1, date, 75.0));
            enrollments.Add(new Enrollment(4, 2, 2, date, 92.5));
            enrollments.Add(new Enrollment(5, 3, 3, date, null));
            enrollments.Add(new Enrollment(6, 4, 2, date, 88.0));
            enrollments.Add(new Enrollment(7, 4, 4, date, 95.0));
            
        }
        public void PrintAllStudents()
        {
            
            if (students.Count == 0)
            {
                Console.WriteLine("Студентов нет");
            }
            else
            {
                Console.WriteLine("------ СТУДЕНТЫ ------");
                foreach(var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
        public void PrintAllCourses()
        {

            if (courses == null)
            {
                Console.WriteLine("Курсов нет");
            }
            else
            {
                Console.WriteLine("------ КУРСЫ ------");
                foreach (var course in courses)
                {
                    Console.WriteLine(course);
                }
            }
        }
        public void AddStudent()
        {
            Console.Write("Введите имя: ");
            string firstname = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string lastname = Console.ReadLine();

            Console.Write("Введите возраст: ");
            string ageParse = Console.ReadLine();

            
            if (!Int32.TryParse(ageParse, out int age))
            {
                Console.WriteLine("Ошибка: неверный формат возраста");
                return; 
            }

            Console.Write("Введите email: ");
            string email = Console.ReadLine();

            int freeId = _nextStudentId;

            while(students.Any(x => x.Id == freeId))
            {
                freeId++;
            }
            _nextStudentId = freeId;

            Student newStudent = new Student(_nextStudentId, firstname, lastname, age, email);
            students.Add(newStudent);
            SaveStudents();
        }
        public void AddCourse()
        {
            Console.Write("Введите название: ");
            string Name = Console.ReadLine();
            
            Console.Write("Введите кредиты: ");
            string creditParse = Console.ReadLine();
            if (!Int32.TryParse(creditParse, out int credit))
            {
                Console.WriteLine("Ошибка: неверный формат ввода");
                return;
            }
                

            int FreeId = _nextCourseId;
            
            while(courses.Any(p => p.Id == FreeId))
            {
                FreeId++;
            }

            _nextCourseId = FreeId;
            courses.Add(new Course(_nextCourseId, Name, credit));
            SaveCourses();
        }


        public void EnrollStudent()
        {
            Console.Write("Введите id студента: ");
            string studentIdParse = Console.ReadLine();
            if (!Int32.TryParse(studentIdParse, out int studentId))
            {
                Console.WriteLine("Неверный формат ввода");
                return;
            }
                
            var student = students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                Console.WriteLine($"Студент с ID {studentId} не найден!");
                Console.WriteLine("Доступные студенты:");
                foreach (var s in students)
                    Console.WriteLine($"  {s}");
                return;
            }

            Console.Write("Введите id курса: ");
            string courseIdParse = Console.ReadLine();
            if (!Int32.TryParse(courseIdParse, out int courseId))
                Console.WriteLine("Неверный формат ввода");
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine($"Курс с таким ID не найден!");
                Console.WriteLine("Доступные курсы:");
                foreach (var c in courses)
                    Console.WriteLine($"  {c}");
                return;
            }

            bool alreadyEnrolled = enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
            if (alreadyEnrolled)
            {
                Console.WriteLine($"Студент {student.FirstName} {student.LastName} уже записан на курс '{course.Name}'!");
                return;
            }

            int freeId = _nextEnrollmentId;
            while(enrollments.Any(e => e.Id == freeId))
            {
                freeId++;
            }
            _nextEnrollmentId = freeId;
            DateTime date = DateTime.Now;

            Console.Write("Введите оценку: ");
            string grade = Console.ReadLine();
            if (!Double.TryParse(grade, out double Grade))
                Console.WriteLine("Неверный формат ввода");

            enrollments.Add(new Enrollment(_nextEnrollmentId, studentId, courseId, date, Grade));
            SaveEnrollments();

        }
        public void PrintEnrollmentsWithDetails()
        {
            Console.WriteLine("=== ВСЕ ЗАПИСИ ===");

            if (enrollments == null || !enrollments.Any())
            {
                Console.WriteLine("Нет записей для отображения.");
                return;
            }

            foreach (var enrollment in enrollments)
            {
                var student = students.FirstOrDefault(s => s.Id == enrollment.StudentId);
                var course = courses.FirstOrDefault(c => c.Id == enrollment.CourseId);

                if (student == null || course == null)
                    continue;

                if (enrollment.Grade.HasValue)
                    Console.WriteLine($"{student.FirstName} {student.LastName} -> {course.Name}, оценка: {enrollment.Grade.Value:F2}");
                else
                    Console.WriteLine($"{student.FirstName} {student.LastName} -> {course.Name}, оценка: не сдал");
            }
        }

        public void PrintAverageGrades()
        {
            Console.Write("Введите id курса: ");
            if (!Int32.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Неверный формат");
                return;
            }

            var group = enrollments
                .Where(e => e.CourseId == courseId && e.Grade.HasValue)
                .ToList();

            if (group.Count == 0)
            {
                Console.WriteLine($"Нет оценок для курса с ID {courseId}");
                return;
            }

            double avg = group.Average(e => e.Grade.Value);
            var course = courses.FirstOrDefault(c => c.Id == courseId);
            Console.WriteLine($"Курс: {course.Name}, средняя оценка: {avg:F2}");
        }

        public void SaveStudents()
        {
            try
            {
                var json = JsonConvert.SerializeObject(students);
                File.WriteAllText(studentsJsonFile, json);
                Console.WriteLine($"Студенты сохранены в файл: {studentsJsonFile}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении студентов: {ex.Message}");
            }
            
        }
        public void LoadStudents()
        {
            try
            {
                if (!File.Exists(studentsJsonFile))
                {
                    Console.WriteLine("Такого файла не существует");
                    return;
                }

                var json = File.ReadAllText(studentsJsonFile);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
                Console.WriteLine($"Студенты загружены из файла: {studentsJsonFile} (Загружено {students.Count} записей)");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке студентов: {ex.Message}");
            }
                
        }

        public void SaveCourses()
        {
            try
            {
                var json = JsonConvert.SerializeObject(courses);
                File.WriteAllText (coursesJsonFile, json);
                Console.WriteLine($"Успешно сохранены курсы в файл: {coursesJsonFile}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении курсов: {ex.Message}");
            }
        }
        public void LoadCourses()
        {
            try
            {
                if (!File.Exists(coursesJsonFile))
                {
                    Console.WriteLine("Такого файла не существует");
                    return;
                }
                
                var json = File.ReadAllText(coursesJsonFile);
                courses = JsonConvert.DeserializeObject<List<Course>>(json);
                Console.WriteLine($"Успешно загружены курсы из файла {coursesJsonFile} (Загружено {courses.Count} записей)");
            }
            catch( Exception ex )
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
        public void SaveEnrollments()
        {
            try
            {
                var json = JsonConvert.SerializeObject (enrollments);
                File.WriteAllText(enrollmentsJsonFile, json);
                Console.WriteLine($"Успешно сохранено в файл: {enrollmentsJsonFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
        public void LoadEnrollments()
        {
            try
            {
                if (!File.Exists(enrollmentsJsonFile))
                {
                    Console.WriteLine("Такого файла не существует");
                    return;
                }

                var json = File.ReadAllText (enrollmentsJsonFile);
                enrollments = JsonConvert.DeserializeObject<List<Enrollment>>(json);
                Console.WriteLine($"Успешно загруженo из файла {enrollmentsJsonFile} (Загружено {enrollments.Count} записей)");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

    }
}
