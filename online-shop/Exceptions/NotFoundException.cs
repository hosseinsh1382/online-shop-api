namespace online_shop.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("NotFound")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}