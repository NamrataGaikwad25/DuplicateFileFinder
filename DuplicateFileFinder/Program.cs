using DuplicateFileFinder;
using DuplicateFileFinder.Utils;
using System.Diagnostics;

Stopwatch stopwatch = Stopwatch.StartNew();

Console.WriteLine("Enter folder path:");

string folderPath = Console.ReadLine();

if (!Directory.Exists(folderPath))
{
    Console.WriteLine("Folder does not exist.");
    return;
}

try
{
    Console.WriteLine("Scanning files...");

    FileScanner scanner = new();

    var files = scanner.Scan(folderPath);

    Console.WriteLine($"Files scanned: {files.Count}");

    Console.WriteLine("Select Mode:");
    Console.WriteLine("1 = Basic (File name only)");
    Console.WriteLine("2 = Extended (File name + content)");

    string mode = Console.ReadLine();

    bool compareContent = mode == "2";

    DuplicateFinder finder = new();

    var duplicates = finder.FindDuplicates(files, compareContent);

    Console.WriteLine($"Duplicate groups: {duplicates.Count}");

    OutputWriter.Write(duplicates);

    File.WriteAllText("output.txt", "Duplicate scan completed.");

    Console.WriteLine("Output saved to output.txt");

    stopwatch.Stop();

    Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");

    Console.WriteLine("Finished.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadLine();