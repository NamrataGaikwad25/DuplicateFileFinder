namespace DuplicateFileFinder.Models
{
    public class FileRecord
    {
        public string FileName { get; set; }

        public string FullPath { get; set; }

        public string ProjectPath { get; set; }

        public string Hash { get; set; }

        public long FileSize { get; set; }
    }
}