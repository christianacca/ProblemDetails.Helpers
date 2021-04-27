namespace CcAcca.ProblemDetails.Helpers
{
    internal static class StringUtils
    {
        public static string PascalCase(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
