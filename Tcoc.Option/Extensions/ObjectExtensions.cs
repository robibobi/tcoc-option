using System;

namespace Tcoc.OptionType.Extensions
{
    internal static class ObjectExtensions
    {
        public static void AssertNotNull(this object obj, string nameOfArgument)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameOfArgument);
            }
        }
    }
}