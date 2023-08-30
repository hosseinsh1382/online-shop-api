namespace online_shop.Exceptions;

public class NotEnoughtCreditException:Exception
{
    public NotEnoughtCreditException() : base("Not Enough Credit")
    {
    }

    public NotEnoughtCreditException(string? message) : base(message)
    {
    }
}