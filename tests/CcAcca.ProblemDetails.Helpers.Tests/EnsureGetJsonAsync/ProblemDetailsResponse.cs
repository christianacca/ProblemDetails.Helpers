using System.Threading;
using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsureGetJsonAsync
{
    public class ProblemDetailsResponse : ProblemDetailsResponseBase
    {
        public ProblemDetailsResponse()
        {
            // given
            Client = New.HttpClient.Returning(Problem);
        }

        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client.EnsureGetJsonAsync<ExampleModel>(Url, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client.EnsureGetJsonAsync<ExampleModel>(Url, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client.EnsureGetJsonAsync<ExampleModel>(Uri, Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Type()
        {
            // when
            async Task Act() => await Client.EnsureGetJsonAsync<ExampleModel>(Uri, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }


        [Fact]
        public async void String_Url_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsureGetJsonAsync(Url, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void String_Url_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client.EnsureGetJsonAsync(Url, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }


        [Fact]
        public async void Uri_JsonSerializerOptions_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client
                .EnsureGetJsonAsync(Uri, typeof(ExampleModel), Options, CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_CancellationToken_Result_Object()
        {
            // when
            async Task Act() => await Client.EnsureGetJsonAsync(Uri, typeof(ExampleModel), CancellationToken.None);

            // then
            await AssertThrows(Act, Problem);
        }
    }
}
