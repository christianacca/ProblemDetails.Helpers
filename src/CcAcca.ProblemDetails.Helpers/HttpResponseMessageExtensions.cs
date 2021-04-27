using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers
{
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        ///     Throws a <see cref="ProblemDetailsException" /> if the <paramref name="source" /> represents a
        ///     ProblemDetails response
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Where the hosting app has added the <see cref="ProblemDetailsMiddleware" /> to it's middleware pipeline
        ///         then the <see cref="ProblemDetailsException" /> thrown here will be returned as the response for the
        ///         current request
        ///     </para>
        ///     <para>
        ///         Any TraceId field found on the deserialized ProblemDetails instance will be re-mapped and
        ///         added to <see cref="ProblemDetails.Extensions" /> as CorrelationId
        ///     </para>
        /// </remarks>
        public static async Task EnsureNotProblemDetailAsync(this HttpResponseMessage source)
        {
            if (!source.Content.IsProblemDetails()) return;

            var problem = await source.Content.ReadAsProblemDetailsAsync();

            // rename so that when our problem is rethrown, that the hosting app will add it's own
            // traceId for the current process.
            var traceId = problem.RemoveExtensionValue("traceId");
            if (traceId != null)
            {
                problem.Extensions[GetExtensionValueKey("correlationId")] = traceId;
            }

            throw new ProblemDetailsException(problem);
        }

        /// <summary>
        ///     Drop in replacement for <see cref="HttpResponseMessage.EnsureSuccessStatusCode" /> that throws a
        ///     <see cref="ProblemDetailsException" /> if the <paramref name="source" /> represents a ProblemDetails
        ///     response otherwise falling back to calling <see cref="HttpResponseMessage.EnsureSuccessStatusCode" />
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Where the hosting app has added the <see cref="ProblemDetailsMiddleware" /> to it's middleware pipeline
        ///         then the <see cref="ProblemDetailsException" /> thrown here will be returned as the response for the
        ///         current request
        ///     </para>
        ///     <para>
        ///         Any TraceId field found on the deserialized ProblemDetails instance will be re-mapped and
        ///         added to <see cref="ProblemDetails.Extensions" /> as CorrelationId
        ///     </para>
        /// </remarks>
        public static async Task EnsureSuccessAsync(this HttpResponseMessage source)
        {
            if (source.Content.IsProblemDetails())
            {
                await source.EnsureNotProblemDetailAsync();
            }
            else
            {
                source.EnsureSuccessStatusCode();
            }
        }

        private static string GetExtensionValueKey(string key)
        {
            return JsonProblemDetailsConverter.SerializerOptions.PropertyNamingPolicy == JsonNamingPolicy.CamelCase
                ? key
                : StringUtils.PascalCase(key);
        }
    }
}
