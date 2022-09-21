using System;

class MyStack<T> : IMyStack<T>
{
    private int index;
    private readonly T[] data;

    public MyStack()
    {
        data = new T[100];
    }

    public MyStack(int length)
    {
        if (length <= 0)
        {
            throw new InvalidOperationException("Incorrect input");
        }
        data = new T[length];
    }

    public IMyStack<T> Reverse()
    {
        MyStack<T> newStack = new(index);
        for (int i = index - 1; i >= 0; i--)
        {
            newStack.Push(data[i]);
        }
        return newStack;
    }

    public void Push(T x)
    {
        if (index == data.Length)
        {
            throw new InvalidOperationException("OverLoading of the stack!");
        }
        data[index++] = x;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The stack is empty!");
        }
        T element = data[--index];
        data[index] = default;
        return element;
    }

    public bool IsEmpty() => index == 0;

    public override string ToString()
    {
        string str = "Stack: \n";
        for (int i = index - 1; i >= 0; i--)
        {
            str = str + data[i] + "\n";
        }
        return str;
    }
}