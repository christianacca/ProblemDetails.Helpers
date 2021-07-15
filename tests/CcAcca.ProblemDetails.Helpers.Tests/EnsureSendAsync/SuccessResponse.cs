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

        [Fact]
        public async void CancellationToken_ResponseMessage()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var response = await Client.EnsureSendAsync(request, CancellationToken.None);

            // then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void Result_Type()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result = await Client.EnsureSendAsync<ExampleModel>(request);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void JsonSerializerOptions_Result_Type()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result = await Client.EnsureSendAsync<ExampleModel>(request, Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result =
                await Client.EnsureSendAsync<ExampleModel>(request, Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void CancellationToken_Result_Type()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result =
                await Client.EnsureSendAsync<ExampleModel>(request, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Result_Object()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result = await Client.EnsureSendAsync(request, typeof(ExampleModel));

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void JsonSerializerOptions_Result_Object()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result = await Client.EnsureSendAsync(request, typeof(ExampleModel), Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result =
                await Client.EnsureSendAsync(request, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void CancellationToken_Result_Object()
        {
            // when
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var result = await Client.EnsureSendAsync(request, typeof(ExampleModel), CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }
    }
}
