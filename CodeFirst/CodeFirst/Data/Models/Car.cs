using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Data.Models;

public class Car
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Make { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Required]
    public DateTime Year { get; set; }
    
    public uint Mileage { get; set; } = 0;
    
    [ForeignKey("CarType")]
    public int CarTypeId { get; set; }
    public virtual CarType CarType { get; set; }
    
    [ForeignKey("FuelType")]
    public int FuelTypeId { get; set; }
    public virtual FuelType FuelType { get; set; }

    public override string ToString()
    {
        return $"{Make}\t{Model}\t{Year}\t{CarType.CarTypeName}\t{FuelType.FuelName}";
    }
}