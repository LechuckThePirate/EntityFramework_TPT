using EF_TPT.Infrastructure.BoundContexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EF_TPT.Domain.Entities;
using EF_TPT.Domain.Entities.Base;

namespace EF_TPT
{
    class Program
    {
        #region .: Fields :.
        private static CarFactory _carFactory = new CarFactory();
        #endregion

        #region .: Main Program :.

        static void Main(string[] args)
        {

            // The database will be created at bin/Debug/ by default
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine("c:\\temp\\", ""));
            // Get a new context for de DB (always "using" to dispose the connection)
            using (var context = new CarBoundContext())
            {
                do
                {
                    switch (ShowMenu(context.Cars.Count()))
                    {
                        case ConsoleKey.D1:
                            var newCar = CreateNewCar(context);
                            ShowNewCar(newCar);
                            break;
                        case ConsoleKey.D2:
                            var cars = GetCars(context);
                            ShowCars(cars);
                            break;
                        case ConsoleKey.D3:
                            var updatedCar = UpdateRandomCar(context);
                            ShowUpdatedCar(updatedCar);
                            break;
                        case ConsoleKey.D4:
                            RemoveAllCars(context);
                            break;
                        case ConsoleKey.D0:
                            return;
                    }

                    Console.Clear();

                } while (true);
            }
        }

        #endregion

        #region .: Repository Operations :.

        static Car CreateNewCar(CarBoundContext context)
        {
            var newCar = _carFactory.CreateNewRandomCar();
            context.Cars.Add(newCar);
            context.SaveChanges();
            return newCar;
        }

        static IEnumerable<Car> GetCars(CarBoundContext context)
        {
            return context.Cars;
        }

        static Car UpdateRandomCar(CarBoundContext context)
        {
            var randomCar = context.Cars.GetRandomElement();
            randomCar.Model += $" (modified {DateTime.Now}";
            context.SaveChanges();
            return randomCar;
        }

        static void RemoveAllCars(CarBoundContext context)
        {
            var cars = context.Cars;
            var count = cars.Count();
            cars.RemoveRange(cars);
            context.SaveChanges();
            Console.Clear();
            Console.WriteLine($"Removed {count} cars from repository.");
            PressAnyKey();
        }

        #endregion

        #region .: Console stuff :.

        static void PrintParts(string partName, IEnumerable<CarPart> parts)
        {
            Console.WriteLine("    *** {0} ({1}):", partName, parts.Count());
            parts.ToList().ForEach(Console.WriteLine);
        }

        static void ShowOneCar(Car car)
        {
            Console.WriteLine("Model: {0}", car.Model);
            Console.WriteLine("Total parts: {0}", car.Parts.Count);

            PrintParts("Doors", car.Parts.OfType<Door>());
            PrintParts("Seats", car.Parts.OfType<Seat>());
            PrintParts("Wheels", car.Parts.OfType<Wheel>());
            if (car.Created != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Created {car.Created:dd/MM/yyyy hh:mm} by {car.CreatedBy}");
            }
            if (car.Updated != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Updated {car.Updated:dd/MM/yyyy hh:mm} by {car.UpdatedBy}");
            }
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }

        static void ShowCars(IEnumerable<Car> cars)
        {
            Console.Clear();
            Console.WriteLine($"Listing {cars.Count()} in repository.");
            Console.WriteLine();
            cars.ToList().ForEach(car => ShowOneCar(car));
            PressAnyKey();
        }

        static void ShowNewCar(Car newCar)
        {
            Console.Clear();
            Console.WriteLine("New car added to repository:");
            ShowOneCar(newCar);
            PressAnyKey();
        }

        static void ShowUpdatedCar(Car updatedCar)
        {
            Console.Clear();
            Console.WriteLine("Car description updated for:");
            ShowOneCar(updatedCar);
            PressAnyKey();
        }

        static ConsoleKey ShowMenu(long carCount)
        {
            Console.Clear();
            Console.WriteLine($"There are {carCount} in the repository.");
            Console.WriteLine("Options:");
            Console.WriteLine("    1 : Add new random car to repository");
            Console.WriteLine("    2 : Show all cars");
            Console.WriteLine("    3 : Update random car");
            Console.WriteLine("    4 : Truncate table (remove all cars)");
            Console.WriteLine();
            Console.WriteLine("    0 : Exit");
            return Console.ReadKey().Key;
        }

        static void PressAnyKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        #endregion
    }
}
