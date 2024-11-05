using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Task.Vasileva
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            int maxAttempts = 5; 
            string folderPath = string.Empty;
            bool validPath = false;

            // Даем пользователю 5 попыток на ввод правильного пути
            for (int attempts = 1; attempts <= maxAttempts; attempts++)
            {
                Console.WriteLine($"Попытка {attempts} из {maxAttempts}. Введите путь к папке:");
                folderPath = Console.ReadLine();

                // Проверка на пустой путь
                if (string.IsNullOrWhiteSpace(folderPath))
                {
                    Console.WriteLine("Путь не может быть пустым.");
                    continue;
                }

                // Проверка, существует ли папка
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Указанный путь не существует или не является папкой.");
                    if (attempts < maxAttempts)
                    {
                        Console.WriteLine($"Осталось попыток: {maxAttempts - attempts}");
                    }
                    continue;
                }

                validPath = true;
                break;
            }

            if (!validPath)
            {
                Console.WriteLine("Вы исчерпали все попытки. Программа завершена.");
                return;
            }

            var stopwatch = Stopwatch.StartNew();

            var folderReader = new FolderReader();
            await folderReader.ReadFilesInFolder(folderPath);

            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.ReadKey();
        }
    }
}
