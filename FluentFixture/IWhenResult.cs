namespace FluentFixture
{
    public interface IWhenResult<out TEntity, out TResult>
    {
        TEntity Entity { get; }
        TResult Result { get; }
    }
}