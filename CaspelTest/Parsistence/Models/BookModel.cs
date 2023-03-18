namespace CaspelTest.Parsistence.Models;

///<summary>
/// Это модель, которая служит для взаимодействия С# с SqlServer
///</summary>
public class BookModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfCreate { get; set; }

    public ICollection<OrderModel> Orders { get; set; }
}