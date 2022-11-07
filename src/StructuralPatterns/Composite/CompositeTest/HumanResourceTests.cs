namespace CompositeTest
{
    public class HumanResourceTests
    {
        private HumanResource GetHumanResource()
        {
            var root = new Department(1);

            //get department & employee
            root.AddSub(
                    new Department(2)
                        .AddSub(new Department(3)
                            .AddSub(new Employee(1, 10))
                            .AddSub(new Employee(2, 10))
                            .AddSub(new Employee(3, 10)))
                        .AddSub(new Department(4)
                            .AddSub(new Employee(4, 10)))
                        .AddSub(new Employee(5, 20)))
                .AddSub(new Employee(6, 30));

            return root;
        }

        [Fact]
        public void CalculateSalary_Test()
        {
            var resource = GetHumanResource();

            resource.CalculateSalary().ShouldBe(90);
        }
    }
}
