namespace FluentFixture.Delegates
{
    public delegate void TestAction<in TFixture>(TFixture fixture);
}