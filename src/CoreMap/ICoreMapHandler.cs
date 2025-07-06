namespace CoreMap;
public interface ICoreMapHandler<in TOrigin, out TDestination>
{
    TDestination Handler(TOrigin data, ICoreMap alsoMap);
}
