using System;
using System.Net.Http;
using System.Text.Json;

namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class SuccessResponseBase
    {
        protected const string Url = "https://whatever";
        protected static ExampleModel Model => ExampleModel.Instance;
        protected HttpClient Client { get; init; }
        protected JsonSerializerOptions Options { get; } = new();
        protected Uri Uri { get; } = new("https://whatever");
    }
}
