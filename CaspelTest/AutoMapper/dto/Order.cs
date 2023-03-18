namespace CaspelTest.AutoMapper.dto;

public class Order
{
    public ICollection<Book> OrderBooks { get; set; } = null!;
    public DateTime DateOrder { get; set; }
}