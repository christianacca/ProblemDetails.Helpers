namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class CustomProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public string StringField { get; set; }
        public int IntField { get; set; }
    }
}
