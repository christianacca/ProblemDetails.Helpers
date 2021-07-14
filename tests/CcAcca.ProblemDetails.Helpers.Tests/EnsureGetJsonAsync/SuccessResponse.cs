using System.Net.Http.Json;
using System.Threading;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsureGetJsonAsync
{
    public class SuccessResponse : SuccessResponseBase
    {
        public SuccessResponse()
        {
            // given
            Client = New.HttpClient.Returning(Model);
        }

        [Fact]
        public async void String_Url_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Url);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Url, Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Url, Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Url, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void Uri_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Uri);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Uri, Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Uri, Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Type()
        {
            // when
            var result = await Client.EnsureGetJsonAsync<ExampleModel>(Uri, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void String_Url_Result_Object()
        {
            // when
            var result = await Client.EnsureGetJsonAsync(Url, typeof(ExampleModel));

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_Result_Object()
        {
            // when
            var result = await Client.EnsureGetJsonAsync(Url, typeof(ExampleModel), Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            var result = await Client
                .EnsureGetJsonAsync(Url, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Object()
        {
            // when
            var result = await Client.EnsureGetJsonAsync(Url, typeof(ExampleModel), CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void Uri_Result_Object()
        {
            // when
            var result = await Client.EnsureGetJsonAsync(Uri, typeof(ExampleModel));

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_Result_Object()
        {
            // when
            var result = await Client.EnsureGetJsonAsync(Uri, typeof(ExampleModel), Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            var result = await Client
                .EnsureGetJsonAsync(Uri, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Object()
        {
            // when
            var result = await Client.EnsureGetJsonAsync(Uri, typeof(ExampleModel), CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }
    }
}
