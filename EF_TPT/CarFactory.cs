using EF_TPT.Domain.Entities;
using EF_TPT.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TPT
{
    public class CarFactory
    {

        #region .: Private fields :.
        private Random _seed = new Random();
        private static List<string> CarNames = new List<string> { "Chevrolet Cruze", "Seat Leon", "Audi A4", "Mercedes SLK", "Subaru Imprezza" };
        private static List<string> WheelBrands = new List<string> { "Bridgestone", "Dunlop", "Michelin", "Kumo" };
        private static List<string> SeatBrands = new List<string> { "Sparco", "BC Line", "Recaro", "FK", "BUTZI" };
        private static List<decimal> WheelRadiuses = new List<decimal> { 15.0m, 16.0m, 17.0m, 18.0m, 19.0m };
        private static List<decimal> WheelWidths = new List<decimal> { 165.0m, 170.0m, 175.0m, 180.0m, 185.0m, 190.0m, 195.0m, 200.0m, 205.0m, 210.0m, 215.0m, 220.0m, 225.0m };
        #endregion

        #region .: Public Methods :.

        public Car CreateNewRandomCar()
        {
            var parts = new List<CarPart>();
            parts.AddRange(CreateRandomDoors());
            parts.AddRange(CreateRandomSeats());
            parts.AddRange(CreateRandomWheels());
            return new Car
            {
                Model = CarNames.GetRandomElement(_seed),
                Parts = parts
            };
        }

        #endregion

        #region .: Private Methods :.

        private IEnumerable<Door> CreateDoors()
        {
            return new List<Door>
            {
                new Door(GetRandomSerialNumber(), Door.DoorPositionEnum.FrontLeft),
                new Door(GetRandomSerialNumber(), Door.DoorPositionEnum.FrontRight)
            };
        }

        private IEnumerable<Wheel> CreateRandomWheels()
        {
            var result = typeof(Wheel.WheelPositionEnum)
                .AsEnumerable<Wheel.WheelPositionEnum>()
                .Select(position => new Wheel(GetRandomSerialNumber(), position, WheelBrands.GetRandomElement(_seed), 
                            WheelRadiuses.GetRandomElement(_seed), WheelWidths.GetRandomElement(_seed)));
            return result;
        }

        private IEnumerable<Seat> CreateRandomSeats()
        {
            var result = typeof(Seat.SeatPositionEnum)
                .AsEnumerable<Seat.SeatPositionEnum>()
                .Select(position => new Seat(GetRandomSerialNumber(), position, SeatBrands.GetRandomElement(_seed),
                             typeof(Seat.SeatMaterialEnum).AsEnumerable<Seat.SeatMaterialEnum>().GetRandomElement(_seed),
                             typeof(Seat.SeatTypeEnum).AsEnumerable<Seat.SeatTypeEnum>().GetRandomElement(_seed)));
            return result;
        }

        private IEnumerable<Door> CreateRandomDoors()
        {
            var result = typeof(Door.DoorPositionEnum)
                .AsEnumerable<Door.DoorPositionEnum>()
                .Select(position => new Door(GetRandomSerialNumber(), position));
            return result;
        }

        #endregion

        #region .: Utility :.

        private string GetRandomSerialNumber()
        {
            return string.Format("{0:00000000}", _seed.NextDouble() * (double)100000000);
        }

        #endregion

    }
}
