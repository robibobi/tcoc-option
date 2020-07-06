using System;
using System.Collections.Generic;
using System.Text;

namespace Tcoc.OptionType
{
    public class None<T> : Option<T>
    {
        internal None()
        {
        }

        public override string ToString()
        {
            return $"None<{typeof(T).Name}>";
        } 
    }
}
