namespace CcAcca.ProblemDetails.Helpers.Tests.Fixtures
{
    public class ExampleModel
    {
        public string StringProp { get; set; }
        public int Int32Prop { get; set; }

        public static ExampleModel Instance { get; } = new()
        {
            StringProp = "StringProp value",
            Int32Prop = 10
        };
    }
}
