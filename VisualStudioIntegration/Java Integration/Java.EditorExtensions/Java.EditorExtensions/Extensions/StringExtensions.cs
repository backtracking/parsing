using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Java.EditorExtensions
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitAndKeepSeparators(this string source, string[] separators)
        {
            var builder = new StringBuilder();
            foreach (var cur in source)
            {
                builder.Append(cur);
                if (separators.Contains(cur.ToString()))
                {
                    yield return builder.ToString();
                    builder.Length = 0;
                }
            }
            if (builder.Length > 0)
            {
                yield return builder.ToString();
            }
        }
    }
}
