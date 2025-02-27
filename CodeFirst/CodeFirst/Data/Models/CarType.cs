using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeFirst.Data.Models;

public class CarType
{
    [Key] public int Id { get; set; }
    
    [Required] 
    [MaxLength(50)]
    public string CarTypeName { get; set; }

    public ICollection<CarType> Cars { get; set; }
}