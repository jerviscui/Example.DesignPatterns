namespace CommandTest;

internal class PasteReceiver
{
    public void Paste(CopyContext context)
    {
        var s = context.Compnent;
        context.Compnent = "pasted";
    }
}
