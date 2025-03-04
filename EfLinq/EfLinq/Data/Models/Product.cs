using System;
using System.Collections.Generic;

namespace EfLinq.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category1? Category { get; set; }
}
