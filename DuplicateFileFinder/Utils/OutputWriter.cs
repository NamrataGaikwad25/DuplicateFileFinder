using DuplicateFileFinder.Models;
using System.Text;

namespace DuplicateFileFinder.Utils
{
    public static class OutputWriter
    {
        public static void Write(
            Dictionary<string, List<FileRecord>> duplicates)
        {
            StringBuilder sb = new();

            foreach (var group in duplicates)
            {
                var files = group.Value;

                var projects = files
                    .Select(f => f.ProjectPath)
                    .Distinct();

                foreach (var project in projects)
                {
                    sb.AppendLine(project);
                }

                var uniqueFiles = files
                    .Select(f => f.FileName)
                    .Distinct();

                foreach (var fileName in uniqueFiles)
                {
                    var fileInfo = files.First(f => f.FileName == fileName);

                    sb.AppendLine($"\t{fileName} ({fileInfo.FileSize} bytes)");
                }

                sb.AppendLine();
            }

            string result = sb.ToString();

            Console.WriteLine(result);

            string desktopPath = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);

            string outputPath = Path.Combine(desktopPath, "output.txt");

            File.WriteAllText(outputPath, result);
        }
    }
}