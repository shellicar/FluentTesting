namespace FluentFixture
{
    class ThenResult<TResult> : IThenResult<TResult>
    {
        public ThenResult(TResult result)
        {
            Result = result;
        }

        public TResult Result { get; }
    }
}