namespace CoreMap.Tests.Infrastructure.Contracts.Requests;
public record CreateArticleRequest
{
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public Guid AuthorId { get; init; }
}
