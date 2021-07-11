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
        ///     Send a DELETE request to the specified Uri, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of
        ///     cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type
        ///     application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The request message was already sent by a <see cref="HttpClient" />
        ///     instance.
        /// </exception>
        public static async Task<HttpResponseMessage> EnsureDeleteAsync(
            this HttpClient client,
            string requestUri,
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            var response = await client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        ///     Send a DELETE request to the specified Uri, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of
        ///     cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type
        ///     application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException">
        ///     The request message was already sent by a <see cref="HttpClient" />
        ///     instance.
        /// </exception>
        public static async Task<HttpResponseMessage> EnsureDeleteAsync(
            this HttpClient client,
            Uri requestUri,
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            var response = await client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }
    }
}
