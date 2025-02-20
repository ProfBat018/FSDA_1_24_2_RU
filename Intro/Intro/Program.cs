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

var configBuilder = new ConfigurationBuilder();

configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Default");

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

var commandString = "select * from Users where userName = @userName;" +
    "select * from UserRoles where userNameRef = @userName;";

using var connection = new SqlConnection(connectionString);
connection.Open();

using var multi = connection.QueryMultiple(commandString, new {userName = "emily_clark"});

var user = multi.Read<User>().Single();

var userRoles = multi.Read<UserRole>();

Console.WriteLine(user);

foreach(var userRole in userRoles)
{
    Console.WriteLine(userRole);
}

#endregion