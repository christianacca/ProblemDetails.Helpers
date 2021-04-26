using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers
{
    public static class ProblemDetailsExtensions
    {
        /// <summary>
        /// Copy the fields defined in the RFC-7807 spec from <paramref name="source"/> to <paramref name="target"/>
        /// </summary>
        public static void CopyStandardFieldsTo(this MvcProblemDetails source, MvcProblemDetails target)
        {
            target.Type = source.Type;
            target.Title = source.Title;
            target.Instance = source.Instance;
            target.Status = source.Status;
            target.Detail = source.Detail;
        }

        /// <summary>
        /// Attempts to remove the entry in <see cref="MvcProblemDetails.Extensions"/> matching the
        /// <paramref name="key"/>, returning the value of the entry removed, if any.
        /// </summary>
        public static object RemoveExtensionValue(this MvcProblemDetails problem, string key)
        {
            return DoRemoveExtensionValue(problem, key) ?? DoRemoveExtensionValue(problem, PascalCase(key));
        }

        private static object DoRemoveExtensionValue(MvcProblemDetails problem, string key)
        {
            if (!problem.Extensions.ContainsKey(key)) return null;

            var value = problem.Extensions[key];
            problem.Extensions.Remove(key);
            return value;
        }

        private static string PascalCase(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
