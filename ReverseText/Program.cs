using ReverseText.Infrastructure;
using System;
using System.IO;

namespace ReverseText
{
    // IMPORTANT: make sure you read the instructions in README.md

    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "TestTextFile.txt";

            try
            {
                var reversedContent = new FileTextReverser(new FileProvider())
                    .ReverseFileContents(filePath);

                Console.WriteLine(reversedContent);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File: {filePath} not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }
    }
}