using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using Xunit;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests.EnsureDeleteAsync
{
    public class ProblemDetailsResponse : ProblemDetailsResponseBase
    {
        public ProblemDetailsResponse()
        {
            // given
            Client = New.HttpClient.Returning(Problem);
        }

        [Fact]
        public async void String_Url()
        {
            // When
            async Task Act() => await Client.EnsureDeleteAsync(Url);

            // then
            await AssertThrows(Act, Problem);
        }

        [Fact]
        public async void Uri_Url()
        {
            // when
            async Task Act() => await Client.EnsureDeleteAsync(Uri);

            // then
            await AssertThrows(Act, Problem);
        }
    }
}
