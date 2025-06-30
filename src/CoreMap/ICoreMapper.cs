namespace CoreMap;
public interface ICoreMap
{
    TDestination MapTo<TOrigin, TDestination>(TOrigin origin);
    Task<TDestination> MapToAsync<TOrigin, TDestination>(TOrigin origin);
}
