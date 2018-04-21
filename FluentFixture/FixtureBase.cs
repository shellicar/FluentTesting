namespace FluentFixture
{
    public abstract class FixtureBase
    {

        protected IEntityBuilder<TEntity> Create<TEntity>()
        {
            var builder = new FixtureBuilder<TEntity>();
            return builder;
        }
    }
}