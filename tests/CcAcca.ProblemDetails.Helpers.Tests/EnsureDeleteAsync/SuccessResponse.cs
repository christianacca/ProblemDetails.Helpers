using System.Net;
using System.Threading;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsureDeleteAsync
{
    public class SuccessResponse: SuccessResponseBase
    {
        public SuccessResponse()
        {
            // given
            Client = New.HttpClient.Returning(Model);
        }

        [Fact]
        public async void String_Url()
        {
            // when
            var response = await Client.EnsureDeleteAsync(Url);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void String_Url_CancellationToken()
        {
            // when
            var response = await Client.EnsureDeleteAsync(Url, CancellationToken.None);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Uri_Url()
        {
            // when
            var response = await Client.EnsureDeleteAsync(Uri);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Uri_Url_CancellationToken()
        {
            // when
            var response = await Client.EnsureDeleteAsync(Uri, CancellationToken.None);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
