using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class ProblemDetailsFixture
    {
        public static ProblemDetailsFixture Instance { get; } = new();

        public MvcProblemDetails BadRequest { get; } = new()
        {
            Type = "https://httpstatuses.com/400",
            Title = "One or more validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Detail = "Some details that explains problem to user"
        };

        public Dictionary<string, string[]> ValidationErrors { get; } = new()
        {
            {"Reference", new[] {"The Reference field is required."}},
            {"AccountNumber", new[] {"The AccountNumber field is required."}}
        };

        public ValidationProblemDetails ValidationProblemDetails()
        {
            var problem = new ValidationProblemDetails(ValidationErrors);
            BadRequest.CopyStandardFieldsTo(problem);
            return problem;
        }

        public CustomProblemDetails CustomProblemDetailsWithExtensions()
        {
            var problem = new CustomProblemDetails
            {
                StringField = "string field value",
                IntField = 20,
                Extensions =
                {
                    {"s2", "value 2"},
                    {"i2", 30}
                }
            };
            BadRequest.CopyStandardFieldsTo(problem);
            return problem;
        }

        public MvcProblemDetails ProblemDetailsWithExtensions()
        {
            var problem = new MvcProblemDetails
            {
                Extensions =
                {
                    {"stringField", "string field value"},
                    {"intField", 20}
                }
            };
            BadRequest.CopyStandardFieldsTo(problem);
            return problem;
        }

        public CustomProblemDetails CustomProblemDetails()
        {
            var problem = new CustomProblemDetails
            {
                StringField = "string field value",
                IntField = 20
            };
            BadRequest.CopyStandardFieldsTo(problem);
            return problem;
        }
    }
}
