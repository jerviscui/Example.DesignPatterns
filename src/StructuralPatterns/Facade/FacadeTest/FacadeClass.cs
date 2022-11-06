namespace FacadeTest;

public class FacadeClass
{
    private readonly IOrder _order;

    private readonly IStock _stock;

    public FacadeClass()
    {
        _order = new OrderService();
        _stock = new StockService();
    }

    public void Sale()
    {
        _order.CreateOrder();
        _stock.Subtract(1);
    }
}
