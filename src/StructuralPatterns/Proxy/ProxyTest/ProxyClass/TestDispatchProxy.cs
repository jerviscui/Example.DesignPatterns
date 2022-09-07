using System.Reflection;

namespace ProxyTest.ProxyClass;

public class TestDispatchProxy : DispatchProxy
{
    public object? Wrap { get; set; }

    public Predicate<MethodInfo> Predicate { get; set; } = info => true;

    public Action<MethodInfo, object?[]>? OnBefore { get; set; }

    public Func<MethodInfo, object?[], object?, object?>? OnAfter { get; set; }

    public Func<MethodInfo, object?[], Exception, bool>? OnException { get; set; }

    /// <inheritdoc />
    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        if (targetMethod is null)
        {
            throw new ArgumentNullException(nameof(targetMethod));
        }

        args ??= Array.Empty<object?>();
        var obj = Wrap ?? this;

        if (!Predicate(targetMethod))
        {
            return targetMethod.Invoke(obj, args);
        }

        try
        {
            OnBefore?.Invoke(targetMethod, args);

            var result = targetMethod.Invoke(obj, args);

            var after = OnAfter?.Invoke(targetMethod, args, result);
            if (targetMethod.ReturnType.IsAssignableFrom(after?.GetType()))
            {
                return after;
            }

            return result;
        }
        catch (Exception e)
        {
            if (OnException?.Invoke(targetMethod, args, e) ?? false)
            {
                return null;
            }

            throw;
        }
    }
}
