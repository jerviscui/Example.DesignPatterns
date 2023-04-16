namespace MementoTest
{
    public class ConcreteMementoTest
    {
        [Fact]
        public void Test()
        {
            var text = "message";
            var editor = new ConcreteOriginator(text);
            var history = new ConcreteCaretaker();
            history.Push(editor.CreateSnapshot());

            editor.Text = "new message";

            var snapshot = history.Pop();
            snapshot.ShouldNotBeNull();
            editor.Restore((ConcreteMemento)snapshot);

            editor.Text.ShouldBe(text);
        }
    }
}
