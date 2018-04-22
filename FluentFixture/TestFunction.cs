namespace FluentFixture
{
    public delegate TResult TestFunction<in TFixture, out TResult>(TFixture fixture);
}