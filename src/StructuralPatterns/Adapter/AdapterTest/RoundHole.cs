namespace AdapterTest;

public class RoundHole
{
    public RoundHole(double radius) => Radius = radius;

    public double Radius { get; }

    public bool Fits(RoundPeg peg)
    {
        return peg.Radius <= Radius;
    }
}
