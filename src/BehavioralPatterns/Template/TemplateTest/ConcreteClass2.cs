namespace TemplateTest;

internal class ConcreteClass2 : TemplateBase
{
    public int Executed { get; set; }

    /// <inheritdoc />
    protected override bool Step2() => true;

    /// <inheritdoc />
    protected override void Step3()
    {
        Executed = 3;
    }

    /// <inheritdoc />
    protected override void Step4()
    {
        Executed = 4;
    }
}
