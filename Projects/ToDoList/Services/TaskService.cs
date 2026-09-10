using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    internal class TaskService
    {
        JsonStorage jsonStorage = new JsonStorage();
        int _nextTaskId = 1;

        //Добавление
        #region AddTask
        public void AddTask()
        {
            Console.Write("Введите название: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Введите описание: ");
            string inputDescription = Console.ReadLine();

            Console.Write("Введите дату дедлайна (дд.мм.гггг): ");
            string inputDeadline = Console.ReadLine();
            if (!DateTime.TryParse(inputDeadline, out DateTime deadline))
            {
                Console.WriteLine("Неверный формат ввода");
                return;
            }

            int _freeId = 1;

            while (jsonStorage.items.Any(p => p.Id == _freeId))
            {
                _freeId++;
            }

            _nextTaskId = _freeId;


            jsonStorage.items.Add(new TaskItem(_nextTaskId, inputTitle, inputDescription, deadline));
            
            Console.WriteLine($"Задача {inputTitle} успешно добавлена");
            jsonStorage.SaveTasks();

        }
        #endregion

        //Удаление
        #region RemoveTask
        public void RemoveTask()
        {
            Console.WriteLine("Какую задачу хотите удалить?");
            Console.Write("Введите id задачи: ");
            string inputTaskRemoveId = Console.ReadLine();
            if (!Int32.TryParse(inputTaskRemoveId, out int id))
            {
                Console.WriteLine("Ошибка ввода формата");
                return;
            }


            var itemsIdTask = jsonStorage.items.FirstOrDefault(p => p.Id == id);
            if (itemsIdTask != null)
            {
                jsonStorage.items.Remove(itemsIdTask);
                
                Console.WriteLine($"Задача '{itemsIdTask.Title}' удалена");
                jsonStorage.SaveTasks();
            }
            else
                Console.WriteLine("Ошибка: задача с таким id не найдена");

        }
        #endregion

        //Вывод всех задач
        #region PrintAllTasks
        public void PrintAllTasks()
        {
            jsonStorage.LoadTasks();
            if (jsonStorage.items.Count == 0)
            {
                Console.WriteLine("Задач нет");
                return;
            }

            Console.WriteLine("----- Все задачи -----");
            foreach ( var item in jsonStorage.items)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        //Отмечание задачи выполненой
        #region MarkAsCompleted
        public void MarkAsCompleted()
        {
            Console.Write("Введите id задачи: ");
            string inputIdTask = Console.ReadLine();
            if(!Int32.TryParse(inputIdTask, out int id)) 
            {
                Console.WriteLine("Неверный ввод формата");
                return;
            }

            var idTaskfirstOrDefail = jsonStorage.items.FirstOrDefault(p => p.Id == id);

            if (idTaskfirstOrDefail == null)
            {
                Console.WriteLine("Задача с таким id не найдена");
                return;
            }
            if (idTaskfirstOrDefail.IsCompleted == true)
            {
                Console.WriteLine("Задача с таким id уже выполнена");
                return;
            }
            else
            {
                idTaskfirstOrDefail.IsCompleted = true;

                Console.WriteLine($"Задача '{idTaskfirstOrDefail.Title} отмечена выполненой'");
                jsonStorage.SaveTasks();
            }
        }
        #endregion

        //Вывод только активных задач
        #region PrintActiveTasks
        public void PrintActiveTasks()
        {
            var activeTaskWhere = jsonStorage.items.Where(p => !p.IsCompleted).ToList();
            
            if (activeTaskWhere.Count == 0)
            {
                Console.WriteLine("Активных задач нет");
            }
            else
            {
                Console.WriteLine("----- Активные задачи -----");
                foreach (var item in activeTaskWhere)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        //Вывод только выполненных задач
        #region PrintCompletedTasks
        public void PrintCompletedTasks()
        {
            var completedTasks = jsonStorage.items.Where (p => p.IsCompleted == true).ToList();
            if (completedTasks.Count == 0)
            {
                Console.WriteLine("Выполненных задач нет");
            }
            else
            {
                Console.WriteLine("----- Выполненные задачи -----");
                foreach (var item in completedTasks)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        //Вывод только просроченных задач
        #region PrintOverdueTasks
        public void PrintOverdueTasks()
        {
            var tasksOverdueWhere = jsonStorage.items.Where(p => p.IsOverdue()).ToList();

            if (tasksOverdueWhere.Count == 0)
            {
                Console.WriteLine("Просроченных задач нет");
            }
            else
            {
                Console.WriteLine("----- Просроченные задачи -----");
                foreach (var item in jsonStorage.items)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion

        //Вывод статистики
        #region PrintStatistics
        public void PrintStatistics()
        {
            var allTasks = jsonStorage.items.Count;
            var active = jsonStorage.items.Count(p => !p.IsCompleted);
            var completed = jsonStorage.items.Count(p => p.IsCompleted == true);
            var overdue = jsonStorage.items.Count(p => p.IsOverdue());

            Console.WriteLine("----- Статистика -----");
            Console.WriteLine($"Всего задач: {allTasks}" +
                $"\nАктивных: {active}" +
                $"\nВыполненных: {completed}" +
                $"\nПросроченных: {overdue}");
        }
        #endregion

        //Вывод отсортированных задач по дедлайну
        #region SortByDeadline
        public void SortByDeadline()
        {
            var sortedDeadline = jsonStorage.items.OrderBy(p => p.Deadline).ToList();

            if(sortedDeadline.Count == 0)
            {
                Console.WriteLine("Задач нет для сортировки");
                return;
            }
            else
            {
                Console.WriteLine("----- Сортировка по дедлайну -----");
                foreach (var item in sortedDeadline)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion
    }
}
