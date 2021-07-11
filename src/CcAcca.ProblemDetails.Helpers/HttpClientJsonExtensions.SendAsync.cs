using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers
{
    public static partial class HttpClientJsonExtensions
    {
        /// <summary>
        ///     Send a HTTP request, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="request">The HTTP request message to send</param>
        /// <param name="completionOption">
        ///     When the operation should complete (as soon as a response is available or after reading the whole
        ///     response content). Defaults to reading the whole response content
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     When the <paramref name="client" /> or <paramref name="request" /> is <c>null</c>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     The request message was already sent by a <see cref="HttpClient" /> instance.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying issue such as network
        ///     connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        public static async Task<HttpResponseMessage> EnsureSendAsync(
            this HttpClient client,
            HttpRequestMessage request,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead,
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            var response = await client.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }
    }
}
