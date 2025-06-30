using Microsoft.Extensions.DependencyInjection;

namespace CoreMap;
public static class MappingExt
{
    public static TDestination MapTo<TOrigin, TDestination>(this TOrigin origin, IServiceProvider serviceProvider)
    {
        var mapper = serviceProvider.GetRequiredService<ICoreMapHandler<TOrigin, TDestination>>();
        return mapper.MapHandler(origin);
    }

    public static async Task<TDestination> MapToAsync<TOrigin, TDestination>(this TOrigin origin, IServiceProvider serviceProvider)
    {
        var mapper = serviceProvider.GetRequiredService<ICoreMapHandler<TOrigin, TDestination>>();
        return await mapper.MapHandlerAsync(origin);
    }

}
