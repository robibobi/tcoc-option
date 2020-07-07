using System;
using System.Collections.Generic;
using System.Text;

namespace Tcoc.OptionType
{
    public readonly struct None<T> : Option<T>
    {
        public override string ToString()
        {
            return $"None<{typeof(T).Name}>";
        } 
    }
}
