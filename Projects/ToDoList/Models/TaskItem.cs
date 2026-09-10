using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskItem(int id, string title, string description, DateTime deadline)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            IsCompleted = false;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            if (DateTime.Now <= Deadline)
            {
                IsCompleted = false;
            }
            else
                IsCompleted = true;

            if (IsCompleted == false)
            {
                return $"[{Id}] {Title} | Дедлайн: {Deadline.ToString("dd, MM, yyyy")} | Статус: Активна ";
            }
            else
                return $"[{Id}] {Title} | Дедлайн: {Deadline.ToString("dd, MM, yyyy")} | Статус: Выполнена ";

        }
        public bool IsOverdue()
        {
            if (Deadline < DateTime.Now && IsCompleted == false)
            {
                return true;
            }
            else 
                return false ;
        }

    }
}
