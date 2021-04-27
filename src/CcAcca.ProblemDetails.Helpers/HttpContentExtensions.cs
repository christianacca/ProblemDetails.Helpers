using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers
{
    public static class HttpContentExtensions
    {
        public const string ProblemDetailsMediaType = "application/problem+json";

        private static readonly string ErrorsFieldKey = $"\"{nameof(ValidationProblemDetails.Errors)}\"";

        /// <summary>
        ///     Deserialize the content of the HTTP content as a <see cref="MvcProblemDetails" />. Returns <c>Null</c>
        ///     where there is the content is empty or does not have the ProblemDetails media type
        /// </summary>
        /// <remarks>
        ///     A "best-effort" attempt will be made to discover whether to deserialize to a
        ///     <see cref="ValidationProblemDetails" /> where there is an errors field that has the shape of the
        ///     <see cref="ValidationProblemDetails.Errors" /> dictionary. Otherwise the content will be
        ///     deserialized as a <see cref="MvcProblemDetails" /> instance
        /// </remarks>
        /// <param name="content">The content to deserialize</param>
        public static async Task<MvcProblemDetails> ReadAsProblemDetailsAsync(this HttpContent content)
        {
            if (!content.IsProblemDetails()) return await Task.FromResult<MvcProblemDetails>(null);

            var rawProblem = await content.ReadAsStringAsync();

            if (rawProblem.Contains(ErrorsFieldKey, StringComparison.OrdinalIgnoreCase))
            {
                ValidationProblemDetails validationProblem = null;

                try
                {
                    validationProblem = JsonProblemDetailsConverter.Deserialize<ValidationProblemDetails>(rawProblem);
                }
                catch (JsonSerializationException)
                {
                    // we're going to fallback so ignore this exception
                }

                return validationProblem == null || validationProblem.Errors.Count == 0
                    // the response wasn't really a ValidationProblemDetails, therefore fallback
                    ? JsonProblemDetailsConverter.Deserialize<MvcProblemDetails>(rawProblem)
                    : validationProblem;
            }

            return JsonProblemDetailsConverter.Deserialize(rawProblem);
        }

        /// <summary>
        ///     Deserialize the content of the HTTP content as a <see cref="MvcProblemDetails" />. Returns <c>Null</c>
        ///     where there is the content is empty or does not have the ProblemDetails media type
        /// </summary>
        /// <param name="content">The content to deserialize</param>
        /// <typeparam name="T">The target type to deserialize</typeparam>
        public static async Task<T> ReadAsProblemDetailsAsync<T>(this HttpContent content) where T : MvcProblemDetails
        {
            if (!content.IsProblemDetails()) return await Task.FromResult<T>(null);

            var rawProblem = await content.ReadAsStringAsync();
            return JsonProblemDetailsConverter.Deserialize<T>(rawProblem);
        }

        /// <summary>
        ///     Test that the Content-Type response header matches the media type of a ProblemDetails
        /// </summary>
        public static bool IsProblemDetails(this HttpContent content)
        {
            return content?.Headers.ContentType.MediaType == ProblemDetailsMediaType;
        }
    }
}
