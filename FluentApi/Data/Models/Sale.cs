namespace FluentApi.Data.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    
    public int SalesmanId { get; set; }
    public Salesman Salesman { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
}