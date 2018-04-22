namespace FluentFixture
{
    public delegate void TestAction<in TFixture>(TFixture fixture);
}