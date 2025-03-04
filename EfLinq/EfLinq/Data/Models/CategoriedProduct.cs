using System;
using System.Collections.Generic;

namespace EfLinq.Data.Models;

public partial class CategoriedProduct
{
    public string? CategoryName { get; set; }

    public string? ProductName { get; set; }
}
