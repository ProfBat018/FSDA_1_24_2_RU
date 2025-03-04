using DbFirst;
using Microsoft.EntityFrameworkCore;

using var context = new TechCommerceContext();


// var categories = 
//     from c in context.Categories
//     join ParentCategory in context.Categories on c.CategoryNameRef equals ParentCategory.CategoryName
//     select c.CategoryName + " -> " + ParentCategory.CategoryName;


var categories =
    from c in context.Categories
    join ParentCategory in context.Categories on c.CategoryNameRef equals ParentCategory.CategoryName
    select new
    {
        CategoryName = c.CategoryName,
        ParentCategoryName = ParentCategory.CategoryName
    };


foreach (var category in categories)
{
    Console.WriteLine($"{category.CategoryName} => {category.ParentCategoryName}");
}

