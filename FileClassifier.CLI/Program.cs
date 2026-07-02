using FileClassifier.CLI.Core;

namespace FileClassifier.CLI;
using System;
using Service;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0 || args[0] == "-h" || args[0] == "--help")
        {
            ConsoleMessages.ShowHelp();
            return;
        }
        
        string? destination = null;
        string? source = null;
        var scanFlag = false;
        
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-s" or "--scan":
                    scanFlag = true;
                    break;
                case "-d" or "--destination":
                    if (i + 1 >= args.Length || args[i + 1].StartsWith('-'))
                    {
                        ConsoleMessages.MissingPathError($"{args[i]}");
                        return;
                    }
                    destination = args[++i];
                    break;
                case "-sr" or "--source":
                    if (i + 1 >= args.Length || args[i + 1].StartsWith('-'))
                    {
                        ConsoleMessages.MissingPathError($"{args[i]}");
                        return;
                    }
                    source = args[++i];
                    break;
                default:
                    ConsoleMessages.PrintError($"Unknown option {args[i]}. Please specify a valid option.");
                    return;
            }
        }

        if (!scanFlag && destination == null)
        {
            ConsoleMessages.PrintError($"Please specify a valid destination.");
            Console.WriteLine();
            ConsoleMessages.ShowHelp();
        }
        else if (scanFlag)
        {
            try
            {
                var scannedFiles = FileService.Scan(source);
                FileModelFormatter.PrintAll(scannedFiles);
            }catch(Exception e)
            {
                ConsoleMessages.PrintError(e.Message);
            }
        }
        else if(destination != null)
        {
            try
            {
                ConsoleMessages.PrintPrompt($"Please type (yes or y) if you want to organise files to the {destination}.");
                string? key = Console.ReadLine();
                if (key is "y" or "yes")
                {
                    ConsoleMessages.PrintInfo($"Files copying to {destination}...");
                    var count = FileService.Organise(source, destination);
                    ConsoleMessages.PrintInfo($"Organised {count} file(s).");
                }
                else
                {
                    Console.WriteLine("You gave up on transferring the files.");
                    
                }
            }catch(Exception e)
            {
                ConsoleMessages.PrintError(e.Message);
            }
        }
    }
}