using System.Threading;
using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsurePostJsonAsync
{
    public class ProblemDetailsResponse : ProblemDetailsResponseBase
    {
        public ProblemDetailsResponse()
        {
            // given
            Client = New.HttpClient.Returning(Problem);
        }


        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_ResponseMessage()
        {
            // When
            async Task Act() => await Client.EnsurePostJsonAsync(Url, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_ResponseMessage()
        {
            // when
            async Task Act() => await Client.EnsurePostJsonAsync(Url, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_ResponseMessage()
        {
            // when
            async Task Act() => await Client.EnsurePostJsonAsync(Uri, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_ResponseMessage()
        {
            // when
            async Task Act() => await Client.EnsurePostJsonAsync(Uri, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync<ExampleModel, ExampleModel>(Url, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync<ExampleModel, ExampleModel>(Url, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync<ExampleModel, ExampleModel>(Uri, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Type()
        {
            // when
            async Task Act() =>
                await Client.EnsurePostJsonAsync<ExampleModel, ExampleModel>(Uri, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }


        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync(Url, Model, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync(Url, Model, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }


        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync(Uri, Model, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePostJsonAsync(Uri, Model, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }
    }
}
