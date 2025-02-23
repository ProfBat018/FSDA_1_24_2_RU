using System.Threading.Channels;
using Dapper;
using Intro;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

#region Part1
/*
var connectionString = "Data Source=localhost; Initial Catalog=Auth_24_2; User Id=sa; Password=Elvin123; Trust Server Certificate=true";
var commandString = "select userName from Users";

using var connection = new SqlConnection(connectionString);
connection.Open();

using var command = new SqlCommand(commandString, connection);

using var reader = command.ExecuteReader();

while (reader.Read())
{
    // Console.WriteLine(reader["userName"]);
    Console.WriteLine(reader.GetString(0));
}

Console.WriteLine("Connected to Database");
*/
#endregion

#region AuthConnection
// var configBuilder = new ConfigurationBuilder();
//
// configBuilder.AddJsonFile("appsettings.json");
//
// var config = configBuilder.Build();
//
// var connectionString = config.GetConnectionString("Default");

#endregion

#region Part2
/*
 
var commandString = "select * from Users";

using var connection = new SqlConnection(connectionString);

connection.Open();

var res = connection.Query<User>(commandString);

foreach(var user in res)
{
    Console.WriteLine(user);
}
*/
#endregion

#region Part3

// var commandString = "select count(*) from Users";
//
// using var connection = new SqlConnection(connectionString);
// connection.Open();
//
// var count = connection.ExecuteScalar<int>(commandString);
//
// Console.WriteLine(count);
//
#endregion

#region Part4
//
// var commandString = "select * from Users where userName = 'alice_smith'";
//
// using var connection = new SqlConnection(connectionString);
// connection.Open();
//
// var user = connection.QuerySingle<User>(commandString);
//
// Console.WriteLine(user);

#endregion

#region Part5

// Параметризованный запрос

// var commandString = "select * from Users where userName = @userName";
//
// using var connection = new SqlConnection(connectionString);
// connection.Open();
//
// var user = connection.QuerySingle<User>(commandString, new {userName = "alice_smith"});
//
// Console.WriteLine(user);


#endregion

#region Part6

// var commandString = "select * from Users where userName = @userName;" +
//     "select * from UserRoles where userNameRef = @userName;";
//
// using var connection = new SqlConnection(connectionString);
// connection.Open();
//
// using var multi = connection.QueryMultiple(commandString, new {userName = "emily_clark"});
//
// var user = multi.Read<User>().Single();
//
// var userRoles = multi.Read<UserRole>();
//
// Console.WriteLine(user);
//
// foreach(var userRole in userRoles)
// {
//     Console.WriteLine(userRole);
// }

#endregion

#region Part7 

// Non-query ADO.NET 

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
// var sqlQuery = "insert into Roles values(N'Editor');";
//
// var command = new SqlCommand(sqlQuery, connection);
//
// int ExecutedRows = command.ExecuteNonQuery();
//

#endregion


#region Part8 

// Insert Dapper 

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var users = new List<User>()
// {
//     new User("Evin_123", "Elvin_1234", "profbat018@gmail.com"),
//     new User("Ramazan_123", "Ramazan_1234", "ramazan@gmail.com")
// };
//
//
// var sqlQuery = "insert into Users(userName, password, email) values(@UserName, @Password, @Email);";
//
// var affectedRows = connection.Execute(sqlQuery, users);
//

#endregion

// В связи со сложной структурой примеров мы будет подключаться к базе данных Ecommerce

#region EcommerceConnection

var configBuilder = new ConfigurationBuilder();

configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Ecommerce");

#endregion

#region Part9 
//
// using var connection = new SqlConnection(connectionString);
// connection.Open();
//
// var sqlQuery = """
//                SELECT 
//                    C.CategoryID, C.Name, 
//                    Pc.CategoryID AS ParentCategoryID, Pc.Name 
//                FROM Categories AS C
//                INNER JOIN Categories AS Pc ON Pc.CategoryID = C.ParentCategoryID
//                WHERE C.ParentCategoryID IS NOT NULL;
//                """;
//
// var categories = connection.Query<Category, Category, Category>(
//     sqlQuery,
//     (category, parentCategory) =>
//     {
//         category.ParentCategory = parentCategory;
//         return category;
//     },
//     splitOn: "ParentCategoryID" // Теперь эта колонка есть в SELECT
// );
//
// foreach (var category in categories)
// {
//     Console.WriteLine($"{category.CategoryID}\t {category.Name}\t{category.ParentCategory.Name}");
// }

#endregion

#region Part10

// many to many
//
// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var sqlQuery = """
//                select p.Name, c.Name from ProductCategories
//                inner join dbo.Products P on P.ProductID = ProductCategories.ProductID
//                inner join dbo.Categories C on C.CategoryID = ProductCategories.CategoryID; 
//                """;
//
//
// var productCategories = connection.Query<Product, Category, Product>(
//     sqlQuery,
//     (product, category) =>
//     {
//         product.Categories.Add(category);
//         return product;
//     },
//     splitOn: "Name"
// );
//
// foreach (var product in productCategories)
// {
//     Console.WriteLine($"{product.Name}");
//     foreach (var category in product.Categories)
//     {
//         Console.WriteLine($"\t{category.Name}");
//     }
// }

#endregion
