namespace CompositeTest;

public class Goods : IPack
{
    /// <summary>
    /// Gets the price.
    /// </summary>
    public int Price { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Goods"/> class.
    /// </summary>
    /// <param name="price">The price.</param>
    public Goods(int price) => Price = price;

    /// <inheritdoc />
    public int CalculatePrice() => Price;
}
