using System;
using System.Net.Http;
using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Hellang.Middleware.ProblemDetails;
using Xunit;

namespace CcAcca.ProblemDetails.Helpers.Tests
{
    public class EnsureSuccessAsync
    {
        [Fact]
        public async void Should_Throw_ProblemDetailsException_On_ProblemDetails_Response()
        {
            // given
            var problem = New.ProblemDetails.BadRequest;
            var response = await New.HttpResponseMessage.Of(problem);

            // when
            Func<Task> act = async () => await response.EnsureSuccessAsync();

            // then
            (await act.Should().ThrowAsync<ProblemDetailsException>())
                .Which.Details.Should().BeEquivalentTo(problem);
        }

        [Fact]
        public async void Should_Throw_HttpResponseException_On_All_Other_Non_Success_Response()
        {
            // given
            var response = await New.HttpResponseMessage.EmptyInternalServerError();

            // when
            Func<Task> act = async () => await response.EnsureSuccessAsync();

            // then
            await act.Should().ThrowAsync<HttpRequestException>();
        }

        [Fact]
        public async void Should_Not_Throw_When_Success_Response()
        {
            // given
            var response = await New.HttpResponseMessage.EmptySuccess();

            // when
            Func<Task> act = async () => await response.EnsureSuccessAsync();

            // then
            await act.Should().NotThrowAsync();
        }
    }
}
