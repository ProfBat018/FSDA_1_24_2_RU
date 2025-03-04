using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class AttributeValue
{
    public Guid AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public string CategoryRef { get; set; } = null!;

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual Category CategoryRefNavigation { get; set; } = null!;
}
