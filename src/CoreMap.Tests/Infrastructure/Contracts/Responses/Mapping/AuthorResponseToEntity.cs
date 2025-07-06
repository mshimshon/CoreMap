using CoreMap.Tests.Domain.Entities;

namespace CoreMap.Tests.Infrastructure.Contracts.Responses.Mapping;
internal class AuthorResponseToEntity : ICoreMapHandler<AuthorResponse, AuthorEntity>
{
    public AuthorEntity Handler(AuthorResponse data) => new AuthorEntity()
    {
        Id = data.Id,
        Name = data.Title
    };

    public Task<AuthorEntity> HandlerAsync(AuthorResponse data) => Task.FromResult(Handler(data));
}
