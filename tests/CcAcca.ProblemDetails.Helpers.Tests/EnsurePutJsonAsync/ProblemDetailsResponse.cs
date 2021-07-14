using System.Threading;
using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using Xunit;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsurePutJsonAsync
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
            async Task Act() => await Client.EnsurePutJsonAsync(Url, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_ResponseMessage()
        {
            // when
            async Task Act() => await Client.EnsurePutJsonAsync(Url, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_ResponseMessage()
        {
            // when
            async Task Act() => await Client.EnsurePutJsonAsync(Uri, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_ResponseMessage()
        {
            // when
            async Task Act() => await Client.EnsurePutJsonAsync(Uri, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Url, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Url, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync<ExampleModel, ExampleModel>(Uri, Model, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Type()
        {
            // when
            async Task Act() =>
                await Client.EnsurePutJsonAsync<ExampleModel, ExampleModel>(Uri, Model, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }


        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync(Url, Model, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync(Url, Model, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }


        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync(Uri, Model, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsurePutJsonAsync(Uri, Model, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }
    }
}
