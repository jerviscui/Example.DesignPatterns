namespace BuilderTest.SimpleBuilder;

public class ConstructorArg
{
    public ConstructorArg(ConstructorArgBuilder builder)
    {
        IsRef = builder.IsRef;
        Type = builder.Type;
        Arg = builder.Arg!;
    }

    public bool IsRef { get; }

    public Type? Type { get; }

    public object Arg { get; }
}
