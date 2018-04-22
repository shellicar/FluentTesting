namespace FluentFixture.Delegates
{
    public delegate void TestActionWithResult<in TFixture>(TFixture fixture, object previousResult);
}