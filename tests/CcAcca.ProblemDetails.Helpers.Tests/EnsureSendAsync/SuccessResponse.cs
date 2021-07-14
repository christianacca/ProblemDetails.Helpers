using System.Net;
using System.Net.Http;
using System.Threading;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsureSendAsync
{
    public class SuccessResponse: SuccessResponseBase
    {
        public SuccessResponse()
        {
            // given
            Client = New.HttpClient.Returning(Model);
        }

        [Fact]
        public async void ResponseMessage()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var response = await Client.EnsureSendAsync(request);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void CompletionOption_CancellationToken_ResponseMessage()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var response = await Client.EnsureSendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
