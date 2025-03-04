using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class Product
{
    public Guid Id { get; set; }

    public string ProductName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Warehouse? Warehouse { get; set; }

    public virtual ICollection<Category> CategoryRefs { get; set; } = new List<Category>();
}
