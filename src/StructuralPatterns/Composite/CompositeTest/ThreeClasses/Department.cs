namespace CompositeTest;

public class Department : HumanResource
{
    /// <inheritdoc />
    public Department(long id) : base(id)
    {
    }

    private readonly List<HumanResource> _resources = new();

    public Department AddSub(HumanResource resource)
    {
        _resources.Add(resource);

        return this;
    }

    /// <inheritdoc />
    public override int CalculateSalary()
    {
        int salary = 0;
        foreach (var humanResource in _resources)
        {
            salary += humanResource.CalculateSalary();
        }

        Salary = salary;
        return salary;
    }
}
