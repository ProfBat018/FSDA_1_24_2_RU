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
    public CarType CarType { get; set; }
    
    [ForeignKey("FuelType")]
    public int FuelTypeId { get; set; }
    public FuelType FuelType { get; set; }
}