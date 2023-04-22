namespace CommandTest;

internal class CopyReceiver
{
    public void Copy(CopyContext context)
    {
        context.Compnent = "copied";
    }
}
