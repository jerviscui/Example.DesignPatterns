using PrototypeTest.DeepCopy;
using PrototypeTest.ShallowCopy;

namespace PrototypeTest;

public class DeepCopyTest
{
    [Fact]
    public void RefrenceTypeCopy_Test()
    {
        var building = new DeepBuilding("building", new[] { new Classroom("test1"), new Classroom("test2") });

        var clone = building.Clone();

        ReferenceEquals(clone.Classrooms[0], building.Classrooms[0]).ShouldBeFalse();
    }
}
