using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class JsonStorage
    {
        public List<TaskItem> items = new List<TaskItem>();
        private readonly string filePath = "Tasks.json";

        public void SaveTasks()
        {
            try
            {
                var json = JsonConvert.SerializeObject(items);
                File.WriteAllText(filePath, json);
                Console.WriteLine($"Успешно сохранены данные в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
        public void LoadTasks()
        {
            try
            {
                if(!File.Exists(filePath))
                {
                    Console.WriteLine("Такого файла не существует");
                    return;
                }
                var json = File.ReadAllText(filePath);
                items = JsonConvert.DeserializeObject<List<TaskItem>>(json);
                Console.WriteLine($"Успешно загружены данные (Всего {items.Count} записей)");
            }
            catch ( Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузки данных: {ex.Message}");
            }
        }
    }
}
