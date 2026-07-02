using Model;

namespace FileClassifier.CLI.Core;

public static class HelperFunctions
{
    
    //==========================================FOR SCANNING=========================================================//
    private const int NameWidth = 50;
    private const int SizeWidth = 10;
    private const int DateWidth = 12;
    private const int CategoryWidth = 12;
    private const int AuthorWidth = 10;
    
    private static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(
            $"{"Name",-NameWidth} {"Size",-SizeWidth} {"Created",-DateWidth} {"Category",-CategoryWidth} {"Author",-AuthorWidth}");
        Console.WriteLine(new string('-', NameWidth + SizeWidth + DateWidth + CategoryWidth + AuthorWidth + 4));
        Console.ResetColor();
    }
    private static void ToLine(FileModel fileModel)
    {
        Console.WriteLine($"{fileModel.Name,-NameWidth} {FormatSize(fileModel.Size),-SizeWidth} {fileModel.CreatedDate,-DateWidth:MM/dd/yyyy} {fileModel.FileCategory,-CategoryWidth} {fileModel.Author,-AuthorWidth}");
    }
    public static void PrintAll(IEnumerable<FileModel> files)
    {
        var fileList = files.ToList();
        PrintHeader();
        foreach (var file in fileList)
        {
            ToLine(file);
        }
        
    }
    private static string FormatSize(long bytes)
    {
        string[] units = { "B", "KB", "MB", "GB" };
        double size = bytes;
        int unit = 0;
        while (size >= 1024 && unit < units.Length - 1)
        {
            size /= 1024;
            ++unit;
        }

        return $"{size:0.#} {units[unit]}";
    }
    //============================================FOR PRINTING========================================================//
    public static void ShowHelp()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== File Classifier CLI ===");
        Console.ResetColor();
        Console.WriteLine("Usage:");
        Console.WriteLine("  -s,  --scan         [Optional: path]  Scan and list files without moving them.");
        Console.WriteLine("  -d,  --destination  <Required: path>  Set the target directory where folders will be created.");
        Console.WriteLine("  -sr, --source       [Optional: path]  Set the custom directory to start organizing files from.");
        if (OperatingSystem.IsWindows())
        {
            Console.WriteLine("\nExamples (Windows):");
            Console.WriteLine(@"FileClassifier.CLI.exe -d C:\Organized -sr C:\Downloads");
        }
        else
        {
            Console.WriteLine("\nExamples (Linux/macOS):");
            Console.WriteLine("./FileClassifier.CLI -d /home/user/Organized -sr /home/user/Downloads");
        }
    }

    public static void MissingArgumentError(string flag)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {flag} requires a path.");
        Console.ResetColor();
    }

    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {message}");
        Console.ResetColor();
    }
}