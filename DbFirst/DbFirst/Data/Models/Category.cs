using System;
using System.Collections.Generic;

namespace DbFirst;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public string CategoryNameRef { get; set; } = null!;

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual Category CategoryNameRefNavigation { get; set; } = null!;

    public virtual ICollection<Category> InverseCategoryNameRefNavigation { get; set; } = new List<Category>();

    public virtual ICollection<Attribute> AttributesRefs { get; set; } = new List<Attribute>();

    public virtual ICollection<Product> ProductRefs { get; set; } = new List<Product>();
}
