namespace InterpreterTest;

internal class AdditionExpression : IExpression
{
    private readonly IExpression _exp1;

    private readonly IExpression _exp2;

    public AdditionExpression(IExpression exp1, IExpression exp2)
    {
        _exp1 = exp1;
        _exp2 = exp2;
    }

    /// <inheritdoc />
    public long Interpreter() => _exp1.Interpreter() + _exp2.Interpreter();
}
