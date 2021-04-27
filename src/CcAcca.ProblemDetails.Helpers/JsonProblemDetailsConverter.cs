using System.Text.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers
{
    /// <summary>
    ///     Convenience class for serializing/deserializing <see cref="MvcProblemDetails" />
    /// </summary>
    /// <remarks>
    ///     Codifies sensible default configuration for the built-in JSON serializers, leaning on each of
    ///     their strengths. For example:
    ///     <list type="bullet">
    ///         <item>
    ///             using <see cref="System.Text.Json.JsonSerializer" /> for serialization as it
    ///             does a better job of serializing <see cref="MvcProblemDetails.Extensions" />.
    ///         </item>
    ///         <item>
    ///             using <see cref="Newtonsoft.Json.JsonConvert" /> for deserialization as it
    ///             does a better job of deserializing <see cref="MvcProblemDetails" />
    ///             in general.
    ///         </item>
    ///     </list>
    /// </remarks>
    public static class JsonProblemDetailsConverter
    {
        static JsonProblemDetailsConverter()
        {
            // note: copy of the code in new JsonOptions().JsonSerializerOptions to avoid more external dependencies
            SerializerOptions = new JsonSerializerOptions
            {
                // Limit the object graph we'll consume to a fixed depth. This prevents stackoverflow exceptions
                // from deserialization errors that might occur from deeply nested objects.
                // This value is the same for model binding and Json.Net's serialization.
                MaxDepth = 32,

                // We're using case-insensitive because there's a TON of code that there that does uses JSON.NET's default
                // settings (preserve case) - including the WebAPIClient. This worked when we were using JSON.NET + camel casing
                // because JSON.NET is case-insensitive by default.
                PropertyNameCaseInsensitive = true,

                // Use camel casing for properties
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // note: for some reason serializing *sub-classed* ProblemDetails does NOT ignore null property values
            // to keep consistency with the serialization behaviour of built-in ProblemDetails we're explicitly
            // configuring
            SerializerOptions.IgnoreNullValues = true;
        }

        public static JsonSerializerOptions SerializerOptions { get; internal set; }

        public static JsonSerializerSettings DeserializerSettings { get; } =
            JsonSerializerSettingsProvider.CreateSerializerSettings();

        public static MvcProblemDetails Deserialize(string json)
        {
            return Deserialize<MvcProblemDetails>(json);
        }

        public static T Deserialize<T>(string json) where T : MvcProblemDetails
        {
            var problem = JsonConvert.DeserializeObject<T>(json, DeserializerSettings);
            FlattenNestedExtensions(problem);
            return problem;
        }

        public static string Serialize<T>(T value) where T : MvcProblemDetails
        {
            return JsonSerializer.Serialize(value, SerializerOptions);
        }

        private static void FlattenNestedExtensions(MvcProblemDetails problem)
        {
            // a *sub-class* of a ProblemDetails or ValidationProblemDetails aren't associated
            // with special-case converters and so end up causing the Extensions property to be
            // serialized "as is" and ending up being added as an nested entry in
            // the Extensions property itself!
            // this is a workaround to flatten the extensions values into the Extensions property
            // for details of issue see: https://github.com/khellang/Middleware/issues/74
            if (!(problem.RemoveExtensionValue("extensions") is JObject unhandledExtensionValue)) return;

            foreach (var (key, value) in unhandledExtensionValue)
            {
                problem.Extensions[key] = value.ToObject(typeof(object));
            }
        }
    }
}
