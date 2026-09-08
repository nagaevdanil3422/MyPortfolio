using Student_Course_Manager.Data;
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
            
            Database database = new Database();
            
            database.SeedData();
            database.SaveStudents();
            database.LoadStudents();
            bool isWork = true;

            while (isWork)
            {
                
                Console.WriteLine("=========================================\r\n   СИСТЕМА УПРАВЛЕНИЯ УЧЕБНЫМ ЦЕНТРОМ\r\n=========================================" +
                    "\r\n1. Показать всех студентов" +
                    "\r\n2. Показать все курсы" +
                    "\r\n3. Добавить студента" +
                    "\r\n4. Добавить курс" +
                    "\r\n5. Записать студента на курс" +
                    "\r\n6. Показать записи студентов на курсы (JOIN)" +
                    "\r\n7. Показать среднюю оценку по курсам (GROUP BY)" +
                    "\r\n8. Очистить консоль" +
                    "\r\n0. Выход\r\n=========================================");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        {
                            database.PrintAllStudents();
                            break;
                        }
                    case "2":
                        {
                            database.PrintAllCourses();
                            break;
                        }
                    case "3":
                        {
                            database.AddStudent();
                            break;
                        }
                    case "4":
                        {
                            database.AddCourse();
                            break;
                        }
                    case "5":
                        {
                            database.EnrollStudent();
                            break;
                        }
                    case "6":
                        {
                            database.PrintEnrollmentsWithDetails();
                            break;
                        }
                    case "7":
                        {
                            database.PrintAverageGrades();
                            break;
                        }
                    case "8":
                        {
                            Console.Clear();
                            break;
                        }
                    case "0":
                        {
                            isWork = false;
                            Console.WriteLine("До свидания Друг! Удачки тебе!");
                            break;
                        }

                }


            }

            
        }
        
    }
}
