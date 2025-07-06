using CoreMap.Tests.Domain.Entities;
using CoreMap.Tests.Infrastructure.Contracts.Requests;
using CoreMap.Tests.Infrastructure.Contracts.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMap.Tests;
public class MappingTests : TestBase
{
    [Fact]
    public async Task RequestShouldProperlyConvert()
    {
        var coreMap = ServiceProvider.GetRequiredService<ICoreMap>();
        var entity = new ArticleEntity()
        {
            Description = "A description",
            Title = "A Title",
            Id = Guid.NewGuid(),
            WrittenBy = new AuthorEntity()
            {
                Id = Guid.NewGuid(),
                Name = "Maksim Shimshon"
            }
        };

        var createRequest = coreMap.MapTo<ArticleEntity, CreateArticleRequest>(entity);
        Assert.Equal(entity.Title, createRequest.Title);
        Assert.Equal(entity.Description, createRequest.Description);
        Assert.Equal(entity.WrittenBy.Id, createRequest.AuthorId);
    }

    [Fact]
    public async Task ArrayConverter_ShouldConvertAll()
    {
        var coreMap = ServiceProvider.GetRequiredService<ICoreMap>();
        var response = new ArticleResponse()
        {
            Description = "A description",
            Title = "A Title",
            Id = Guid.NewGuid(),
            Author = new AuthorResponse()
            {
                Id = Guid.NewGuid(),
                Title = "Maksim Shimshon"
            }
        };
        List<ArticleResponse> responses = new()
        {
            response with { },
            response with{ }
        };

        ICollection<ArticleEntity> entities = coreMap.MapEachTo<ArticleResponse, ArticleEntity>(responses);
        Assert.All(entities, p =>
        {
            Assert.Equal(response.Title, p.Title);
            Assert.Equal(response.Description, p.Description);
            Assert.Equal(response.Id, p.Id);
            Assert.Equal(response.Author.Title, p.WrittenBy.Name);
            Assert.Equal(response.Author.Id, p.WrittenBy.Id);
        });
    }
}
