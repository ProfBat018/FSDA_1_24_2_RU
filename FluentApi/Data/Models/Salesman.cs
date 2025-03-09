namespace FluentApi.Data.Models;

public class Salesman
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Surname { get; set; } 
    public string PhoneNumber { get; set; }
    
    public ICollection<Sale> Sales { get; set; }
}