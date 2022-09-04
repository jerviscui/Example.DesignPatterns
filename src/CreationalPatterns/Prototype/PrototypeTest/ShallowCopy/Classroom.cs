namespace PrototypeTest.ShallowCopy;

public class Classroom : ICloneable
{
    public Classroom(string name) => Name = name;

    public string Name { get; set; }

    /// <inheritdoc />
    public object Clone() => new Classroom((string)Name.Clone());
}
