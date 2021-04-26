using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests
{
    public class TypedReadAsProblemDetailsAsync
    {
        [Fact]
        public async void Should_Return_Null_When_Response_Has_No_Content()
        {
            // given
            var response = await New.HttpResponseMessage.Success();

            // when
            var problem = await response.Content.ReadAsProblemDetailsAsync<CustomProblemDetails>();

            // then
            problem.Should().BeNull();
        }

        [Fact]
        public async void Should_Return_Null_When_Not_ProblemDetails_Response()
        {
            // given
            var response = await New.HttpResponseMessage.EmptySuccess();

            // when
            var problem = await response.Content.ReadAsProblemDetailsAsync<CustomProblemDetails>();

            // then
            problem.Should().BeNull();
        }

        [Fact]
        public async void Should_Deserialize_To_Requested_ProblemDetails_Type()
        {
            // given
            var problem = New.ProblemDetails.CustomProblemDetails();
            var response = await New.HttpResponseMessage.Of(problem);

            // when
            CustomProblemDetails actual = await response.Content.ReadAsProblemDetailsAsync<CustomProblemDetails>();

            // then
            actual.Should().BeEquivalentTo(problem);
        }
    }
}
