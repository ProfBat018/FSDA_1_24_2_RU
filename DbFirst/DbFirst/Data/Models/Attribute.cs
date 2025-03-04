using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class Attribute
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual ICollection<Category> CategoryRefs { get; set; } = new List<Category>();
}
