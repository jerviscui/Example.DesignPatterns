namespace TemplateTest;

internal class ConcreteClass1 : TemplateBase
{
    public int Executed { get; set; }

    /// <inheritdoc />
    protected override void Step1()
    {
        Executed = 10;
    }

    /// <inheritdoc />
    protected override bool Step2() => false;

    /// <inheritdoc />
    protected override void Step3() => Executed *= 3;

    /// <inheritdoc />
    protected override void Step4() => Executed *= 4;
}
