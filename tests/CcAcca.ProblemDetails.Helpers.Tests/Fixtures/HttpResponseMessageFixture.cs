using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;

namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class HttpResponseMessageFixture
    {
        public static HttpResponseMessageFixture Instance { get; set; } = new HttpResponseMessageFixture();

        public async Task<HttpResponseMessage> Of<T>(T problem)
            where T : Microsoft.AspNetCore.Mvc.ProblemDetails
        {
            var mockHttp = new MockHttpMessageHandler();
            var content = JsonProblemDetailsConverter.Serialize(problem);
            mockHttp.When("https://whatever-url")
                .Respond(HttpStatusCode.BadRequest, HttpContentExtensions.ProblemDetailsMediaType, content);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://whatever-url");
            return await mockHttp.ToHttpClient().SendAsync(request);
        }

        public async Task<HttpResponseMessage> EmptySuccess()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://whatever-url").Respond(HttpStatusCode.OK);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://whatever-url");
            return await mockHttp.ToHttpClient().SendAsync(request);
        }

        public async Task<HttpResponseMessage> EmptyInternalServerError()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://whatever-url").Respond(HttpStatusCode.InternalServerError);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://whatever-url");
            return await mockHttp.ToHttpClient().SendAsync(request);
        }

        public async Task<HttpResponseMessage> Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://whatever-url").Respond(HttpStatusCode.OK, "application/json", "body");

            var request = new HttpRequestMessage(HttpMethod.Get, "https://whatever-url");
            return await mockHttp.ToHttpClient().SendAsync(request);
        }
    }
}
