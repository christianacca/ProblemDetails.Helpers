using CcAcca.ProblemDetails.Helpers.Tests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests
{
    public class JsonProblemDetailsConverterTests
    {
        [Fact]
        public void Can_Serialize_ProblemDetails_With_Extensions()
        {
            // given
            var problem = New.ProblemDetails.ProblemDetailsWithExtensions();

            // when
            var actualJson = JsonProblemDetailsConverter.Serialize(problem);

            // then
            var expectedJson =
                $"{{\"type\":\"{problem.Type}\",\"title\":\"{problem.Title}\",\"status\":{problem.Status}," +
                $"\"detail\":\"{problem.Detail}\",\"stringField\":\"{problem.Extensions["stringField"]}\"" +
                $",\"intField\":{problem.Extensions["intField"]}}}";
            actualJson.Should().Be(expectedJson);
        }

        [Fact]
        public void Can_Deserialize_ProblemDetails_With_Extensions()
        {
            // given
            var problem = New.ProblemDetails.ProblemDetailsWithExtensions();
            var json = JsonProblemDetailsConverter.Serialize(problem);

            // when
            var actual = JsonProblemDetailsConverter.Deserialize(json);

            // then
            actual.Should().BeEquivalentTo(problem);
        }

        [Fact]
        public void Can_Serialize_Custom_ProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.CustomProblemDetails();

            // when
            var actualJson = JsonProblemDetailsConverter.Serialize(problem);

            // then
            var expectedJson =
                $"{{\"stringField\":\"{problem.StringField}\",\"intField\":{problem.IntField},\"type\":\"{problem.Type}\","
                + $"\"title\":\"{problem.Title}\",\"status\":{problem.Status},\"detail\":\"{problem.Detail}\"}}";
            actualJson.Should().Be(expectedJson);
        }

        [Fact]
        public void Can_Deserialize_Custom_ProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.CustomProblemDetails();
            var json = JsonProblemDetailsConverter.Serialize(problem);

            // when
            var actual = JsonProblemDetailsConverter.Deserialize<CustomProblemDetails>(json);

            // then
            actual.Should().BeEquivalentTo(problem);
        }

        [Fact]
        public void Can_Serialize_Custom_ProblemDetails_With_Extensions()
        {
            // given
            var problem = New.ProblemDetails.CustomProblemDetailsWithExtensions();

            // when
            var actualJson = JsonProblemDetailsConverter.Serialize(problem);

            // then
            var expectedJson =
                $"{{\"stringField\":\"{problem.StringField}\",\"intField\":{problem.IntField},\"type\":\"{problem.Type}\"" +
                $",\"title\":\"{problem.Title}\",\"status\":{problem.Status},\"detail\":\"{problem.Detail}\"," +
                $"\"s2\":\"{problem.Extensions["s2"]}\",\"i2\":{problem.Extensions["i2"]}}}";
            actualJson.Should().Be(expectedJson);
        }

        [Fact]
        public void Cannot_Fully_Deserialize_Custom_ProblemDetails_With_Extensions()
        {
            // given
            var problem = New.ProblemDetails.CustomProblemDetailsWithExtensions();
            var json = JsonProblemDetailsConverter.Serialize(problem);

            // when
            var actual = JsonProblemDetailsConverter.Deserialize<CustomProblemDetails>(json);

            // then
            var expected = new CustomProblemDetails
            {
                IntField = problem.IntField,
                StringField = problem.StringField
            };
            problem.CopyStandardFieldsTo(expected);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Can_Deserialize_ProblemDetails_With_Nested_Extensions()
        {
            // given
            var problem = New.ProblemDetails.ProblemDetailsWithExtensions();

            var json =
                $"{{\"type\":\"{problem.Type}\",\"title\":\"{problem.Title}\",\"status\":{problem.Status}" +
                $",\"detail\":\"{problem.Detail}\",\"intField\":{problem.Extensions["intField"]}" +
                $",\"extensions\":{{\"stringField\":\"{problem.Extensions["stringField"]}\"}}}}";

            // when
            var actual = JsonProblemDetailsConverter.Deserialize<MvcProblemDetails>(json);

            // then
            actual.Should().BeEquivalentTo(problem);
        }

        [Fact]
        public void Can_Deserialize_ProblemDetails_With_Extensions_To_CustomProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.ProblemDetailsWithExtensions();
            var json = JsonProblemDetailsConverter.Serialize(problem);

            // when
            var actual = JsonProblemDetailsConverter.Deserialize<CustomProblemDetails>(json);

            // then
            var expected = new CustomProblemDetails
            {
                IntField = (int) problem.Extensions["intField"],
                StringField = (string) problem.Extensions["stringField"]
            };
            problem.CopyStandardFieldsTo(expected);
            actual.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void Can_Serialize_ValidationProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.ValidationProblemDetails();

            // when
            var actualJson = JsonProblemDetailsConverter.Serialize(problem);

            // then
            var validationJson =
                $"{{\"Reference\":[\"{problem.Errors["Reference"][0]}\"],\"AccountNumber\":[\"{problem.Errors["AccountNumber"][0]}\"]}}";
            var expectedJson =
                $"{{\"type\":\"{problem.Type}\",\"title\":\"{problem.Title}\",\"status\":{problem.Status}," +
                $"\"detail\":\"{problem.Detail}\",\"errors\":{validationJson}}}";
            actualJson.Should().Be(expectedJson);
        }

        [Fact]
        public void Can_Deserialize_ValidationProblemDetails()
        {
            // given
            var problem = New.ProblemDetails.ValidationProblemDetails();
            var json = JsonProblemDetailsConverter.Serialize(problem);

            // when
            var actual = JsonProblemDetailsConverter.Deserialize<ValidationProblemDetails>(json);

            // then
            actual.Should().BeEquivalentTo(problem);
        }


        [Fact]
        public void Can_Serialize_ValidationProblemDetails_With_Extensions()
        {
            // given
            var problem = New.ProblemDetails.ValidationProblemDetails();
            problem.Extensions["looseKey"] = 123;

            // when
            var actualJson = JsonProblemDetailsConverter.Serialize(problem);

            // then
            var validationJson =
                $"{{\"Reference\":[\"{problem.Errors["Reference"][0]}\"],\"AccountNumber\":[\"{problem.Errors["AccountNumber"][0]}\"]}}";
            var expectedJson =
                $"{{\"type\":\"{problem.Type}\",\"title\":\"{problem.Title}\",\"status\":{problem.Status}," +
                $"\"detail\":\"{problem.Detail}\",\"looseKey\":123,\"errors\":{validationJson}}}";
            actualJson.Should().Be(expectedJson);
        }
    }
}
