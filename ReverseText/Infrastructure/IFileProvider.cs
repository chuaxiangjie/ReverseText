using System.Collections.Generic;
using System.Text;

namespace ReverseText.Infrastructure
{
    public interface IFileProvider
    {
        IEnumerable<string> ReadLines(string path, Encoding encoding);
        void WriteAllLines(string path, string[] contents, Encoding encoding);
    }
}