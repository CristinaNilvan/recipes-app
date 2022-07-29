using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesApp.Domain.Models;

namespace RecipesApp.Console.FileAssignment
{
    internal class FileOperations
    {
        private static string? _directoryPath;
        private static string? _filePath;
        private static FileStream _fileStream;

        public static void DoDirectorySetup()
        {
            _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "AssignmentFolder");
            Directory.CreateDirectory(_directoryPath);
        }

        public static void DoFileSetup()
        {
            _filePath = Path.Combine(_directoryPath, "IngredientsFile.txt");
            _fileStream = File.Create(_filePath);
        }

        public static void WriteIngredientsInFile(List<Ingredient> ingredients)
        {
            using (var streamWriter = new StreamWriter(_fileStream))
            {
                foreach (var item in ingredients)
                {
                    streamWriter.WriteLine($"{item.Id} {item.Name}");
                }
            }
        }

        public static void ReadIngredientsFromFile()
        {
            using (var streamReader = new StreamReader(_filePath))
            {
                var read = true;

                while (read)
                {
                    var line = streamReader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                        read = false;
                    else 
                        System.Console.WriteLine(line);
                }
            }
        }
    }
}
