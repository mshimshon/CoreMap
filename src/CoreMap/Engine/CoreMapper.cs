using Microsoft.Extensions.DependencyInjection;

namespace CoreMap.Engine;
internal class CoreMapper : ICoreMap
{
    private readonly IServiceProvider _serviceProvider;

    public CoreMapper(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public TDestination MapTo<TDestination, TOrigin>(TOrigin origin)
    {
        var service = GetService<TDestination, TOrigin>();
        return service.MapHandler(origin);
    }
    public async Task<TDestination> MapToAsync<TDestination, TOrigin>(TOrigin origin)
    {
        var service = GetService<TDestination, TOrigin>();
        return await service.MapHandlerAsync(origin);
    }

    private ICoreMapHandler<TOrigin, TDestination> GetService<TDestination, TOrigin>()
    {
        return _serviceProvider.GetRequiredService<ICoreMapHandler<TOrigin, TDestination>>();
    }
}
