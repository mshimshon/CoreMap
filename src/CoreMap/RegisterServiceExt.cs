using CoreMap.Engine;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMap;
public static class RegisterServiceExt
{
    public static IServiceCollection AddCoreMap(this IServiceCollection services, Action<CoreMapConfiguration> options, Type[]? scanAssemblies = default)
    {
        var config = new CoreMapConfiguration();
        options(config);
        services.AddScoped<ICoreMap, CoreMapper>();
        foreach (var assembly in scanAssemblies ?? new Type[] { })
        {
            // Find all types implementing ICoreMapper<,>
            var mapperTypes = assembly.Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICoreMapHandler<,>))
                    .Select(i => new { Implementation = t, Service = i }));

            foreach (var map in mapperTypes)
                if (config.Scope == Enums.ServiceScope.Scoped)
                    services.AddScoped(map.Service, map.Implementation);
                else if (config.Scope == Enums.ServiceScope.Transient)
                    services.AddTransient(map.Service, map.Implementation);

        }
        return services;
    }
}
