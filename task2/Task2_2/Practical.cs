public class Practical : Classes
{
    private string _task;
    private string _solution;
    public Practical(string description, string task, string solution)
        : base(description)
    {
        _task = task;
        _solution = solution;
    }
    public string LinkOfTask
    {
        get => _task;
        set => _task = value;
    }
    public string LinkOfSolution
    {
        get => _solution;
        set => _solution = value;
    }
    public override string ToString()
    {
        return "Practical: \n\t\t\tdescription - "+ _description + "\n\t\t\tlink of task - " + _task + "\n\t\t\tlink of solution - " + _solution;
    }
}
