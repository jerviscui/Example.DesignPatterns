namespace FacadeTest;

public interface IStock
{
    /// <summary>
    /// Adds the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    public void Add(int count);

    /// <summary>
    /// Subtracts the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    public void Subtract(int count);
}

public class StockService : IStock
{
    /// <inheritdoc />
    public void Add(int count)
    {
    }

    /// <inheritdoc />
    public void Subtract(int count)
    {
    }
}
