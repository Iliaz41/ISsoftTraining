using System;

Key c = new Key(Octave.First, Note.C, Accidental.Sharp);
Console.WriteLine(c);

Key d = new Key(Octave.First, Note.D, Accidental.Flat);
Console.WriteLine(d);

Console.WriteLine(c.Equals(d));
Console.WriteLine(c.CompareTo(d));