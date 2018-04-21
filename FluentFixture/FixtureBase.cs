namespace FluentFixture
{
    public abstract class FixtureBase
    {
        protected FixtureBuilder<TEntity> Create<TEntity>()
        {
            var builder = new FixtureBuilder<TEntity>();
            return builder;
        }
    }
}