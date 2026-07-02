using Model;

namespace Service;

public static class FileService
{
    public static IEnumerable<FileModel> Scan(string? path = null)
    {
        var dir = path ?? Directory.GetCurrentDirectory();
        foreach (var filePath in Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories))
        {
            var info = new FileInfo(filePath);
            yield return new FileModel()
            {
                Name =  info.Name,
                Author = Environment.MachineName,
                CreatedDate = info.CreationTime,
                Extension = info.Extension,
                Size = info.Length,
                Location = info.FullName,
                FileCategory =  FileCategorizer.Categorize(info.Extension)
            };
        }
    }

    public static int Organise(string? source, string destinationRoot)
    {
        var sourceDir = Path.GetFullPath(source ?? Directory.GetCurrentDirectory());
        var destDir = Path.GetFullPath(destinationRoot);
        if (sourceDir == destDir)
            throw new InvalidOperationException("Source and destination cannot be in the same directory");   
        var files = Scan(source);
        var count = 0;
        foreach (var file in files)
        {
            var categoryFolder = Path.Combine(destinationRoot, file.FileCategory.ToString());
            Directory.CreateDirectory(categoryFolder);
            var destinationPath = Path.Combine(categoryFolder, file.Name);
            File.Copy(file.Location, destinationPath, true);
            ++count;
        }

        return count;
    }
}