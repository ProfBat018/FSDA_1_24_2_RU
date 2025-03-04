using System;
using System.Collections.Generic;

namespace EfLinq.Data.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Pages { get; set; }

    public int YearPress { get; set; }

    public int IdThemes { get; set; }

    public int IdCategory { get; set; }

    public int IdAuthor { get; set; }

    public int IdPress { get; set; }

    public string? Comment { get; set; }

    public int Quantity { get; set; }

    public  Author IdAuthorNavigation { get; set; } = null!;

    public  Category IdCategoryNavigation { get; set; } = null!;

    public  Press IdPressNavigation { get; set; } = null!;

    public  Theme IdThemesNavigation { get; set; } = null!;

    public  ICollection<SCard> SCards { get; set; } = new List<SCard>();

    public  ICollection<TCard> TCards { get; set; } = new List<TCard>();
}
