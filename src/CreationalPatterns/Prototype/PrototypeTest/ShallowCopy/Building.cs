namespace PrototypeTest.ShallowCopy;

public class Building : ICloneable<Building>
{
    public Building(string name, IEnumerable<Classroom> classrooms)
    {
        Name = name;
        Classrooms = new List<Classroom>(classrooms);
    }

    public string Name { get; }

    public IList<Classroom> Classrooms { get; }

    /// <inheritdoc />
    public Building Clone()
    {
        var arr = new Classroom[Classrooms.Count];
        Classrooms.CopyTo(arr, 0);

        return new Building(Name, arr);
    }

    /// <inheritdoc />
    object ICloneable.Clone() => Clone();
}
