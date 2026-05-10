using DuplicateFileFinder.Models;

namespace DuplicateFileFinder
{
    public class DuplicateFinder
    {
        public Dictionary<string, List<FileRecord>> FindDuplicates(
            List<FileRecord> files,
            bool compareContent)
        {
            if (compareContent)
            {
                return files
                    .GroupBy(f => $"{f.FileName}_{f.Hash}")
                    .Where(g => g.Count() > 1)
                    .ToDictionary(g => g.Key, g => g.ToList());
            }
            else
            {
                return files
                    .GroupBy(f => f.FileName)
                    .Where(g => g.Count() > 1)
                    .ToDictionary(g => g.Key, g => g.ToList());
            }
        }
    }
}