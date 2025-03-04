using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class Warehouse
{
    public Guid ProductId { get; set; }

    public int Count { get; set; }

    public virtual Product Product { get; set; } = null!;
}
