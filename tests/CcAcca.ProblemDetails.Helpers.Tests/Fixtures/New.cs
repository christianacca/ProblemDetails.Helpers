namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public static class New
    {
        public static HttpClientFixture HttpClient => HttpClientFixture.Instance;
        public static HttpResponseMessageFixture HttpResponseMessage => HttpResponseMessageFixture.Instance;
        public static ProblemDetailsFixture ProblemDetails => ProblemDetailsFixture.Instance;
    }
}
