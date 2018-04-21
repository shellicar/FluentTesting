namespace FluentFixture
{
    class WhenResult<TEntity, TResult> : IWhenResult<TEntity, TResult>
    {
        public WhenResult(TEntity entity, TResult result)
        {
            Entity = entity;
            Result = result;
        }
        public TEntity Entity { get; }
        public TResult Result { get; }
    }
}