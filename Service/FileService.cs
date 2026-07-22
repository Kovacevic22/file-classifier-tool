using Model;

namespace Service;

public static class FileService
{
    public static IEnumerable<FileModel> Scan(string? path = null)
    {
        var dir = path ?? Directory.GetCurrentDirectory();
        var options = new EnumerationOptions()
        {
            RecurseSubdirectories = true,
            IgnoreInaccessible = true,
            AttributesToSkip = FileAttributes.System | FileAttributes.Hidden,
        };
        foreach (var filePath in Directory.EnumerateFiles(dir, "*", options))
        {
            var info = new FileInfo(filePath);
            yield return new FileModel()
            {
                Name =  info.Name,
                Author = Environment.UserName,
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
        var sourceWithSeparator = sourceDir.EndsWith(Path.DirectorySeparatorChar)? sourceDir : sourceDir + Path.DirectorySeparatorChar;
        if (destDir.Equals(sourceDir, StringComparison.OrdinalIgnoreCase) || destDir.StartsWith(sourceWithSeparator, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Source and destination cannot be in the same directory");   
        var files = Scan(source);
        var count = 0;
        var createdDirectories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var file in files)
        {
            var categoryFolder = Path.Combine(destDir, file.FileCategory.ToString());
            if (createdDirectories.Add(categoryFolder))
            {
                Directory.CreateDirectory(categoryFolder);
            }
            var destinationPath = UniquePath(Path.Combine(categoryFolder, file.Name));    
            try 
            {
                File.Move(file.Location, destinationPath, false);
                ++count;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Failed to move {file.Location}: {e.Message}");
            }
        }

        return count;
    }
    
    
    //====================================Additional functions=======================================================//
    private static string UniquePath(string path)
    {
        if (!File.Exists(path)) return path;
        var dir = Path.GetDirectoryName(path);
        if(!Directory.Exists(dir)) throw new DirectoryNotFoundException("Directory not found");
        var fileName =  Path.GetFileNameWithoutExtension(path);
        var fileExtension = Path.GetExtension(path);
        var i = 1;
        string candidate;
        do
        {
            candidate = Path.Combine(dir, $"{fileName} ({i}){fileExtension}");
            ++i;
        } while (File.Exists(candidate));
        return candidate;
    }
}