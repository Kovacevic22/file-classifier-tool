namespace FileClassifier.CLI.Core;

public static class ConsoleMessages
{
    public static void ShowHelp()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== File Classifier CLI ===");
        Console.ResetColor();
        Console.WriteLine("Usage:");
        Console.WriteLine("  -s,  --scan                            Scan and list files, without moving them.");
        Console.WriteLine("  -s  -sr <path>                         Scan a specific folder without moving files.");
        Console.WriteLine("  -d,  --destination  <Required: path>   Set the target directory where folders will be created.");
        Console.WriteLine("  -sr, --source       [Optional: path]   Set the custom directory to start organizing files from.");
        if (OperatingSystem.IsWindows())
        {
            Console.WriteLine("\nExamples (Windows):");
            Console.WriteLine(@"FileClassifier.CLI.exe -s -sr C:\Downloads");
            Console.WriteLine(@"FileClassifier.CLI.exe -d C:\Organized -sr C:\Downloads");
        }
        else
        {
            Console.WriteLine("\nExamples (Linux/macOS):");
            Console.WriteLine("./FileClassifier.CLI -s -sr /home/user/Downloads");
            Console.WriteLine("./FileClassifier.CLI -d /home/user/Organized -sr /home/user/Downloads");
        }
    }

    public static void MissingPathError(string flag)
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
    public static void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void PrintPrompt(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}