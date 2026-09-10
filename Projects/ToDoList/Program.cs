using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskService taskService = new TaskService();

            bool IsWork = true;

            while (IsWork)
            {
                
                PrintMenu();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        taskService.AddTask();
                        break;

                    case "2":
                        taskService.PrintAllTasks();
                        break;
                    case "3":
                        taskService.PrintActiveTasks();
                        break;
                    case "4":
                        taskService.PrintCompletedTasks();
                        break;
                    case "5":
                        taskService.PrintOverdueTasks();
                        break;
                    case "6":
                        taskService.MarkAsCompleted();
                        break;
                    case "7":
                        taskService.RemoveTask();
                        break;
                    case "8":
                        taskService.PrintStatistics();
                        break;
                    case "9":
                        taskService.SortByDeadline();
                        break;
                    case "0":
                        IsWork = false;
                        Console.WriteLine("До свидания!");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор");
                        break;

                }
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("           TO-DO LIST МЕНЕДЖЕР");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1.  Добавить задачу");
            Console.WriteLine("2.  Показать все задачи");
            Console.WriteLine("3.  Показать активные задачи");
            Console.WriteLine("4.  Показать выполненные задачи");
            Console.WriteLine("5.  Показать просроченные задачи");
            Console.WriteLine("6.  Отметить задачу выполненной");
            Console.WriteLine("7.  Удалить задачу");
            Console.WriteLine("8.  Показать статистику");
            Console.WriteLine("9.  Сортировать по дедлайну");
            Console.WriteLine("0.  Выход");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Выберите действие: ");

        }

    }
}


