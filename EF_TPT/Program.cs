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

        private static Random _seed = new Random();

        static string NewSerialNumber()
        {
            return string.Format("{0:00000000}", _seed.NextDouble() * (double)100000000);
        }

        static Car NewCar()
        {
            return new Car
            {
                Model = "Chevrolet Cruze LTZ",
                Parts = new List<CarPart>
                {
                    new Wheel(NewSerialNumber(), "Bridgestone",17.0,225.0),
                    new Wheel(NewSerialNumber(), "Bridgestone",17.0,225.0),
                    new Wheel(NewSerialNumber(), "Bridgestone",17.0,225.0),
                    new Wheel(NewSerialNumber(), "Bridgestone",17.0,225.0),
                    new Door(NewSerialNumber(), Door.DoorPositionEnum.FrontLeft),
                    new Door(NewSerialNumber(), Door.DoorPositionEnum.FrontRight),
                    new Seat(NewSerialNumber(),"Sparco",Seat.SeatMaterialEnum.Leather,Seat.SeatTypeEnum.Sportive),
                    new Seat(NewSerialNumber(), "Sparco",Seat.SeatMaterialEnum.Fabric,Seat.SeatTypeEnum.Comfort)
                }
            };
        }

        static void PrintParts(string partName, IEnumerable<CarPart> parts)
        {
            Console.WriteLine("*** {0} ({1}):", partName, parts.Count());
            parts.ToList().ForEach(Console.WriteLine);
        }

        static void Main(string[] args)
        {
            // The database will be created at bin/Debug/ by default
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ""));
            // Get a new context for de DB (always "using" to dispose the connection)
            using (var context = new CarBoundContext())
            {
                // If no records, let's create one...
                if (context.Cars.Count() == 0)
                {
                    context.Cars.Add(NewCar());
                    context.SaveChanges();
                }
                // Fetch the record and display its parts!
                var car = context.Cars.First();
                Console.WriteLine("Model: {0}", car.Model);
                Console.WriteLine("Total parts: {0}", car.Parts.Count);

                PrintParts("Doors", car.Parts.Where(part => part is Door));
                PrintParts("Seats", car.Parts.Where(part => part is Seat));
                PrintParts("Wheels", car.Parts.Where(part => part is Wheel));

                Console.ReadLine();
            }
        }
    }
}
