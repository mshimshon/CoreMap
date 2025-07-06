namespace CoreMap;
public interface ICoreMapHandler<in TOrigin, TDestination>
{
    TDestination Handler(TOrigin data);
    Task<TDestination> HandlerAsync(TOrigin data);
}
