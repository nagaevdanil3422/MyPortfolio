using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Course_Manager
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public Course(int id, string name, int credits)
        {
            Id = id;
            Name = name;
            Credits = credits;
        }
        public override string ToString()
        {
            return $"[{Id}] {Name}, Кредиты: {Credits}";
        }
    }
}
