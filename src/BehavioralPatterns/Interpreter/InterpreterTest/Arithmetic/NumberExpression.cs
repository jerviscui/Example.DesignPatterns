namespace InterpreterTest;

internal class NumberExpression : IExpression
{
    private readonly long _number;

    public NumberExpression(long number)
    {
        _number = number;
    }

    public NumberExpression(string number)
    {
        _number = long.Parse(number);
    }

    /// <inheritdoc />
    public long Interpreter() => _number;
}
