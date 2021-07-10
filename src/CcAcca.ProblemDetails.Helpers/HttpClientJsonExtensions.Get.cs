// Original source: https://github.com/dotnet/runtime/blob/556582d964cc21b82a88d7154e915076f6f9008e/src/libraries/System.Net.Http.Json/src/System/Net/Http/Json/HttpClientJsonExtensions.Get.cs
// Modification: replace `response.EnsureSuccessStatusCode();` with `await response.EnsureSuccessAsync();`

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CcAcca.ProblemDetails.Helpers
{
    /// <summary>
    ///     Contains the extensions methods for using JSON as the content-type in HttpClient.
    /// </summary>
    public static partial class HttpClientJsonExtensions
    {
        public static Task<object> GetFromJsonAsync(this HttpClient client, string requestUri, Type type,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return GetFromJsonAsyncCore(taskResponse, type, options, cancellationToken);
        }

        public static Task<object> GetFromJsonAsync(this HttpClient client, Uri requestUri, Type type,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return GetFromJsonAsyncCore(taskResponse, type, options, cancellationToken);
        }

        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, string requestUri,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return GetFromJsonAsyncCore<TValue>(taskResponse, options, cancellationToken);
        }

        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return GetFromJsonAsyncCore<TValue>(taskResponse, options, cancellationToken);
        }

        public static Task<object> GetFromJsonAsync(this HttpClient client, string requestUri, Type type,
            CancellationToken cancellationToken = default) =>
            client.GetFromJsonAsync(requestUri, type, null, cancellationToken);

        public static Task<object> GetFromJsonAsync(this HttpClient client, Uri requestUri, Type type,
            CancellationToken cancellationToken = default) =>
            client.GetFromJsonAsync(requestUri, type, null, cancellationToken);

        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, string requestUri,
            CancellationToken cancellationToken = default) =>
            client.GetFromJsonAsync<TValue>(requestUri, null, cancellationToken);

        public static Task<TValue> GetFromJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            CancellationToken cancellationToken = default) =>
            client.GetFromJsonAsync<TValue>(requestUri, null, cancellationToken);

        private static async Task<object> GetFromJsonAsyncCore(Task<HttpResponseMessage> taskResponse, Type type,
            JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            using (var response = await taskResponse.ConfigureAwait(false))
            {
                await response.EnsureSuccessAsync().ConfigureAwait(false);
                // Nullable forgiving reason:
                // GetAsync will usually return Content as not-null.
                // If Content happens to be null, the extension will throw.
                return await response.Content!.ReadFromJsonAsync(type, options, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        private static async Task<T> GetFromJsonAsyncCore<T>(Task<HttpResponseMessage> taskResponse,
            JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            using (var response = await taskResponse.ConfigureAwait(false))
            {
                await response.EnsureSuccessAsync().ConfigureAwait(false);
                // Nullable forgiving reason:
                // GetAsync will usually return Content as not-null.
                // If Content happens to be null, the extension will throw.
                return await response.Content!.ReadFromJsonAsync<T>(options, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
