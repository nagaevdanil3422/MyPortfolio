using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstProject
{
    public class PersonService
    {
        public List<Person> persons = new List<Person>();

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }
        public List<Person> MinAge(List<Person> persons, int age)
        {
            return persons.Where(p => p.Age < age).ToList();
        }
        public void AllPerson()
        {
            foreach (Person p in persons)
            {
                Console.WriteLine(p);
            }
        }
    }
}
