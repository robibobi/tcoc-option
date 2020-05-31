using System;
using System.Collections.Generic;
using System.Text;

namespace Tcoc.OptionType
{
    public class Some<T> : Option<T>
    {
        public T Value { get; }

        internal Some(T value)
        {
            Value = value;
        }
    }
}
