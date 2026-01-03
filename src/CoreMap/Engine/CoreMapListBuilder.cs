using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMap.Engine;

internal class CoreMapListBuilder<TOrigin> : ICoreMapListBuilder where TOrigin : class
{
    private readonly ICollection<TOrigin> _origin;
    private readonly ICoreMap _coreMap;

    public CoreMapListBuilder(ICollection<TOrigin> origin, ICoreMap coreMap)
    {
        _origin = origin;
        _coreMap = coreMap;
    }

    public ICollection<TDestination> To<TDestination>() where TDestination : class
        => _coreMap.MapEachTo<TOrigin, TDestination>(_origin);
}
