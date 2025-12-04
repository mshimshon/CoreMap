using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMap;

public interface ICoreMapListBuilder
{
    ICollection<TDestination> To<TDestination>() where TDestination : class;


}
