using System.Collections.Generic;
using System.Linq;

namespace Tcoc.OptionType.Extensions
{
    public static class EnumerableExtensions
    {
        public static Option<IEnumerable<T>> NoneIfEmpty<T>(
            this IEnumerable<T> enumerable)
        {
            enumerable.AssertNotNull(nameof(enumerable));

            if (enumerable.Any())
            {
                return Option.Some(enumerable);
            }
            else
            {
                return Option.None<IEnumerable<T>>();
            }
        }
    }

}