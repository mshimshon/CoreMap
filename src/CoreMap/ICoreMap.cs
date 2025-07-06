namespace CoreMap;
public interface ICoreMap
{
    TDestination MapTo<TOrigin, TDestination>(TOrigin origin);
    ICollection<TDestination> MapEachTo<TOrigin, TDestination>(ICollection<TOrigin> origins);
}
