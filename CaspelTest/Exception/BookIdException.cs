namespace CaspelTest.Exception;

public class BookIdException : System.Exception
{
    public BookIdException(int id) : base($"{id} does not exist"){}
}