namespace CoreMap;
public interface ICoreMap
{
    TDestination MapTo<TDestination, TOrigin>(TOrigin origin);
    Task<TDestination> MapToAsync<TDestination, TOrigin>(TOrigin origin);
}
