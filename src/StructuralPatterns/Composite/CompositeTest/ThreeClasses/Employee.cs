namespace CompositeTest;

public class Employee : HumanResource
{
    /// <inheritdoc />
    public override int CalculateSalary()
    {
        return Salary;
    }

    /// <inheritdoc />
    public Employee(long id, int salary) : base(id)
    {
        Salary = salary;
    }
}
