using CoreMap.Tests.Domain.Entities;

namespace CoreMap.Tests.Infrastructure.Contracts.Responses.Mapping;

internal class ArticleResponseToEntityMap : ICoreMapHandler<ArticleResponse, ArticleEntity>
{
    private readonly ICoreMap _coreMap;

    public ArticleResponseToEntityMap(ICoreMap coreMap)
    {
        _coreMap = coreMap;
    }

    public ArticleEntity Handler(ArticleResponse data) => new ArticleEntity()
    {
        Description = data.Description,
        Id = data.Id,
        Title = data.Title,
        WrittenBy = _coreMap.MapTo<AuthorResponse, AuthorEntity>(data.Author)
    };

    public Task<ArticleEntity> HandlerAsync(ArticleResponse data)
        => Task.FromResult(Handler(data));
}
