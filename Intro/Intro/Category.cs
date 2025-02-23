namespace Intro;

public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Category? ParentCategory { get; set; } // Навигационное свойство
}