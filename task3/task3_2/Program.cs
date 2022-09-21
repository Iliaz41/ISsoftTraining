using System;

try
{
    MyStack<string> myStack = new MyStack<string>(5);

    myStack.Push("Hello");
    myStack.Push("World");
    myStack.Push("How");
    myStack.Push("Are");
    myStack.Push("You");

    Console.WriteLine(myStack.ToString());

    Console.WriteLine(myStack.Reverse().ToString());

    myStack.Pop();
    myStack.Pop();
    myStack.Pop();
    myStack.Pop();
    myStack.Pop();
    myStack.Pop();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}