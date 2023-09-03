namespace MediatorTest
{
    public class MediatorTests
    {
        [Fact]
        public void Test()
        {
            var dialog = new AuthenticationDialog();

            dialog.OkBtn.Click();
            dialog.Title.Text.ShouldBe("must be checked");

            dialog.SaveChkBx.Check();
            dialog.OkBtn.Click();
            dialog.Title.Text.ShouldBe("OK");
        }
    }
}
