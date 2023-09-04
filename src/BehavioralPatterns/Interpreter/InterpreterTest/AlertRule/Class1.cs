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

internal interface IRuleExpression
{
    public bool Interpreter(Dictionary<string, long> settings);
}

internal class GreaterThanExpression : IRuleExpression
{
    private readonly string _config;

    private readonly long _value;

    public GreaterThanExpression(string config, long value)
    {
        _config = config;
        _value = value;
    }

    public GreaterThanExpression(string rule)
    {
        if (!IsGreaterThanExpression(rule))
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        var arr = rule.Split('>', StringSplitOptions.RemoveEmptyEntries);
        _config = arr[0].Trim();
        _value = long.Parse(arr[1].Trim());
    }

    public static bool IsGreaterThanExpression(string rule)
    {
        return rule.Contains('>');
    }

    /// <inheritdoc />
    public bool Interpreter(Dictionary<string, long> settings)
    {
        if (settings.TryGetValue(_config, out var value))
        {
            return value > _value;
        }

        return false;
    }
}

internal class SmallerThanExpression : IRuleExpression
{
    private readonly string _config;

    private readonly long _value;

    public SmallerThanExpression(string config, long value)
    {
        _config = config;
        _value = value;
    }

    public SmallerThanExpression(string rule)
    {
        if (!IsSmallerThanExpression(rule))
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        var arr = rule.Split('<', StringSplitOptions.RemoveEmptyEntries);
        _config = arr[0].Trim();
        _value = long.Parse(arr[1].Trim());
    }

    public static bool IsSmallerThanExpression(string rule)
    {
        return rule.Contains('<');
    }

    /// <inheritdoc />
    public bool Interpreter(Dictionary<string, long> settings)
    {
        if (settings.TryGetValue(_config, out var value))
        {
            return value < _value;
        }

        return false;
    }
}

internal class EqualExpression : IRuleExpression
{
    private readonly string _config;

    private readonly long _value;

    public EqualExpression(string config, long value)
    {
        _config = config;
        _value = value;
    }

    public EqualExpression(string rule)
    {
        if (!IsEqualExpression(rule))
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        var arr = rule.Split("==", StringSplitOptions.RemoveEmptyEntries);
        _config = arr[0].Trim();
        _value = long.Parse(arr[1].Trim());
    }

    public static bool IsEqualExpression(string rule)
    {
        return rule.Contains("==");
    }

    /// <inheritdoc />
    public bool Interpreter(Dictionary<string, long> settings)
    {
        if (settings.TryGetValue(_config, out var value))
        {
            return value == _value;
        }

        return false;
    }
}

internal class AndExpression : IRuleExpression
{
    private readonly List<IRuleExpression> _expressions = new();

    public AndExpression(List<IRuleExpression> expressions)
    {
        _expressions = expressions;
    }

    public AndExpression(string rule)
    {
        if (!IsAndExpression(rule))
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        var arr = rule.Split("&&", StringSplitOptions.RemoveEmptyEntries);

        if (arr.Length != 2)
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        foreach (var s in arr)
        {
            if (IsAndExpression(s))
            {
                _expressions.Add(new AndExpression(s.Trim()));
            }
            else if (GreaterThanExpression.IsGreaterThanExpression(s))
            {
                _expressions.Add(new GreaterThanExpression(s.Trim()));
            }
            else if (SmallerThanExpression.IsSmallerThanExpression(s))
            {
                _expressions.Add(new SmallerThanExpression(s.Trim()));
            }
            else if (EqualExpression.IsEqualExpression(s))
            {
                _expressions.Add(new EqualExpression(s.Trim()));
            }
            else
            {
                throw new ArgumentException("Invalid rule.", nameof(rule));
            }
        }
    }

    public static bool IsAndExpression(string rule)
    {
        return rule.Contains("&&");
    }

    /// <inheritdoc />
    public bool Interpreter(Dictionary<string, long> settings)
    {
        foreach (var left in _expressions)
        {
            if (!left.Interpreter(settings))
            {
                return false;
            }
        }

        return true;
    }
}

internal class OrExpression : IRuleExpression
{
    private readonly List<IRuleExpression> _expressions = new();

    private readonly List<AndExpression> _ands = new();

    public OrExpression(List<IRuleExpression> expressions)
    {
        _expressions = expressions;
    }

    public OrExpression(string rule)
    {
        if (!IsOrExpression(rule))
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        var arr = rule.Split("||", StringSplitOptions.RemoveEmptyEntries);

        if (arr.Length != 2)
        {
            throw new ArgumentException("Invalid rule.", nameof(rule));
        }

        foreach (var s in arr)
        {
            if (AndExpression.IsAndExpression(s))
            {
                _ands.Add(new AndExpression(s.Trim()));
            }
            else if (GreaterThanExpression.IsGreaterThanExpression(s))
            {
                _expressions.Add(new GreaterThanExpression(s.Trim()));
            }
            else if (SmallerThanExpression.IsSmallerThanExpression(s))
            {
                _expressions.Add(new SmallerThanExpression(s.Trim()));
            }
            else if (EqualExpression.IsEqualExpression(s))
            {
                _expressions.Add(new EqualExpression(s.Trim()));
            }
            else
            {
                throw new ArgumentException("Invalid rule.", nameof(rule));
            }
        }
    }

    public static bool IsOrExpression(string rule)
    {
        return rule.Contains("||");
    }

    /// <inheritdoc />
    public bool Interpreter(Dictionary<string, long> settings)
    {
        foreach (var and in _ands)
        {
            if (and.Interpreter(settings))
            {
                return true;
            }
        }

        foreach (var left in _expressions)
        {
            if (left.Interpreter(settings))
            {
                return true;
            }
        }

        return false;
    }
}
