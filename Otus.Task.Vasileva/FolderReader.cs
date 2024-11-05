using System;
using System.IO;
using System.Linq;

namespace Otus.Task.Vasileva
{
    public class FolderReader
    {
        public async System.Threading.Tasks.Task ReadFilesInFolder(string folderPath)
        {
            var fileReader = new FileReader();

            var files = Directory.GetFiles(folderPath);
            var tasks = files.Select(file => fileReader.CountSpacesInFile(file)).ToArray();

            // Запускаю все задачи параллельно
            var results = await System.Threading.Tasks.Task.WhenAll(tasks);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"Файл: {files[i]}, Пробелов: {results[i]}");
            }
        }
    }
}
