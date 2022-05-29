using ReverseText.Infrastructure;
using ReverseText.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseText
{
    public sealed class FileTextReverser
    {
        private readonly IFileProvider _fileProvider;
        private readonly Encoding _encoding;

        public FileTextReverser(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            _encoding = Encoding.UTF8;
        }

        public string ReverseFileContents(string filePath)
        {
            var allReversedText = new List<string>();

            var allLines = _fileProvider.ReadLines(filePath, _encoding);
            foreach (var line in allLines)
            {
                allReversedText.Add(line.Reverse());
            }
            _fileProvider.WriteAllLines(filePath, allReversedText.ToArray(), _encoding);

            return string.Join(Environment.NewLine, allReversedText);
        }
    }
}