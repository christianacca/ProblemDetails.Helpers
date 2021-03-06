using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
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
        ///         added to <see cref="MvcProblemDetails.Extensions" /> as CorrelationId
        ///     </para>
        /// </remarks>
        public static async Task EnsureNotProblemDetailAsync(this HttpResponseMessage source,
            CancellationToken ct = default)
        {
            if (!source.Content.IsProblemDetails()) return;

            var problem = await source.Content.ReadAsProblemDetailsAsync(ct).ConfigureAwait(false);

            // rename so that when our problem is rethrown, that the hosting app will add it's own
            // traceId for the current process.
            var traceId = problem.RemoveExtensionValue("traceId");
            if (traceId != null)
            {
                problem.Extensions[GetExtensionValueKey("correlationId")] = traceId;
            }

            // Disposing the content should help users: If users call EnsureNotProblemDetailAsync(), an exception is
            // thrown if the response is a ProblemDetails. I.e. the behavior is similar to a failed request (e.g.
            // connection failure). Users don't expect to dispose the content in this case: If an exception is
            // thrown, the object is responsible fore cleaning up its state.
            if (source.Content != null)
            {
                source.Content.Dispose();
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
        ///         added to <see cref="MvcProblemDetails.Extensions" /> as CorrelationId
        ///     </para>
        /// </remarks>
        public static async Task EnsureSuccessAsync(this HttpResponseMessage source, CancellationToken ct = default)
        {
            if (source.Content.IsProblemDetails())
            {
                await source.EnsureNotProblemDetailAsync(ct).ConfigureAwait(false);
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
