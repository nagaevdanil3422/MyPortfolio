using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Course_Manager
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Student(int id, string firstName, string lastName, int age, string email )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;

        }
        public override string ToString()
        {
            if (Email  == null) 
                return $"[{Id}] {FirstName} {LastName}, возраст: {Age}, email: Не указан";
            else
                return $"[{Id}] {FirstName} {LastName}, возраст: {Age}, email: {Email}";
        }

    }
}
