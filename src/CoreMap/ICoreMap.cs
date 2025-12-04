namespace CoreMap;
public interface ICoreMap
{

    ICoreMapBuilder Map<TOrigin>(TOrigin origin)
        where TOrigin : class;

    TDestination MapTo<TOrigin, TDestination>(TOrigin origin);
    ICollection<TDestination> MapEachTo<TOrigin, TDestination>(ICollection<TOrigin> origins);
    ICoreMapListBuilder MapEach<TOrigin>(ICollection<TOrigin> origins)
        where TOrigin : class;
}
