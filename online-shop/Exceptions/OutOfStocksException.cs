namespace online_shop.Exceptions;

public class OutOfStocksException:Exception
{
    public OutOfStocksException():base("Out of Stock")
    {
    }

    public OutOfStocksException(string? message) : base(message)
    {
    }
}