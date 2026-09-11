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
            CreatedAt = DateTime.Now;
            IsCompleted = false;
        }

        public bool IsOverdue
        {
            get { return !IsCompleted && DateTime.Now > Deadline; }
        }

        public override string ToString()
        {
            string status;

            if (IsCompleted)
            {
                status = "Выполнена";
            }
            else if (IsOverdue)
            {
                status = "Просрочена";
            }
            else
            {
                status = "Активна";
            }

            return $"[{Id}] {Title} | Дедлайн: {Deadline:dd, MM, yyyy} | Статус: {status}";
        }

    }
}
