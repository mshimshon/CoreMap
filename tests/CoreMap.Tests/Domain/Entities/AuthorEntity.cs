namespace CoreMap.Tests.Domain.Entities;
public record AuthorEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;

}
