namespace FluentFixture
{
    public interface IEntityBuilder<TFixture>
    {
        TFixture Build();
        void AddMethod(Modify<TFixture> action);
        IEntityBuilder<TFixture> SetArguments(params object[] args);
    }
}