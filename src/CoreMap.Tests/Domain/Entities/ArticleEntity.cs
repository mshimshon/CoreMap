namespace CoreMap.Tests.Domain.Entities;
public record ArticleEntity
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public AuthorEntity WrittenBy { get; init; } = default!;
}
