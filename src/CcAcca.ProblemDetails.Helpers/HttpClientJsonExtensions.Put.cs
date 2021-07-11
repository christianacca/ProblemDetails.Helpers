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
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during serialization. The default options are those specified by
        ///     <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        public static async Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client,
            string requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            var response = await client
                .PutAsJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            await response.EnsureSuccessAsync(cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during serialization. The default options are those specified by
        ///     <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        public static Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client, string requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePutJsonAsync(requestUri, value, (JsonSerializerOptions) null, cancellationToken);

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, throwing an exception when the HTTP response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        public static Task<HttpResponseMessage> EnsurePutJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, CancellationToken cancellationToken) =>
            client.EnsurePutJsonAsync(requestUri, value, (JsonSerializerOptions) null, cancellationToken);


        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during serialization and deserialization. The default options are
        ///     those specified by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
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
        ///     Thrown when the response JSON is invalid, the <paramref name="returnType" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static async Task<object> EnsurePutJsonAsync<TValue>(
            this HttpClient client, string requestUri, TValue value, Type returnType,
            JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(returnType, options, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during serialization and deserialization. The default options are
        ///     those specified by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
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
        ///     Thrown when the response JSON is invalid, the <paramref name="returnType" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static async Task<object> EnsurePutJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, Type returnType, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync(returnType, options, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <typeparam name="TResult">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during serialization and deserialization. The default options are
        ///     those specified by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        ///     Thrown when the response JSON is invalid, <typeparamref name="TResult" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static async Task<TResult> EnsurePutJsonAsync<TValue, TResult>(
            this HttpClient client, string requestUri, TValue value, JsonSerializerOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <typeparam name="TResult">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="options">
        ///     Options to control the behavior during serialization and deserialization. The default options are
        ///     those specified by <see cref="JsonSerializerDefaults.Web" />
        /// </param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        ///     Thrown when the response JSON is invalid, <typeparamref name="TResult" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static async Task<TResult> EnsurePutJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri,
            TValue value, JsonSerializerOptions options = null, CancellationToken cancellationToken = default)
        {
            using var response = await client
                .EnsurePutJsonAsync(requestUri, value, options, cancellationToken)
                .ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<TResult>(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        ///     Thrown when the response JSON is invalid, the <paramref name="returnType" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsurePutJsonAsync<TValue>(this HttpClient client, string requestUri,
            TValue value, Type returnType, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync(requestUri, value, returnType, null, cancellationToken);

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="returnType">The type of the object to deserialize to and return.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        ///     Thrown when the response JSON is invalid, the <paramref name="returnType" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <paramref name="returnType" /> or its serializable members.
        /// </exception>
        public static Task<object> EnsurePutJsonAsync<TValue>(this HttpClient client, Uri requestUri,
            TValue value, Type returnType, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync(requestUri, value, returnType, null, cancellationToken);

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <typeparam name="TResult">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        ///     Thrown when the response JSON is invalid, <typeparamref name="TResult" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static Task<TResult> EnsurePutJsonAsync<TValue, TResult>(this HttpClient client, string requestUri,
            TValue value, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync<TValue, TResult>(requestUri, value, null, cancellationToken);

        /// <summary>
        ///     Send a PUT request to the specified Uri containing the <paramref name="value" /> serialized as JSON in
        ///     the request body, returning the JSON deserialized response body or throwing an exception when the HTTP
        ///     response is unsuccessful
        /// </summary>
        /// <typeparam name="TValue">The type of the value to serialize.</typeparam>
        /// <typeparam name="TResult">The target type to deserialize to.</typeparam>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <param name="value">The value to serialize.</param>
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
        ///     Thrown when the response JSON is invalid, <typeparamref name="TResult" /> is not compatible with the
        ///     response JSON, or when there is remaining data in the Stream.
        /// </exception>
        /// <exception cref="NotSupportedException">
        ///     There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" />
        ///     for <typeparamref name="TValue" /> or its serializable members.
        /// </exception>
        public static Task<TResult> EnsurePutJsonAsync<TValue, TResult>(this HttpClient client, Uri requestUri,
            TValue value, CancellationToken cancellationToken = default) =>
            client.EnsurePutJsonAsync<TValue, TResult>(requestUri, value, null, cancellationToken);
    }
}
