using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Course_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new Student(1, "Иван", "Петров", 20, "ivan@mail.ru");
            student.Print();
            var date = DateTime.Now;
            var enrolment = new Enrollment(1, 1, 1, date, null);
            enrolment.Print();
        }
    }
}
