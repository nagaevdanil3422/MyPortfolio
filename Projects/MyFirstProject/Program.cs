using System;

namespace MyFirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonService personService = new PersonService();

            Person person = new Person("Danila", 19);
            Person person1 = new Person("Ivan", 67);
            Person person2 = new Person("Danila", 12);

            personService.AddPerson(person);
            personService.AddPerson(person1);
            personService.AddPerson(person2);

            var min = personService.MinAge(personService.persons, 22);
            foreach(var i in min)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------------------------------------");

            personService.AllPerson();


            
        }
        
    }
}