namespace CoreMap;
public interface ICoreMapHandler<in TOrigin, TDestination>
{
    TDestination MapHandler(TOrigin data);
    Task<TDestination> MapHandlerAsync(TOrigin data);
}
