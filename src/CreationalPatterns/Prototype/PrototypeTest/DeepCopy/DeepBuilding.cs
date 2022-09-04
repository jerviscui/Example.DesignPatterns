using PrototypeTest.ShallowCopy;

namespace PrototypeTest.DeepCopy;

public class DeepBuilding : ICloneable<Building>
{
    public DeepBuilding(string name, IEnumerable<Classroom> classrooms)
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
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = (Classroom)Classrooms[i].Clone();
        }

        return new Building(Name, arr);
    }

    /// <inheritdoc />
    object ICloneable.Clone() => Clone();
}
