namespace MementoTest
{
    public class EditorTest
    {
        [Fact]
        public void Test()
        {
            var text = "message";
            var editor = new Editor(text);
            var history = new History();
            history.Push(editor.CreateSnapshot());

            editor.Text = "new message";

            var snapshot = history.Pop();
            snapshot.ShouldNotBeNull();
            editor.Restore(snapshot);

            editor.Text.ShouldBe(text);
        }
    }
}
