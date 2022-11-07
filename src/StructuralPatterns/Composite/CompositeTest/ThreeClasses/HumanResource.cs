namespace CompositeTest;

public abstract class HumanResource
{
    protected HumanResource(long id) => Id = id;

    protected long Id { get; }

    protected int Salary { get; set; }

    public abstract int CalculateSalary();
}
