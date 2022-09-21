public class Lecture : Classes
{
    private string _topic;
    public Lecture(string description, string topic)
        : base(description)
    {
        _topic = topic;
    }
    public string Topic
    {
        get => _topic;
        set => _topic = value;
    }
    public override string ToString()
    {
        return "Lecture: \n\t\t\tdescription - " + _description + "\n\t\t\ttopic - " + _topic;
    }
}

