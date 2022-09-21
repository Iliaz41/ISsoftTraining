public class Matrix
{
    private int[] _elements;
    private readonly int _size;
    public Matrix(params int[] elements)
    {
        elements ??= new int[0];
        _elements = new int[elements.Length];
        for(int i = 0; i < elements.Length; i++)
        {
            _elements[i] = elements[i];
        }
        _size = elements.Length;
    }
    public int[] Elements
    {
        get => _elements;
    }
    public int Size
    {
        get => _size;
    }
    public int this[int i, int j]
    {
        get
        {
            if (i != j || i < 0 || j < 0 || i >= _size || j >= _size) 
            {
                return 0;
            }
            else 
            { 
                return _elements[i]; 
            }
        }
        set
        {
            if (i == j)
            {
                _elements[i] = value;
            }
            
        }
    }
    public int Track()
    {
        int sum = 0;
        foreach(int element in _elements)
        {
            sum += element;
        }
        return sum;
    }
    public override bool Equals(object obj)
    {
        if(obj is Matrix matrix && _size == matrix._size)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_elements[i] != matrix._elements[i])
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }           
    }
    public override string ToString()
    {
        string str = "";
        for(int i = 0; i < _size; i++)
        {
            for(int j = 0; j < _size; j++)
            {
                if (i == j)
                {
                    str += _elements[i];
                    str += " ";
                }
                else
                {
                    str += "0";
                    str += " ";
                }
            }
            str += "\n";
        }
        str = str + "Size: " + _size;
        return str;
    }
}

