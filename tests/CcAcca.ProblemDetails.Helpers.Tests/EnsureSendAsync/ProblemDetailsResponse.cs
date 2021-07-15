using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsureSendAsync
{
    public class ProblemDetailsResponse : ProblemDetailsResponseBase
    {
        public ProblemDetailsResponse()
        {
            // given
            Client = New.HttpClient.Returning(Problem);
        }

        [Fact]
        public async void Options_CancellationToken_ResponseMessage()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client
                .EnsureSendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void CancellationToken_ResponseMessage()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client.EnsureSendAsync(request, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Options_CancellationToken_Return_Type()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client
                .EnsureSendAsync<ExampleModel>(request, new JsonSerializerOptions(), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void CancellationToken_Return_Type()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client.EnsureSendAsync<ExampleModel>(request, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Options_CancellationToken_Return_Object()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client
                .EnsureSendAsync(request, typeof(ExampleModel), new JsonSerializerOptions(), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void CancellationToken_Return_Object()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client.EnsureSendAsync(request, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }
    }
}
