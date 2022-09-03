using System.Text;

namespace BuilderTest.DirectorAndBuilder;

public class CarManualBuilder : IBuilder
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

    public CarManual Build()
    {
        return new CarManual(this);
    }
}

public class CarManual
{
    public CarManual(IBuilder builder)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"seats: {builder.Seats}");
        sb.AppendLine($"engine: {(builder.Engine ? "is" : "is not")} gas");
        if (builder.GPS)
        {
            sb.AppendLine("use GPS:");
        }

        Document = sb.ToString();
    }

    public string Document { get; }
}
