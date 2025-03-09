
namespace FluentApi.Data.Models;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    
    public int CarTypeId { get; set; }
    public CarType CarType { get; set; }
    
    public int FuelTypeId { get; set; }
    public FuelType FuelType { get; set; } 
    
    public ICollection<Sale> Sales { get; set; }
}

