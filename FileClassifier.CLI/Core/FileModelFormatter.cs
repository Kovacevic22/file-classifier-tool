using Model;

namespace FileClassifier.CLI.Core;

public static class FileModelFormatter
{
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
        PrintHeader();
        foreach (var file in files)
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
}