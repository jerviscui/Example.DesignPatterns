namespace CommandTest;

internal class Button
{
    public string Name { get; set; }

    public Button(string name) => Name = name;

    private ICommand? _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public async Task OnClick()
    {
        if (_command is not null)
        {
            await _command.ExecuteAsync();
        }

        // do something else
    }
}
