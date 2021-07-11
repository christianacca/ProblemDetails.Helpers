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
        public static async Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client,
            string requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .PutAsJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static async Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client,
            Uri requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client
                .PutAsJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        public static Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client, string requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePutJsonAsync(requestUri, value, (JsonSerializerOptions)null, cancellationToken);

        public static Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePutJsonAsync(requestUri, value, (JsonSerializerOptions)null, cancellationToken);


        public static async Task<object> EnsurePutJsonAsync<TValue>(
            this HttpClient client, string requestUri, TValue value, Type type, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(type, options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<object> EnsurePutJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, Type type, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(type, options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<TResult> EnsurePutJsonAsync<TValue, TResult>(
            this HttpClient client, string requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<TResult> EnsurePutJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri,
            TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        public static Task<object> EnsurePutJsonAsync<TValue>(this HttpClient client, string requestUri,
            TValue value, Type type, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync(requestUri, value, type, null, cancellationToken);

        public static Task<object> EnsurePutJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, Type type, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync(requestUri, value, type, null, cancellationToken);

        public static Task<TResult> EnsurePutJsonAsync<TValue, TResult>(this HttpClient client, string requestUri,
            TValue value, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync<TValue, TResult>(requestUri, value, null, cancellationToken);

        public static Task<TResult> EnsurePutJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri,
            TValue value, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync<TValue, TResult>(requestUri, value, null, cancellationToken);
    }
}
