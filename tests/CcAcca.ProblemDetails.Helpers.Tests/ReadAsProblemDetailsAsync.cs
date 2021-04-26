using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests
{
    public class ReadAsProblemDetailsAsync
    {
        [Fact]
        public async void Should_Return_Deserialized_ProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.BadRequest;
            var response = await New.HttpResponseMessage.Of(problem);

            // when
            var actual = await response.Content.ReadAsProblemDetailsAsync();

            // then
            actual.Should().BeEquivalentTo(problem);
        }

        [Fact]
        public async void Should_Return_Null_When_Response_Has_No_Content()
        {
            // given
            var response = await New.HttpResponseMessage.Success();

            // when
            var problem = await response.Content.ReadAsProblemDetailsAsync();

            // then
            problem.Should().BeNull();
        }

        [Fact]
        public async void Should_Return_Null_When_Not_ProblemDetails_Response()
        {
            // given
            var response = await New.HttpResponseMessage.EmptySuccess();

            // when
            var problem = await response.Content.ReadAsProblemDetailsAsync();

            // then
            problem.Should().BeNull();
        }

        [Fact]
        public async void When_Errors_Fields_Detected_Should_Return_ValidationProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.ValidationProblemDetails();
            var response = await New.HttpResponseMessage.Of(problem);

            // when
            var actual = await response.Content.ReadAsProblemDetailsAsync();

            // then
            actual.Should().BeOfType<ValidationProblemDetails>().And.BeEquivalentTo(problem);
        }

        [Fact]
        public async void When_Errors_Not_Suitable_As_ValidationProblemDetails_Should_Fallback_To_ProblemDetails()
        {
            // given
            var problem = new MvcProblemDetails
            {
                Extensions =
                {
                    {"errors", "Some details that are not ValidationProblemDetails"}
                }
            };
            New.ProblemDetails.BadRequest.CopyStandardFieldsTo(problem);

            var response = await New.HttpResponseMessage.Of(problem);

            // when
            var actual = await response.Content.ReadAsProblemDetailsAsync();

            // then
            actual.Should().NotBeOfType<ValidationProblemDetails>().And.BeEquivalentTo(problem);
        }
    }
}
