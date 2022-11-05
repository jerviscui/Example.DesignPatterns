namespace AdapterTest;

public class SquarePegAdapter : RoundPeg
{
    public SquarePeg SquarePeg { get; }

    /// <inheritdoc />
    public SquarePegAdapter(SquarePeg squarePeg) : base(GetRadius(squarePeg.Width)) => SquarePeg = squarePeg;

    private static double GetRadius(double width)
    {
        return Math.Sqrt(Math.Pow(width, 2) * 2) / 2;
    }
}
