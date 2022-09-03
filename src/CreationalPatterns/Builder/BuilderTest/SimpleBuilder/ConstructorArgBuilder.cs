namespace BuilderTest.SimpleBuilder;

public class ConstructorArgBuilder
{
    /// <summary>
    /// Builds this instance.
    /// </summary>
    /// <exception cref="System.ArgumentNullException">Arg</exception>
    public ConstructorArg Build()
    {
        if (Arg is null)
        {
            throw new ArgumentNullException(nameof(Arg));
        }

        return new ConstructorArg(this);
    }

    public bool IsRef { get; private set; }

    public Type? Type { get; private set; }

    public object? Arg { get; private set; }

    /// <summary>
    /// Sets the is reference.
    /// </summary>
    /// <param name="isRef">if set to <c>true</c> [is reference].</param>
    /// <exception cref="System.ArgumentNullException">
    /// Arg
    /// or
    /// Type
    /// </exception>
    public ConstructorArgBuilder SetIsRef(bool isRef)
    {
        if (isRef)
        {
            Arg = "arg is string";
        }
        else
        {
            if (Arg is null)
            {
                throw new ArgumentNullException(nameof(Arg));
            }

            if (Type is null)
            {
                throw new ArgumentNullException(nameof(Type));
            }
        }

        IsRef = isRef;

        return this;
    }

    /// <summary>
    /// Sets the type.
    /// </summary>
    /// <param name="type">The type.</param>
    public ConstructorArgBuilder SetType(Type type)
    {
        Type = type;

        return this;
    }

    /// <summary>
    /// Sets the argument.
    /// </summary>
    /// <param name="arg">The argument.</param>
    public ConstructorArgBuilder SetArg(object arg)
    {
        Arg = arg;

        return this;
    }
}
