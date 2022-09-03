namespace BuilderTest.DirectorAndBuilder;

public interface IBuilder
{
    public int Seats { get; }

    public bool Engine { get; }

    public bool GPS { get; }

    public IBuilder SetSeats(int number);

    public IBuilder SetEngine(bool isGas);

    public IBuilder SetGPS(bool enable);
}
