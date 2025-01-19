public class Person
{
    public readonly string Name;
    public int Turns { get; set; }

    internal Person(string name, int starterturns)
    {
        Name = name;
        Turns = starterturns;

    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}