using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers
{
    /// <summary>
    ///     Extensions methods for fetching JSON and ensuring that the server response is successful (ie has a http
    ///     status code between 200-299)
    /// </summary>
    public static partial class HttpClientJsonExtensions
    {
        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="options">
        ///     Options to control the behavior during deserialization. The default options are those specified
        ///     by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying
        ///     issue such as network connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, the <paramref name="returnType" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" /> for
        ///     <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsureGetJsonAsync(this HttpClient client, string requestUri, Type returnType,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return EnsureGetJsonAsyncCore(taskResponse, returnType, options, cancellationToken);
        }

        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="options">
        ///     Options to control the behavior during deserialization. The default options are those specified
        ///     by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying issue such as network
        ///     connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid,
        ///     the <paramref name="returnType" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsureGetJsonAsync(this HttpClient client, Uri requestUri, Type returnType,
            JsonSerializerOptions options, CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Task<HttpResponseMessage> taskResponse =
                client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            return EnsureGetJsonAsyncCore(taskResponse, returnType, options, cancellationToken);
        }

        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <typeparam name="TValue">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during deserialization. The default options are those specified
        ///     by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of
        ///     cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying
        ///     issue such as network connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, <typeparamref name="TValue" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
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

        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an exception
        ///     when the HTTP response is unsuccessful.
        /// </summary>
        /// <typeparam name="TValue">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during deserialization. The default options are those specified
        ///     by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type
        ///     application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying
        ///     issue such as network connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, <typeparamref name="TValue" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
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


        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying issue such as network
        ///     connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, the <paramref name="returnType" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsureGetJsonAsync(this HttpClient client, string requestUri, Type returnType,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync(requestUri, returnType, null, cancellationToken);

        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying issue such as network
        ///     connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, the <paramref name="returnType" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsureGetJsonAsync(this HttpClient client, Uri requestUri, Type returnType,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync(requestUri, returnType, null, cancellationToken);

        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <typeparam name="TValue">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying issue such as network
        ///     connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, <typeparamref name="TValue" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static Task<TValue> EnsureGetJsonAsync<TValue>(this HttpClient client, string requestUri,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync<TValue>(requestUri, null, cancellationToken);

        /// <summary>
        ///     Sends a GET request to the specified Uri and returns the JSON deserialized response body, throwing an
        ///     exception when the HTTP response is unsuccessful.
        /// </summary>
        /// <typeparam name="TValue">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="ProblemDetailsException">
        ///     The HTTP response is unsuccessful and the server response has media type application/problem+json.
        /// </exception>
        /// <exception cref="ArgumentNullException">When the <paramref name="client" /> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        ///     The requestUri must be an absolute URI or <see cref="HttpClient.BaseAddress" /> must be set.
        /// </exception>
        /// <exception cref="HttpRequestException">
        ///     The HTTP response is unsuccessful, or the request failed due to an underlying issue such as network
        ///     connectivity, DNS failure, server certificate validation or timeout.
        /// </exception>
        /// <exception cref="TaskCanceledException">The request failed due to timeout.</exception>
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, <typeparamref name="TValue" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static Task<TValue> EnsureGetJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            CancellationToken cancellationToken = default) =>
            client.EnsureGetJsonAsync<TValue>(requestUri, null, cancellationToken);

        private static async Task<object> EnsureGetJsonAsyncCore(Task<HttpResponseMessage> taskResponse,
            Type returnType,
            JsonSerializerOptions options, CancellationToken cancellationToken)
        {
            using var response = await taskResponse.ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(returnType, options, cancellationToken)
                .ConfigureAwait(false);
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
