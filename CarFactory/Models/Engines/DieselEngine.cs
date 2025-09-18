using CarFactory.Models.Engines.FuelType;

namespace CarFactory.Models.Engines
{
    public class DieselEngine : IEngine
    {
        public string Name => "Diesel Engine";
        public FuelKind FuelType => FuelKind.Diesel;
        public int HorsePower => 400;
        public double Volume => 3.0;
        public int MaxRPM => 4500;
    }
}
