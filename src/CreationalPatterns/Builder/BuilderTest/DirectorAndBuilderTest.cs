using BuilderTest.DirectorAndBuilder;

namespace BuilderTest
{
    public class DirectorAndBuilderTest
    {
        [Fact]
        public void CarBuilder_Test()
        {
            var builder = new CarBuilder();
            var director = new Director();

            director.MakeSportsCar(builder);
            var car = builder.Build();

            car.Seats.ShouldBe(2);
        }

        [Fact]
        public void CarManualBuilder_Test()
        {
            var builder = new CarManualBuilder();
            var director = new Director();

            director.MakeSportsCar(builder);
            var car = builder.Build();

            car.Document.Contains("seats").ShouldBeTrue();
        }

        [Fact]
        public void Director_CreateCarAndManual_Test()
        {
            var builder = new CarBuilder();
            var director = new Director();

            director.MakeElectricCar(builder);
            var car = builder.Build();

            var manulBuilder = new CarManualBuilder();

            director.MakeElectricCar(manulBuilder);
            var manual = manulBuilder.Build();

            car.Engine.ShouldBeFalse();
            manual.Document.Contains("GPS").ShouldBeTrue();
        }
    }
}
