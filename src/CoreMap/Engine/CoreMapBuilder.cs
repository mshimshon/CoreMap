using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMap.Engine;

internal class CoreMapBuilder<TOrigin> : ICoreMapBuilder where TOrigin : class
{
    private readonly TOrigin _origin;
    private readonly ICoreMap _coreMap;

    public CoreMapBuilder(TOrigin origin, ICoreMap coreMap)
    {
        _origin = origin;
        _coreMap = coreMap;
    }

    public TDestination To<TDestination>() where TDestination : class
        => _coreMap.MapTo<TOrigin, TDestination>(_origin);
}
