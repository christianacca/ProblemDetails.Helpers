using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CcAcca.ProblemDetails.Helpers
{
        public static partial class HttpClientJsonExtensions
    {
        public static async Task<HttpResponseMessage> EnsurePutAsJsonAsync<TValue>(this HttpClient client, string requestUri, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            var response = await client.PutAsJsonAsync(requestUri, value, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static async Task<HttpResponseMessage> EnsurePutAsJsonAsync<TValue>(this HttpClient client, Uri requestUri, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            var response = await client.PutAsJsonAsync(requestUri, value, options, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static Task<HttpResponseMessage> EnsurePutAsJsonAsync<TValue>(this HttpClient client, string requestUri, TValue value, CancellationToken cancellationToken)
            => client.EnsurePutAsJsonAsync(requestUri, value, options: null, cancellationToken);

        public static Task<HttpResponseMessage> EnsurePutAsJsonAsync<TValue>(this HttpClient client, Uri requestUri, TValue value, CancellationToken cancellationToken)
            => client.EnsurePutAsJsonAsync(requestUri, value, options: null, cancellationToken);

        public static async Task<TResult> PutAsJsonAsync<TValue, TResult>(this HttpClient client, string requestUri, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            var response = await client.EnsurePutAsJsonAsync(requestUri, value, options, cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<TResult> PutAsJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri, TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            var response = await client.EnsurePutAsJsonAsync(requestUri, value, options, cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        public static Task<TResult> PutAsJsonAsync<TValue, TResult>(this HttpClient client, string requestUri, TValue value, CancellationToken cancellationToken)
            => client.PutAsJsonAsync<TValue, TResult>(requestUri, value, options: null, cancellationToken);

        public static Task<TResult> PutAsJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri, TValue value, CancellationToken cancellationToken)
            => client.PutAsJsonAsync<TValue, TResult>(requestUri, value, options: null, cancellationToken);

    }
}
