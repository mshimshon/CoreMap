using Microsoft.Extensions.DependencyInjection;

namespace CoreMap.Engine;
internal class CoreMapper : ICoreMap
{
    private readonly IServiceProvider _serviceProvider;

    public CoreMapper(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TDestination MapTo<TOrigin, TDestination>(TOrigin origin)
    {
        var service = GetService<TOrigin, TDestination>();
        return service.Handler(origin);
    }

    public ICollection<TDestination> MapEachTo<TOrigin, TDestination>(ICollection<TOrigin> origins)
        => origins.Select(MapTo<TOrigin, TDestination>).ToList();



    private ICoreMapHandler<TOrigin, TDestination> GetService<TOrigin, TDestination>()
    {
        return _serviceProvider.GetRequiredService<ICoreMapHandler<TOrigin, TDestination>>();
    }

}
