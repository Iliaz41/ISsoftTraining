public abstract class Classes
{
    protected string _description;

    protected Classes(string description)
    {
        _description = description;
    }
    public string Description
    {
        get => _description;
        set => _description = value;
    }
}

