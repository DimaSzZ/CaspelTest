namespace CaspelTest.Parsistence.Models;

///<summary>
/// Это модель, которая служит для взаимодействия С# с SqlServer
///</summary>
public class OrderModel
{
    public int Id { get; set; }
    public DateTime DateOrder { get; set; }
    public ICollection<BookModel> OrderBooks { get; set; } = null!;
}