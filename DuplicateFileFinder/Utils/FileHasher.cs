using System.Security.Cryptography;
using System.Text;

namespace DuplicateFileFinder.Utils
{
    public static class FileHasher
    {
        public static string GetFileHash(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);

            byte[] hash = sha256.ComputeHash(stream);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}