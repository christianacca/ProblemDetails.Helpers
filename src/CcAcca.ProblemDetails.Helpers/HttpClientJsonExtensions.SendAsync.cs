using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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

        /// <summary>
        ///     Send a HTTP request, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="request">The HTTP request message to send</param>
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
            CancellationToken cancellationToken) =>
            await client.EnsureSendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

        /// <summary>
        ///     Send a HTTP request and returns the JSON deserialized response body, throwing an exception when the
        ///     HTTP response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="request">The HTTP request message to send</param>
        /// <param name="options">
        ///     Options to control the behavior during deserialization. The default options are those specified
        ///     by <see cref="JsonSerializerDefaults.Web" />
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
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, <typeparamref name="TValue" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static async Task<TValue> EnsureSendAsync<TValue>(
            this HttpClient client,
            HttpRequestMessage request,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            using var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TValue>(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Send a HTTP request and returns the JSON deserialized response body, throwing an exception when the
        ///     HTTP response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="request">The HTTP request message to send</param>
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
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, <typeparamref name="TValue" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static Task<TValue> EnsureSendAsync<TValue>(
            this HttpClient client,
            HttpRequestMessage request,
            CancellationToken cancellationToken) => client.EnsureSendAsync<TValue>(request, null, cancellationToken);


        /// <summary>
        ///     Send a HTTP request and returns the JSON deserialized response body, throwing an exception when the
        ///     HTTP response is unsuccessful
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="request">The HTTP request message to send</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="options">
        ///     Options to control the behavior during deserialization. The default options are those specified
        ///     by <see cref="JsonSerializerDefaults.Web" />
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
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, the <paramref name="returnType" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static async Task<object> EnsureSendAsync(
            this HttpClient client,
            HttpRequestMessage request,
            Type returnType,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            using var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(returnType, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Send a HTTP request and returns the JSON deserialized response body, throwing an exception when the
        ///     HTTP response is unsuccessful
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="request">The HTTP request message to send</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
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
        /// <exception cref="JsonException">
        ///     Thrown when the JSON is invalid, the <paramref name="returnType" /> is not compatible with the JSON,
        ///     or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsureSendAsync(
            this HttpClient client,
            HttpRequestMessage request,
            Type returnType,
            CancellationToken cancellationToken) =>
            EnsureSendAsync(client, request, returnType, null, cancellationToken);
    }
}
