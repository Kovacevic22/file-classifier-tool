namespace Model;

public sealed record FileModel
{
    public string Name { get; init; }
    public string Author { get; init; }
    public DateTime CreatedDate { get; init; }
    public string Extension { get; init; }
    public long Size { get; init; }
    public string Location { get; init; }
    public FileCategory FileCategory { get; init; }
}