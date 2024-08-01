namespace Bespeak.ExtensionMethod.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string MultilinePreserveContent(this string @str)
        {
            return str.Replace("\n", " ").Replace("\r", " ");
        }
    }
}
