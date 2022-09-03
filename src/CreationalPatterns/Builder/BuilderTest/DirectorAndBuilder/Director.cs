namespace BuilderTest.DirectorAndBuilder;

public class Director
{
    public void MakeSportsCar(IBuilder builder)
    {
        builder.SetSeats(2);
        builder.SetEngine(true);
        builder.SetGPS(false);
    }

    public void MakeElectricCar(IBuilder builder)
    {
        builder.SetSeats(4);
        builder.SetEngine(false);
        builder.SetGPS(true);
    }
}
