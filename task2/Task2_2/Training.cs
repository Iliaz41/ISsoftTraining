using System;
public class Training 
{
    private string _description;
    private Classes[] _classes;
    public Training(string description, params Classes[] classes)
    {
        _description = description;
        _classes = new Classes [classes.Length];
        for (int i = 0; i < classes.Length; i++)
        {
            _classes[i] = classes[i];
        }
    }
    public string Description
    {
        get => _description;
        set => _description = value;
    }
    public void Add(Classes classes)
    {
        Array.Resize(ref _classes, _classes.Length + 1);
        _classes[_classes.Length - 1] = classes;
    }
    public bool IsPractical()
    {
        foreach(Classes element in _classes)
        {
            if(element is Lecture)
            {
                return false;
            }
        }
        return true;
    }
    public Training Clone()
    {
        return new Training(_description, _classes);
    }
    public override string ToString()
    {
        string str = "Training: \n\tdescription - " + _description;
        str += "\n\tClasses: \n";
        foreach (Classes element in _classes)
        {
            str += "\t\t";
            str += element;
            str += "\n";
        }
        return str;
    }
}

