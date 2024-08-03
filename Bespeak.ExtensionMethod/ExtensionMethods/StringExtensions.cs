namespace Bespeak.ExtensionMethod.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces new line with a space (" ")
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceNewLineWithSpace(this string @str)
        {
            return str.Replace("\r\n", " ").Replace("\n", " ");
        }
    }
}
