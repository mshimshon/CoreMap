using CoreMap.Tests.Domain.Entities;
using CoreMap.Tests.Infrastructure.Contracts.Requests;
using CoreMap.Tests.Infrastructure.Contracts.Requests.Mapping;
using CoreMap.Tests.Infrastructure.Contracts.Responses;
using CoreMap.Tests.Infrastructure.Contracts.Responses.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMap.Tests;

public abstract class TestBase : IDisposable
{
    protected readonly IServiceProvider ServiceProvider;

    protected TestBase()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddCoreMap(o => { });
        services.AddScoped<ICoreMapHandler<ArticleEntity, CreateArticleRequest>, ArticleEntityToCreateArticle>();
        services.AddScoped<ICoreMapHandler<ArticleResponse, ArticleEntity>, ArticleResponseToEntityMap>();
        services.AddScoped<ICoreMapHandler<AuthorResponse, AuthorEntity>, AuthorResponseToEntityMap>();
        // Register your services
        ServiceProvider = services.BuildServiceProvider();
    }
    public void Dispose()
    {
        if (ServiceProvider is IDisposable disposable)
            disposable.Dispose();
    }
}