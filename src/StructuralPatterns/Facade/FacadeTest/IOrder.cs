namespace FacadeTest;

public interface IOrder
{
    /// <summary>
    /// Creates the order.
    /// </summary>
    public void CreateOrder();
}

public class OrderService : IOrder
{
    /// <inheritdoc />
    public void CreateOrder()
    {
    }
}
