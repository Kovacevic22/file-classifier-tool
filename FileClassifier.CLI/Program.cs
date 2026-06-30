using Cocona;
using Service;

var builder = CoconaApp.CreateBuilder(args);

var app = builder.Build();

app.AddCommand("file-classifier", (
    [Argument(Description = "Folder where we want to organise files")]string destination,
    [Argument(Description = "Folder for scanning (default: current folder)")]string? source
) =>
{
    var service = new FileService();
    try
    {
        var count = service.Organise(source, destination);
        Console.WriteLine($"Organised {count} files into: {destination}");
    }catch(Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
});

app.Run();