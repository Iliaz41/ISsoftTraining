public interface IMyStack<T>
{
    void Push(T x);

    T Pop();

    bool IsEmpty();

    IMyStack<T> Reverse();
}