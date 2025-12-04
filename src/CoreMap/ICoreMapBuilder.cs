using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMap;

public interface ICoreMapBuilder
{
    TDestination To<TDestination>() where TDestination : class;


}
