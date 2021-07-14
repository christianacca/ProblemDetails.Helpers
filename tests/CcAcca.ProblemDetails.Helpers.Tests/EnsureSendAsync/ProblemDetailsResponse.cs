using System.Net.Http;
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
        public async void ResponseMessage()
        {
            // When
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            async Task Act() => await Client.EnsureSendAsync(request);

            // then
            await AssertThrows(Act, Problem);
        }
    }
}
