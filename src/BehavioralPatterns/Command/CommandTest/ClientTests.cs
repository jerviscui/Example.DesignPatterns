namespace CommandTest
{
    public class ClientTests
    {
        [Fact]
        public async Task Test()
        {
            //client for binding
            //create receiver
            var copyReceiver = new CopyReceiver();
            var pasteReceiver = new PasteReceiver();

            //create command and bingding with receiver
            var copyContext = new CopyContext();
            var copyCommand = new CopyCommand(copyReceiver, copyContext);
            var pasteCommand = new PasteCommand(pasteReceiver, copyContext);

            //create sender
            var copyBtn = new Button("Copy");
            copyBtn.SetCommand(copyCommand);

            var pasteBtn = new Button("Paste");
            pasteBtn.SetCommand(pasteCommand);

            await copyBtn.OnClick();
            copyContext.Compnent.ShouldBe("copied");

            await pasteBtn.OnClick();
            copyContext.Compnent.ShouldBe("pasted");
        }
    }
}
