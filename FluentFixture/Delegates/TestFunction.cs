namespace FluentFixture.Delegates
{
    public delegate TResult TestFunction<in TFixture, out TResult>(TFixture fixture);
}