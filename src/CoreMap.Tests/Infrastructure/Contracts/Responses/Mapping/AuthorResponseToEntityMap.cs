using CoreMap.Tests.Domain.Entities;

namespace CoreMap.Tests.Infrastructure.Contracts.Responses.Mapping;
internal class AuthorResponseToEntityMap : ICoreMapHandler<AuthorResponse, AuthorEntity>
{
    public AuthorEntity Handler(AuthorResponse data, ICoreMap alsoMap) => new AuthorEntity()
    {
        Id = data.Id,
        Name = data.Title
    };
}
