namespace CoreMap;
public interface ICoreMap
{
    TDestination MapTo<TOrigin, TDestination>(TOrigin origin);
    Task<TDestination> MapToAsync<TOrigin, TDestination>(TOrigin origin);
    ICollection<TDestination> MapEachTo<TOrigin, TDestination>(ICollection<TOrigin> origins);
    Task<ICollection<TDestination>> MapEachToAsync<TOrigin, TDestination>(ICollection<TOrigin> origins);
}
