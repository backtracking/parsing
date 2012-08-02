namespace Smartmobili.VisualStudio.Core
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    internal static class Argument
    {
        internal static void ThrowIfEmpty<T>(IList<T> collection, string paramName)
        {
            if ((collection == null) || (collection.Count == 0))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        internal static void ThrowIfNegative(int index, string paramName)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Argument is negative");
            }
        }

     
        public static void ThrowIfNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}

