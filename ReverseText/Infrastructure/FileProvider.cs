using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReverseText.Infrastructure
{
    public class FileProvider : IFileProvider
    {
        public IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            return File.ReadLines(path, encoding);
        }

        public void WriteAllLines(string path, string[] contents, Encoding encoding)
        {
            using var writer = new StreamWriter(path, false);
            for (int i = 0; i < contents.Length; i++)
            {
                var content = contents[i];

                if (i == contents.Length - 1)
                    writer.Write(content, encoding);
                else
                    writer.WriteLine(content, encoding);
            }
        }
    }
}