using System;

namespace task4_1
{
    public class ElementChangedEventArgs<T> : EventArgs
    {
        public T Old { get; }
        public T New { get; }

        public ElementChangedEventArgs(int index, T old, T @new) => (Old, New) = (old, @new);
    }
}
