namespace FluentFixture
{
    public interface IWhenInvoker
    {
        void When();
    }

    public interface IWhenInvoker<out TResult>
    {
        TResult When();
    }
}