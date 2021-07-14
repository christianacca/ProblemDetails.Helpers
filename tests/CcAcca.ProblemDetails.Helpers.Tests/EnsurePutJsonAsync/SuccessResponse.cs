using System.Net.Http.Json;
using System.Threading;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsurePutJsonAsync
{
    public class SuccessResponse: SuccessResponseBase
    {
        public SuccessResponse()
        {
            // given
            Client = New.HttpClient.Returning(Model);
        }

        [Fact]
        public async void String_Url_ResponseMessage()
        {
            // when
            var response = await Client.EnsurePutJsonAsync(Url, Model);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_ResponseMessage()
        {
            // when
            var response =
                await Client.EnsurePutJsonAsync(Url, Model, Options);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_ResponseMessage()
        {
            // when
            var response = await Client
                .EnsurePutJsonAsync(Url, Model, Options, CancellationToken.None);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_CancellationToken_ResponseMessage()
        {
            // when
            var response = await Client.EnsurePutJsonAsync(Url, Model, CancellationToken.None);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_ResponseMessage()
        {
            // when
            var response = await Client.EnsurePutJsonAsync(Uri, Model);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_ResponseMessage()
        {
            // when
            var response = await Client.EnsurePutJsonAsync(Uri, Model, Options);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_ResponseMessage()
        {
            // when
            var response = await Client
                .EnsurePutJsonAsync(Uri, Model, Options, CancellationToken.None);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_CancellationToken_ResponseMessage()
        {
            // when
            var response = await Client.EnsurePutJsonAsync(Uri, Model, CancellationToken.None);
            var result = await response.Content.ReadFromJsonAsync<ExampleModel>();

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void String_Url_Result_Type()
        {
            // when
            var result =
                await Client.EnsurePutJsonAsync<ExampleModel, ExampleModel>(Url, Model);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_Result_Type()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Url, Model, Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Url, Model, Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Type()
        {
            // when
            var result =
                await Client.EnsurePutJsonAsync<ExampleModel, ExampleModel>(Url, Model,
                    CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void Uri_Result_Type()
        {
            // when
            var result =
                await Client.EnsurePutJsonAsync<ExampleModel, ExampleModel>(Uri, Model);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_Result_Type()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Uri, Model, Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Uri, Model, Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Type()
        {
            // when
            var result =
                await Client.EnsurePutJsonAsync<ExampleModel, ExampleModel>(Uri, Model,
                    CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void String_Url_Result_Object()
        {
            // when
            var result = await Client.EnsurePutJsonAsync(Url, Model, typeof(ExampleModel));

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_Result_Object()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync(Url, Model, typeof(ExampleModel), Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync(Url, Model, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Object()
        {
            // when
            var result = await Client
                .EnsurePutJsonAsync(Url, Model, typeof(ExampleModel), CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }


        [Fact]
        public async void Uri_Result_Object()
        {
            // when
            var result = await Client.EnsurePutJsonAsync(Uri, Model, typeof(ExampleModel));

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_Result_Object()
        {
            // when
            var result = await Client.EnsurePutJsonAsync(Uri, Model, typeof(ExampleModel),
                Options);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            var result = await Client.EnsurePutJsonAsync(Uri, Model, typeof(ExampleModel),
                Options, CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Object()
        {
            // when
            var result = await Client.EnsurePutJsonAsync(Uri, Model, typeof(ExampleModel),
                CancellationToken.None);

            // then
            result.Should().BeEquivalentTo(Model);
        }
    }
}
