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
            HelperFunctions.ShowHelp();
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
                        HelperFunctions.MissingArgumentError($"{args[i]}");
                        return;
                    }
                    destination = args[++i];
                    break;
                case "-sr" or "--source":
                    if (i + 1 >= args.Length || args[i + 1].StartsWith('-'))
                    {
                        HelperFunctions.MissingArgumentError($"{args[i]}");
                        return;
                    }
                    source = args[++i];
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Unknown option {args[i]}. Please specify a valid option.");
                    Console.ResetColor();
                    return;
            }
        }

        if (scanFlag)
        {
            try
            {
                var scannedFiles = FileService.Scan(source);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();

                HelperFunctions.PrintAll(scannedFiles);
            }catch(Exception e)
            {
                HelperFunctions.PrintError(e.Message);
            }
        }
        else if(destination != null)
        {
            try
            {
                Console.WriteLine($"Please type (yes or y) if you want to organise files to the {destination}.");
                string? key = Console.ReadLine();
                if (key is "y" or "yes")
                {
                    var count = FileService.Organise(source, destination);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Files copying to {destination}...");
                    Console.ResetColor();
                    Console.WriteLine($"Organised {count} file(s).");
                }
                else
                {
                    Console.WriteLine("You gave up on transferring the files.");
                }
            }catch(Exception e)
            {
                HelperFunctions.PrintError(e.Message);
            }
        }
    }
}