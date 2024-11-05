using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Task.Vasileva
{
    public class FileReader
    {
        public async Task<int> CountSpacesInFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string content = await reader.ReadToEndAsync();
                return content.Count(c => c == ' ');
            }
        }
    }
}
