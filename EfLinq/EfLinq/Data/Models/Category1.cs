using System;
using System.Collections.Generic;

namespace EfLinq.Data.Models;

public partial class Category1
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
