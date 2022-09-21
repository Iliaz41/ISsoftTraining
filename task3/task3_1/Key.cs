using System;

public struct Key : IComparable<Key>
{
    private Octave _octave;
    private Note _note;
    private Accidental _accidental;

    public Key(Octave octave, Note note, Accidental accidental)
    {
        _octave = octave;
        _note = note;
        _accidental = accidental;
        if (!checkKey(octave, note, accidental))
        {
            Console.WriteLine("There is no such key");
        }
    }

    public bool checkKey(Octave octave, Note note, Accidental accidental)
    {
        if (accidental == Accidental.Flat && (note == Note.C || note == Note.F))
        {
            return false;
        }
        if (accidental == Accidental.Sharp && (note == Note.E || note == Note.B))
        {
            return false;
        }
        if (octave == Octave.Subcounter && (note != Note.A || note != Note.B))
        {
            return false;
        }
        if (octave == Octave.Fifth && note != Note.C && accidental != Accidental.WithOut)
        {
            return false;
        }
        return true;
    }

    public override string ToString() => $"Octave: {_octave}, Note: {_note}, Accidental: {_accidental}";

    public int CompareTo(Key other)
    {
        if (this.Equals(other))
        {
            return 0;
        }
        else if (_octave > other._octave)
        {
            return 1;
        }
        else if (_octave < other._octave)
        {
            return -1;
        }
        else
        {
            if (_note > other._note)
            {
                return 1;
            }
            else if (_note < other._note)
            {
                return -1;
            }
            else
            {
                if (_accidental > other._accidental)
                {
                    return 1;
                }
                else if (_accidental < other._accidental)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is Key key)
        {
            if (_octave == key._octave && _note == key._note && _accidental == key._accidental)
            {
                return true;
            }
            if (_octave == key._octave && (_accidental == Accidental.Sharp && key._accidental == Accidental.Flat && _note == key._note - 1))
            {
                return true;
            }
            if (_octave == key._octave && (_accidental == Accidental.Flat && key._accidental == Accidental.Sharp && _note == key._note + 1))
            {
                return true;
            }
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_octave, _note, _accidental);
    }
}