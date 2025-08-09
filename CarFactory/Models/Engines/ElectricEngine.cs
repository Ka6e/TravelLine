using CarFactory.Models.Engines.FuelType;

namespace CarFactory.Models.Engines
{
    public class ElectricEngine : IEngine
    {
        public string Name => "Electric Engine";
        public FuelKind FuelType => FuelKind.Electric;
        public int HorsePower => 486;
        public double Volume => 0;
        public int MaxRPM => 15000;
    }
}
