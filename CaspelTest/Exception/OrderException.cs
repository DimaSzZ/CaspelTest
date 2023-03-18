namespace CaspelTest.Exception;

public class OrderException : System.Exception
{
    public OrderException() : base($"cart must not be empty") {}
}