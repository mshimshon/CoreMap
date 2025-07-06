using CoreMap.Tests.Domain.Entities;

namespace CoreMap.Tests.Infrastructure.Contracts.Requests.Mapping;
internal class ArticleEntityToCreateArticle : ICoreMapHandler<ArticleEntity, CreateArticleRequest>
{
    public CreateArticleRequest Handler(ArticleEntity data) => new()
    {
        AuthorId = data.WrittenBy.Id,
        Description = data.Description,
        Title = data.Title
    };
    public Task<CreateArticleRequest> HandlerAsync(ArticleEntity data) => Task.FromResult(Handler(data));
}
