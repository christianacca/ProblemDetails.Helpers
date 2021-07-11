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
        public static async Task<HttpResponseMessage> EnsurePostJsonAsync<TValue>(this HttpClient client,
            string requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .PostAsJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static async Task<HttpResponseMessage> EnsurePostJsonAsync<TValue>(this HttpClient client,
            Uri requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .PostAsJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static Task<HttpResponseMessage> EnsurePostJsonAsync<TValue>(this HttpClient client, string requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePostJsonAsync(requestUri, value, null, cancellationToken);

        public static Task<HttpResponseMessage> EnsurePostJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePostJsonAsync(requestUri, value, null, cancellationToken);

        public static async Task<TResult> EnsurePostJsonAsync<TValue, TResult>(
            this HttpClient client, string requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePostJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<TResult> EnsurePostJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri,
            TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePostJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        public static Task<TResult> EnsurePostJsonAsync<TValue, TResult>(this HttpClient client, string requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePostJsonAsync<TValue, TResult>(requestUri, value, null, cancellationToken);

        public static Task<TResult> EnsurePostJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePostJsonAsync<TValue, TResult>(requestUri, value, null, cancellationToken);
    }
}
