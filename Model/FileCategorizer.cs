namespace Model;

public static class FileCategorizer
{
    private static readonly Dictionary<string, FileCategory> Categories = new()
    {
        [".jpg"] = FileCategory.Image,
        [".jpeg"] = FileCategory.Image,
        [".png"] = FileCategory.Image,
        [".gif"] = FileCategory.Image,
        [".doc"] = FileCategory.Document,
        [".docx"] = FileCategory.Document,
        [".pdf"] = FileCategory.Document,
        [".ppt"] = FileCategory.Document,
        [".pptx"] = FileCategory.Document,
        [".exe"] = FileCategory.Executable,
        [".bat"] = FileCategory.Executable,
    };

    public static FileCategory Categorize(string extension)
    {
        var ext = extension.ToLowerInvariant(); // daje uvek isti rezultat bez obzira na lokalizaciju korisnika
        return Categories.GetValueOrDefault(ext, FileCategory.Unknown);
    }
}