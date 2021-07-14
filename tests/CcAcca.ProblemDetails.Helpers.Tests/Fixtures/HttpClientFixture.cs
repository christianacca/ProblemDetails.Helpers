using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text.Json;
using RichardSzalay.MockHttp;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class HttpClientFixture
    {
        public static HttpClientFixture Instance { get; set; } = new();

        public HttpClient Returning(ExampleModel model)
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://whatever").Respond(MediaTypeNames.Application.Json, JsonSerializer.Serialize(model));
            return mockHttp.ToHttpClient();
        }

        public HttpClient Returning(MvcProblemDetails problem)
        {
            Debug.Assert(problem.Status != null, "problem.Status != null");

            var mockHttp = new MockHttpMessageHandler();
            var content = JsonProblemDetailsConverter.Serialize(problem);
            mockHttp.When("https://whatever")
                .Respond((HttpStatusCode) problem.Status.Value, HttpContentExtensions.ProblemDetailsMediaType, content);
            return mockHttp.ToHttpClient();
        }
    }
}
