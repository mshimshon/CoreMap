using CoreMap.Engine;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMap;
public static class RegisterServiceExt
{
    public static IServiceCollection AddCoreMap(this IServiceCollection services, Type[]? scanAssemblies = default)
    {
        services.AddSingleton<ICoreMap, CoreMapper>();
        foreach (var assembly in scanAssemblies ?? new Type[] { })
        {
            // Find all types implementing ICoreMapper<,>
            var mapperTypes = assembly.Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICoreMapHandler<,>))
                    .Select(i => new { Implementation = t, Service = i }));

            foreach (var map in mapperTypes)
            {
                services.AddSingleton(map.Service, map.Implementation);
            }
        }
        return services;
    }
}
