using System;
using System.Text.Json;
using System.Threading.Tasks;
using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Hellang.Middleware.ProblemDetails;
using Xunit;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests
{
    public class EnsureNotProblemDetailAsync
    {
        [Fact]
        public async void Should_Throw_On_ProblemDetails_Response()
        {
            // given
            var problem = New.ProblemDetails.BadRequest;
            var response = await New.HttpResponseMessage.Of(problem);

            // when
            Func<Task> act = async () => await response.EnsureNotProblemDetailAsync();

            // then
            (await act.Should().ThrowAsync<ProblemDetailsException>())
                .Which.Details.Should().BeEquivalentTo(problem);
        }

        [Fact]
        public async void Should_Not_Throw_When_Response_Has_No_Content()
        {
            // given
            var response = await New.HttpResponseMessage.Success();

            // when
            Func<Task> act = async () => await response.EnsureNotProblemDetailAsync();

            // then
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async void Should_Not_Throw_When_Not_ProblemDetails_Response()
        {
            // given
            var response = await New.HttpResponseMessage.EmptySuccess();

            // when
            Func<Task> act = async () => await response.EnsureNotProblemDetailAsync();

            // then
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async void Should_Rename_TraceId_To_CorrelationId()
        {
            // given
            const string traceId = "123";
            var problem = new MvcProblemDetails
            {
                Extensions =
                {
                    {"traceId", traceId}
                }
            };
            New.ProblemDetails.BadRequest.CopyStandardFieldsTo(problem);

            var response = await New.HttpResponseMessage.Of(problem);

            // when
            Func<Task> act = async () => await response.EnsureNotProblemDetailAsync();

            // then
            var expected = new MvcProblemDetails
            {
                Extensions =
                {
                    {"correlationId", traceId}
                }
            };
            problem.CopyStandardFieldsTo(expected);

            (await act.Should().ThrowAsync<ProblemDetailsException>())
                .Which.Details.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void CorrelationId_Should_Use_Configured_Casing()
        {
            // IMPORTANT: This is causing flaky tests as we're modifying static fields and yet xunit will run
            // tests is parallel and so the change to this static field will apply to those tests that are running
            // in parallel with this one!
            // todo: resolve test flake by making this test run NOT in parallel with other tests

            var originalSettings = JsonProblemDetailsConverter.SerializerOptions;
            try
            {
                // given
                JsonProblemDetailsConverter.SerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null // Pascal casing
                };
                const string traceId = "123";
                var problem = new MvcProblemDetails
                {
                    Extensions =
                    {
                        {"traceId", traceId}
                    }
                };
                New.ProblemDetails.BadRequest.CopyStandardFieldsTo(problem);

                var response = await New.HttpResponseMessage.Of(problem);

                // when
                Func<Task> act = async () => await response.EnsureNotProblemDetailAsync();

                // then
                (await act.Should().ThrowAsync<ProblemDetailsException>())
                    .Which.Details.Extensions.Should().ContainKey("CorrelationId");
            }
            finally
            {
                JsonProblemDetailsConverter.SerializerOptions = originalSettings;
            }
        }
    }
}
