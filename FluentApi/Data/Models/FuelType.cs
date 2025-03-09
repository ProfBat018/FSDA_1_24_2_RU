namespace FluentApi.Data.Models;

public class FuelType
{
    public int Id { get; set; }
    public string FuelName { get; set; }
    
    public ICollection<Car> Cars { get; set; }
}