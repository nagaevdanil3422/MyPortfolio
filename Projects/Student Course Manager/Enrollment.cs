using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Course_Manager
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; } 
        public double? Grade { get; set; }

        public Enrollment(int id, int studentId, int courseId, DateTime enrollmentDate, double? grade)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
            EnrollmentDate = enrollmentDate;
            Grade = grade;
        }

        public void Print()
        {
            if (Grade == null)
            {
                Console.WriteLine($"Студент {StudentId} записан на курс {CourseId}, Дата: {EnrollmentDate}, Оценка: Не сдал");
            }
            else
                Console.WriteLine($"Студент {StudentId} записан на курс {CourseId}, Дата: {EnrollmentDate}, Оценка: {Grade}");
        }
    }
}
