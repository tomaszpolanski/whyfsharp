using System;
using System.Collections.Generic;
using System.Linq;

namespace WhyFSharp.CSharp
{
    public static class Extension
    {
        public static string Repeat(this string str, int count)
        {
            return string.Concat(Enumerable.Repeat(str, count));
        }


        public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue)
        {
            return source.Any() ? source.Max(selector) : defaultValue;
        }
    }
}
