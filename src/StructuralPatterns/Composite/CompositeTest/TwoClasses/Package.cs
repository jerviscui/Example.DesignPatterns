namespace CompositeTest;

public class Package : IPack
{
    private const int Price = 1;

    private List<IPack> Packs { get; } = new();

    /// <summary>
    /// Adds the pack.
    /// </summary>
    /// <param name="pack">The pack.</param>
    public void AddPack(IPack pack)
    {
        Packs.Add(pack);
    }

    /// <summary>
    /// Removes the pack.
    /// </summary>
    /// <param name="pack">The pack.</param>
    public void RemovePack(IPack pack)
    {
        Packs.Remove(pack);
    }

    /// <inheritdoc />
    public int CalculatePrice()
    {
        int price = Price;

        foreach (var pack in Packs)
        {
            price += pack.CalculatePrice();
        }

        return price;
    }
}
