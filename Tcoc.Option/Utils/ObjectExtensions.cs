using System;

namespace Tcoc.OptionType.Utils
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