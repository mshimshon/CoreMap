namespace CoreMap.Tests.Infrastructure.Contracts.Responses;
internal class AuthorResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
}
