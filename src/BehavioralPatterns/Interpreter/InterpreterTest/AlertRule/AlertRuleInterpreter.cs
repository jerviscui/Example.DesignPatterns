namespace InterpreterTest;

internal class AlertRuleInterpreter
{
    private readonly IRuleExpression _ruleExpression;

    public AlertRuleInterpreter(string rule)
    {
        if (OrExpression.IsOrExpression(rule))
        {
            _ruleExpression = new OrExpression(rule);
        }
        else if (AndExpression.IsAndExpression(rule))
        {
            _ruleExpression = new AndExpression(rule);
        }
        else if (GreaterThanExpression.IsGreaterThanExpression(rule))
        {
            _ruleExpression = new GreaterThanExpression(rule);
        }
        else if (SmallerThanExpression.IsSmallerThanExpression(rule))
        {
            _ruleExpression = new SmallerThanExpression(rule);
        }
        else if (EqualExpression.IsEqualExpression(rule))
        {
            _ruleExpression = new EqualExpression(rule);
        }
        else
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }
    }

    public bool Interpreter(Dictionary<string, long> settings)
    {
        return _ruleExpression.Interpreter(settings);
    }
}
