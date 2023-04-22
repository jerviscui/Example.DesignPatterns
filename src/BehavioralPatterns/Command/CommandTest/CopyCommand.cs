namespace CommandTest;

internal class CopyCommand : ICommand
{
    private readonly CopyReceiver _receiver;

    private readonly CopyContext _context;

    public CopyCommand(CopyReceiver receiver, CopyContext context)
    {
        _receiver = receiver;
        _context = context;
    }

    public Task ExecuteAsync()
    {
        _receiver.Copy(_context);
        return Task.CompletedTask;
    }
}
