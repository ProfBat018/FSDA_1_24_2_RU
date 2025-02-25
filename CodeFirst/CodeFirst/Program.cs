using CodeFirst.Data.Contexts;
using CodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;

using var context = new ShowroomContext();

#region Part1



// context.FuelTypes.Add(new()
// {
//     FuelName = "Petrol"
// });

// var fuelTypesToAdd = new List<FuelType>()
// {
//     new() { FuelName = "Diesel" },
//     new() { FuelName = "Electric" },
//     new() { FuelName = "LPG" },
//     new() { FuelName = "Hybrid" },
//     new() { FuelName = "CNG" }
// };
//
// context.FuelTypes.AddRange(fuelTypesToAdd);
//
// context.SaveChanges();

#endregion


#region Part2

// var fuelTypes = context.FuelTypes.ToList();
//
// foreach(var fuel in fuelTypes)
// {
//     Console.WriteLine(fuel.FuelName);
// }

// var fuelTypes = context.FuelTypes;
//
// foreach(var fuel in fuelTypes)
// {
//     Console.WriteLine(fuel.FuelName);
// }
//


#endregion

#region Part3

// var carTypesToAdd = new List<CarType>()
// {
//     new() { CarTypeName = "Sedan" },
//     new() { CarTypeName = "SUV" },
//     new() { CarTypeName = "Hatchback" },
//     new() { CarTypeName = "Coupe" },
//     new() { CarTypeName = "Convertible" }
// };
//
// context.CarTypes.AddRange(carTypesToAdd);
//
// context.SaveChanges();


#endregion


#region Part4
/*

var carsToAdd = new List<Car>()
{
    new()
    {
        Make = "Toyota",
        Model = "Corolla",
        Year = new DateTime(2022, 1, 1),
        Mileage = 0,
        CarTypeId = 1,
        FuelTypeId = 1
    },
    new()
    {
        Make = "Toyota",
        Model = "Camry",
        Year = new DateTime(2022, 1, 1),
        Mileage = 0,
        CarTypeId = 1,
        FuelTypeId = 1
    },
    new()
    {
        Make = "Toyota",
        Model = "RAV4",
        Year = new DateTime(2022, 1, 1),
        Mileage = 0,
        CarTypeId = 2,
        FuelTypeId = 5
    }
};

context.Cars.AddRange(carsToAdd);

context.SaveChanges();
*/
#endregion

#region Part5

// Where 
// var petrolCars = context.Cars
//     .Include(c => c.FuelType)
//     .Where(c => c.FuelType.FuelName == "Petrol");
//
// Console.WriteLine(petrolCars.ToQueryString());
//
// foreach(var car in petrolCars)
// {
//     Console.WriteLine($"{car.Make} {car.Model} {car.Year} {car.FuelType.FuelName}");
// }
//


#endregion


#region Part6

// Where 
var petrolCars = context.Cars
    .Include(c => c.FuelType)
    .Where(c => c.FuelType.FuelName == "Petrol")
    .Select(c => new {c.Make, c.Model, c.Year, c.FuelType.FuelName});

Console.WriteLine(petrolCars.ToQueryString());

foreach(var car in petrolCars)
{
    Console.WriteLine($"{car.Make} {car.Model} {car.Year} {car.FuelName}");
}


#endregion