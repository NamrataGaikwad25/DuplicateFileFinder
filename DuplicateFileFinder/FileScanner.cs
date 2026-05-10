using DuplicateFileFinder.Models;
using DuplicateFileFinder.Utils;

namespace DuplicateFileFinder
{
    public class FileScanner
    {
        private readonly string[] allowedExtensions =
        {
            ".c",
            ".cpp",
            ".h",
            ".rc"
        };

        public List<FileRecord> Scan(string basePath)
        {
            List<FileRecord> files = new();

            var allFiles = Directory.GetFiles(
                basePath,
                "*.*",
                SearchOption.AllDirectories);

            foreach (var file in allFiles)
            {
                string extension = Path.GetExtension(file).ToLower();

                if (!allowedExtensions.Contains(extension))
                    continue;

                files.Add(new FileRecord
                {
                    FileName = Path.GetFileName(file),
                    FullPath = file,
                    ProjectPath = Path.GetDirectoryName(file),
                    Hash = FileHasher.GetFileHash(file),
                    FileSize = new FileInfo(file).Length
                });
            }

            return files;
        }
    }
}