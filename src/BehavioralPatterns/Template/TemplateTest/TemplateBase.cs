namespace TemplateTest;

public abstract class TemplateBase
{
    public void TemplateMethod()
    {
        Step1();

        if (Step2())
        {
            Step3();
        }
        else
        {
            Step4();
        }
    }

    protected virtual void Step1()
    {
        //do sth.
    }

    protected abstract bool Step2();

    protected abstract void Step3();

    protected abstract void Step4();
}
