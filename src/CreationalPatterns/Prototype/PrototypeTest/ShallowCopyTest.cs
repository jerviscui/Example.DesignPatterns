using PrototypeTest.ShallowCopy;

namespace PrototypeTest;

public class ShallowCopyTest
{
    [Fact]
    public void StringCopy_Test()
    {
        var classroom = new Classroom("test");

        var clone = classroom.Clone() as Classroom;
        clone!.Name = "new";

        clone.Name.ShouldNotBe(classroom.Name);
    }

    [Fact]
    public void RefrenceTypeCopy_Test()
    {
        var building = new Building("building", new[] { new Classroom("test1"), new Classroom("test2") });

        var clone = building.Clone();

        ReferenceEquals(clone.Classrooms[0], building.Classrooms[0]).ShouldBeTrue();
    }
}
