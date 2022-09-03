namespace BuilderTest.DirectorAndBuilder;

public class CarBuilder : IBuilder
{
    /// <inheritdoc />
    public int Seats { get; private set; }

    /// <inheritdoc />
    public bool Engine { get; private set; }

    /// <inheritdoc />
    public bool GPS { get; private set; }

    /// <inheritdoc />
    public IBuilder SetSeats(int number)
    {
        Seats = number;

        return this;
    }

    /// <inheritdoc />
    public IBuilder SetEngine(bool isGas)
    {
        Engine = isGas;

        return this;
    }

    /// <inheritdoc />
    public IBuilder SetGPS(bool enable)
    {
        GPS = enable;

        return this;
    }

    public Car Build()
    {
        return new Car(this);
    }
}

public class Car
{
    public Car(IBuilder builder)
    {
        Seats = builder.Seats;
        Engine = builder.Engine;
        GPS = builder.GPS;
    }

    public int Seats { get; }

    public bool Engine { get; }

    public bool GPS { get; }
}
