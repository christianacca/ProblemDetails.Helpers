using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CcAcca.ProblemDetails.Helpers
{
    /// <summary>
    ///     Extensions methods for fetching JSON and ensuring that the server response is successful (ie has a http
    ///     status code between 200-299)
    /// </summary>
    public static partial class HttpClientJsonExtensions
    {
        public static Task<object> EnsureGetJsonAsync(this HttpClient client, string requestUri, Type type,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return EnsureGetJsonAsyncCore(taskResponse, type, options, cancellationToken);
        }

        public static Task<object> EnsureGetJsonAsync(this HttpClient client, Uri requestUri, Type type,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return EnsureGetJsonAsyncCore(taskResponse, type, options, cancellationToken);
        }

        public static Task<TValue> EnsureGetJsonAsync<TValue>(this HttpClient client, string requestUri,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return EnsureGetJsonAsyncCore<TValue>(taskResponse, options, cancellationToken);
        }

        public static Task<TValue> EnsureGetJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return EnsureGetJsonAsyncCore<TValue>(taskResponse, options, cancellationToken);
        }

        public static Task<object> EnsureGetJsonAsync(this HttpClient client, string requestUri, Type type,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync(requestUri, type, null, cancellationToken);

        public static Task<object> EnsureGetJsonAsync(this HttpClient client, Uri requestUri, Type type,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync(requestUri, type, null, cancellationToken);

        public static Task<TValue> EnsureGetJsonAsync<TValue>(this HttpClient client, string requestUri,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync<TValue>(requestUri, null, cancellationToken);

        public static Task<TValue> EnsureGetJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync<TValue>(requestUri, null, cancellationToken);

        private static async Task<object> EnsureGetJsonAsyncCore(Task<HttpResponseMessage> taskResponse, Type type,
            JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            using var response = await taskResponse.ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(type, options, cancellationToken).ConfigureAwait(false);
        }

        private static async Task<T> EnsureGetJsonAsyncCore<T>(Task<HttpResponseMessage> taskResponse,
            JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            using var response = await taskResponse.ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<T>(options, cancellationToken).ConfigureAwait(false);
        }
    }
}
