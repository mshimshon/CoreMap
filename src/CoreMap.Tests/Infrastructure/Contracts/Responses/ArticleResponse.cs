namespace CoreMap.Tests.Infrastructure.Contracts.Responses;
internal record ArticleResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public AuthorResponse Author { get; init; } = default!;
}
