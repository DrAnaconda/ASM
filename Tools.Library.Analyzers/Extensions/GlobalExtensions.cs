// ReSharper disable once CheckNamespace
namespace Tools.Library.Analyzers
{
    internal static class GlobalExtensions
    {
        public static int intToStr(this string str)
        {
            return int.Parse(str.TrimStart(new char[] { '0' }));
        }
    }
}