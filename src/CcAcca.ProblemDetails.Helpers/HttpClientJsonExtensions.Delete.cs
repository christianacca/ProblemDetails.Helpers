using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CcAcca.ProblemDetails.Helpers
{
    public static partial class HttpClientJsonExtensions
    {
        public static async Task<HttpResponseMessage> EnsureDeleteAsync(
            this HttpClient client,
            string requestUri,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static async Task<HttpResponseMessage> EnsureDeleteAsync(
            this HttpClient client,
            Uri requestUri,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }
    }
}
