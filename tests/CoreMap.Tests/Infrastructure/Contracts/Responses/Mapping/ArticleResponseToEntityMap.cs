using CoreMap.Tests.Domain.Entities;

namespace CoreMap.Tests.Infrastructure.Contracts.Responses.Mapping;

internal class ArticleResponseToEntityMap : ICoreMapHandler<ArticleResponse, ArticleEntity>
{
    public ArticleEntity Handler(ArticleResponse data, ICoreMap alsoMap) => new ArticleEntity()
    {
        Description = data.Description,
        Id = data.Id,
        Title = data.Title,
        WrittenBy = alsoMap.MapTo<AuthorResponse, AuthorEntity>(data.Author)
    };

}
