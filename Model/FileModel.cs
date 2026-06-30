namespace Model;

public sealed record FileModel
{
    public required string Name { get; init; }
    public required string Author { get; init; }
    public DateTime CreatedDate { get; init; }
    public required string Extension { get; init; }
    public long Size { get; init; }
    public required string Location { get; init; }
    public FileCategory FileCategory { get; init; }
}