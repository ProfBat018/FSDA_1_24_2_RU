using EfLinq.Data.Contexts;
using EfLinq.Data.Models;
using Microsoft.EntityFrameworkCore;


using var context = new LibraryContext();

/*
//var books = context.Books
//    .Include(b => b.IdAuthorNavigation)
//    .Include(b => b.IdCategoryNavigation)
//    .Select(nb => new 
//    {
//        nb.Name,
//        nb.IdAuthorNavigation.FirstName,
//        nb.IdAuthorNavigation.LastName,
//        CategoryName = nb.IdCategoryNavigation.Name
//    })
//    .Where(x => x.Name == "SQL Server Part 1")
//    .Single();


//Console.WriteLine(books.Name);

//foreach (var book in books)
//{
//    Console.WriteLine($"{book.Name}\t {book.FirstName}\t {book.LastName}" +
//        $"t {book.CategoryName}");
//}

*/


var res = context.Authors
    .Where(a => a.FirstName == "Sergey")
    .SelectMany(x => x.Books);

Console.WriteLine(res.ToQueryString());

foreach (var item in res)
{
    Console.WriteLine(item.Name);
}





