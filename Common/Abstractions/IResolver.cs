using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Abstractions
{
    public interface IResolver
    {
        TInstanceType Resolve<TInstanceType>();
    }
}
