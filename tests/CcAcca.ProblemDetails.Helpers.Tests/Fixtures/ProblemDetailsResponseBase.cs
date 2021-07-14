using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Hellang.Middleware.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class ProblemDetailsResponseBase
    {
        protected const string Url = "https://whatever";
        protected static ExampleModel Model => ExampleModel.Instance;
        protected static Microsoft.AspNetCore.Mvc.ProblemDetails Problem => New.ProblemDetails.BadRequest;
        protected HttpClient Client { get; init; }
        protected JsonSerializerOptions Options { get; } = new();
        protected Uri Uri { get; } = new("https://whatever");

        protected static async Task AssertThrows(Func<Task> act, Microsoft.AspNetCore.Mvc.ProblemDetails problem)
        {
            (await act.Should().ThrowAsync<ProblemDetailsException>())
                .Which.Details.Should().BeEquivalentTo(problem);
        }
    }
}
