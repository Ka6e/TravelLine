using CarFactory.Models.Engines.FuelType;

namespace CarFactory.Models.Engines
{
    public class PetrolEngine : IEngine
    {
        public string Name => "Petrol Engine";
        public FuelKind FuelType => FuelKind.Petrol;
        public int MaxRPM => 7000;
        public int HorsePower => 300;
        public double Volume => 2.5;
    }
}
