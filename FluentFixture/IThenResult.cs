namespace FluentFixture
{
    public interface IThenResult<out TResult>
    {
        TResult Result { get; }
    }
}