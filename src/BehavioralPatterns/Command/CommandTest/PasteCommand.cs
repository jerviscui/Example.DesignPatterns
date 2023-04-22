namespace CommandTest;

internal class PasteCommand : ICommand
{
    private readonly PasteReceiver _receiver;

    private readonly CopyContext _context;

    public PasteCommand(PasteReceiver receiver, CopyContext context)
    {
        _receiver = receiver;
        _context = context;
    }

    public Task ExecuteAsync()
    {
        _receiver.Paste(_context);
        return Task.CompletedTask;
    }
}
